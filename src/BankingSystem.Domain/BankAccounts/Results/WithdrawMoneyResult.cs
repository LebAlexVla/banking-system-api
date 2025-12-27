namespace BankingSystem.Domain.BankAccounts.Results;

public abstract record WithdrawMoneyResult
{
    private WithdrawMoneyResult() { }

    public sealed record Success : WithdrawMoneyResult;

    public sealed record Failure(string Message) : WithdrawMoneyResult;
}