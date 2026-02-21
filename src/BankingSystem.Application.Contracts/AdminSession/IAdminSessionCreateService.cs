using BankingSystem.Application.Contracts.AdminSession.Operations;

namespace BankingSystem.Application.Contracts.AdminSession;

public interface IAdminSessionCreateService
{
    CreateAdminSession.Response Create(CreateAdminSession.Request request);
}