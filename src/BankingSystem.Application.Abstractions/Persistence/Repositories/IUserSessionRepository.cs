using BankingSystem.Application.Abstractions.Persistence.Queries;
using BankingSystem.Domain.Sessions;

namespace BankingSystem.Application.Abstractions.Persistence.Repositories;

public interface IUserSessionRepository
{
    UserSession Save(UserSession userSession);

    UserSession Query(UserSessionQuery query);
}