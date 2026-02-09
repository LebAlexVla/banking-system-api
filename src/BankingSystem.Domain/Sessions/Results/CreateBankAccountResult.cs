using BankingSystem.Domain.BankAccounts;

namespace BankingSystem.Domain.Sessions.Results;

public abstract record CreateBankAccountResult
{
    private CreateBankAccountResult() { }

    public sealed record Success(BankAccount BankAccount) : CreateBankAccountResult;

    public sealed record Failure(string Message) : CreateBankAccountResult;
}