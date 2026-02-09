namespace BankingSystem.Domain.Sessions.Results;

public abstract record WithdrawMoneySessionResult
{
    private WithdrawMoneySessionResult() { }

    public sealed record Success : WithdrawMoneySessionResult;

    public sealed record Failure(string Message) : WithdrawMoneySessionResult;
}