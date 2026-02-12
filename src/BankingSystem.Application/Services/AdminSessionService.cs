using BankingSystem.Application.Abstractions.Authentication.UserAuthentication;
using BankingSystem.Application.Abstractions.Generation;
using BankingSystem.Application.Abstractions.Persistence;
using BankingSystem.Application.Abstractions.Persistence.Queries;
using BankingSystem.Application.Contracts.AdminSession;
using BankingSystem.Application.Contracts.AdminSession.Operations;
using BankingSystem.Application.Mapping;
using BankingSystem.Domain.BankAccounts;
using BankingSystem.Domain.Sessions;
using BankingSystem.Domain.ValueObjects;

namespace BankingSystem.Application.Services;

public class AdminSessionService : IAdminSessionService
{
    private readonly IPersistenceContext _context;
    private readonly IAccountNumberGenerator _accountNumberGenerator;
    private readonly IBankAccountPinStorage _accountPinStorage;

    public AdminSessionService(IPersistenceContext context, IAccountNumberGenerator accountNumberGenerator, IBankAccountPinStorage accountPinStorage)
    {
        _context = context;
        _accountNumberGenerator = accountNumberGenerator;
        _accountPinStorage = accountPinStorage;
    }

    public CreateBankAccount.Response CreateBankAccount(CreateBankAccount.Request request)
    {
        var sessionId = Guid.Parse(request.AdminSessionId);

        AdminSession? adminSession = _context.AdminSession.Query(new AdminSessionQuery(sessionId));
        if (adminSession is null)
        {
            return new CreateBankAccount.Response.Failure("admin session not found");
        }

        AccountNumber accountNumber = _accountNumberGenerator.Generate();
        BankAccount bankAccount = adminSession.CreateBankAccount(accountNumber, BankAccountId.Default);
        bankAccount = _context.BankAccounts.Save(bankAccount);

        _accountPinStorage.SetPin(accountNumber, request.PinCode);

        return new CreateBankAccount.Response.Success(bankAccount.MapToDto());
    }
}