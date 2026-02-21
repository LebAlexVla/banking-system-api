using BankingSystem.Application.Abstractions.Persistence.Queries;
using BankingSystem.Application.Abstractions.Persistence.Repositories;
using BankingSystem.Domain.Sessions;

namespace BankingSystem.Infrastructure.Persistence.Repositories;

public class InMemoryAdminSessionRepository : IAdminSessionRepository
{
    private readonly Dictionary<Guid, AdminSession> _values = [];

    public AdminSession Save(AdminSession adminSession)
    {
        _values[adminSession.SessionId] = adminSession;

        return _values[adminSession.SessionId];
    }

    public AdminSession? Query(AdminSessionQuery query)
    {
        return _values[query.SessionId];
    }
}