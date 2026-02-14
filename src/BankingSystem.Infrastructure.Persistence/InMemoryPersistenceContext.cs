using BankingSystem.Application.Abstractions.Persistence;
using BankingSystem.Application.Abstractions.Persistence.Repositories;

namespace BankingSystem.Infrastructure.Persistence;

public class InMemoryPersistenceContext : IPersistenceContext
{
    public InMemoryPersistenceContext(
        IAdminSessionRepository adminSession,
        IUserSessionRepository userSessions,
        IBankAccountRepository bankAccounts)
    {
        AdminSession = adminSession;
        UserSessions = userSessions;
        BankAccounts = bankAccounts;
    }

    public IAdminSessionRepository AdminSession { get; }

    public IUserSessionRepository UserSessions { get; }

    public IBankAccountRepository BankAccounts { get; }
}