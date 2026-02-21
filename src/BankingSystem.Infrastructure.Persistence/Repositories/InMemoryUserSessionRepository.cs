using BankingSystem.Application.Abstractions.Persistence.Queries;
using BankingSystem.Application.Abstractions.Persistence.Repositories;
using BankingSystem.Domain.Sessions;

namespace BankingSystem.Infrastructure.Persistence.Repositories;

public class InMemoryUserSessionRepository : IUserSessionRepository
{
    private readonly Dictionary<Guid, UserSession> _values = [];

    public UserSession Save(UserSession userSession)
    {
        _values[userSession.SessionId] = userSession;

        return _values[userSession.SessionId];
    }

    public UserSession Query(UserSessionQuery query)
    {
        return _values[query.SessionId];
    }
}