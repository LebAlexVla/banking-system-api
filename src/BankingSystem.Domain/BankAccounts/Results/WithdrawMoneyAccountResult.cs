namespace BankingSystem.Domain.BankAccounts.Results;

public abstract record WithdrawMoneyAccountResult
{
    private WithdrawMoneyAccountResult() { }

    public sealed record Success : WithdrawMoneyAccountResult;

    public sealed record Failure(string Message) : WithdrawMoneyAccountResult;
}