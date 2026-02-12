using BankingSystem.Application.Abstractions.Persistence;
using BankingSystem.Application.Abstractions.Persistence.Queries;
using BankingSystem.Application.Contracts.AdminSession;
using BankingSystem.Application.Contracts.AdminSession.Operations;
using BankingSystem.Application.Mapping;
using BankingSystem.Domain.BankAccounts;
using BankingSystem.Domain.Sessions;

namespace BankingSystem.Application.Services;

public class AdminSessionService : IAdminSessionService
{
    private readonly IPersistenceContext _context;

    public AdminSessionService(IPersistenceContext context)
    {
        _context = context;
    }

    public CreateBankAccount.Response CreateBankAccount(CreateBankAccount.Request request)
    {
        var sessionId = Guid.Parse(request.AdminSessionId);

        AdminSession? adminSession = _context.AdminSession.Query(new AdminSessionQuery(sessionId));

        if (adminSession is null)
        {
            return new CreateBankAccount.Response.Failure("admin session not found");
        }

        BankAccount bankAccount = adminSession.CreateBankAccount();
        bankAccount = _context.BankAccountRepository.Save(bankAccount);

        return new CreateBankAccount.Response.Success(bankAccount.MapToDto());
    }
}