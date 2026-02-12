using BankingSystem.Application.Abstractions.Persistence.Repositories;

namespace BankingSystem.Application.Abstractions.Persistence;

public interface IPersistenceContext
{
    IAdminSessionRepository AdminSession { get; }

    IUserSessionRepository UserSessions { get; }

    IBankAccountRepository BankAccounts { get; }
}