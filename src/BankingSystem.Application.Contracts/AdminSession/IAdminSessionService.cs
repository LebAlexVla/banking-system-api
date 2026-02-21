using BankingSystem.Application.Contracts.AdminSession.Operations;

namespace BankingSystem.Application.Contracts.AdminSession;

public interface IAdminSessionService
{
    CreateBankAccount.Response CreateBankAccount(CreateBankAccount.Request request);
}