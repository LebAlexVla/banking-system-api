using BankingSystem.Application.Contracts.UserSession.Operations;

namespace BankingSystem.Application.Contracts.UserSession;

public interface IUserSessionCreateService
{
    CreateUserSession.Response Create(CreateUserSession.Request request);
}