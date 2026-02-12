using BankingSystem.Application.Abstractions.Persistence.Repositories;

namespace BankingSystem.Application.Abstractions.Persistence;

public interface IPersistenceContext
{
    IAdminSessionRepository AdminSession { get; }

    IUserSessionRepository UserSessionRepository { get; }

    IBankAccountRepository BankAccountRepository { get; }
}