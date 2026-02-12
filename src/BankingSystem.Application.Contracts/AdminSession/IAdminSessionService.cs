using BankingSystem.Application.Contracts.AdminSession.Operations;

namespace BankingSystem.Application.Contracts.AdminSession;

public interface IAdminSessionService
{
    CreateBankAccount.Response Create(CreateBankAccount.Request request);
}