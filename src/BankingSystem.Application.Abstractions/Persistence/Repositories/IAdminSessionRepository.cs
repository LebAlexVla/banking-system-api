using BankingSystem.Application.Abstractions.Persistence.Queries;
using BankingSystem.Domain.Sessions;

namespace BankingSystem.Application.Abstractions.Persistence.Repositories;

public interface IAdminSessionRepository
{
    AdminSession Save(AdminSession adminSession);

    AdminSession Query(AdminSessionQuery query);
}