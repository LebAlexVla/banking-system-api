using BankingSystem.Application.Contracts.AdminSession.Operations;

namespace BankingSystem.Application.Contracts.AdminSession;

public interface IBankAccountCreator
{
    CreateBankAccount.Response Create(CreateBankAccount.Request request);
}