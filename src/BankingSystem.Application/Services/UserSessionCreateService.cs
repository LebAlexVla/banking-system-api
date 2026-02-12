using BankingSystem.Application.Abstractions.Authentication.UserAuthentication;
using BankingSystem.Application.Abstractions.Persistence;
using BankingSystem.Application.Abstractions.Persistence.Queries;
using BankingSystem.Application.Contracts.UserSession;
using BankingSystem.Application.Contracts.UserSession.Models;
using BankingSystem.Application.Contracts.UserSession.Operations;
using BankingSystem.Domain.BankAccounts;
using BankingSystem.Domain.Sessions;
using BankingSystem.Domain.ValueObjects;

namespace BankingSystem.Application.Services;

public class UserSessionCreateService : IUserSessionCreateService
{
    private readonly IPersistenceContext _context;
    private readonly IBankAccountPinVerifier _pinVerifier;

    public UserSessionCreateService(IPersistenceContext context, IBankAccountPinVerifier pinVerifier)
    {
        _context = context;
        _pinVerifier = pinVerifier;
    }

    public CreateUserSession.Response Create(CreateUserSession.Request request)
    {
        var accountNumber = new AccountNumber(request.AccountNumber);
        if (!_pinVerifier.Verify(accountNumber, request.PinCode))
        {
            return new CreateUserSession.Response.Failure("Invalid pin code or account number");
        }

        BankAccount? bankAccount = _context.BankAccountRepository
            .Query(new BankAccountNumberQuery([accountNumber])).FirstOrDefault();
        if (bankAccount == null)
        {
            return new CreateUserSession.Response.Failure("Bank account not found");
        }

        var userSessionId = Guid.NewGuid();
        var userSession = new UserSession(userSessionId, bankAccount.Id);
        userSession = _context.UserSessionRepository.Save(userSession);

        return new CreateUserSession.Response.Success(new UserSessionDto(userSessionId.ToString()));
    }
}