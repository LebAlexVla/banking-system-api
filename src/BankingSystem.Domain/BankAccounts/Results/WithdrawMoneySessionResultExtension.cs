using BankingSystem.Domain.Sessions.Results;

namespace BankingSystem.Domain.BankAccounts.Results;

public static class WithdrawMoneySessionResultExtension
{
    public static WithdrawMoneySessionResult Then(this WithdrawMoneyAccountResult result)
    {
        if (result is WithdrawMoneyAccountResult.Success)
        {
            return new WithdrawMoneySessionResult.Success();
        }

        if (result is WithdrawMoneyAccountResult.Failure({ } message))
        {
            return new WithdrawMoneySessionResult.Failure(message);
        }

        return new WithdrawMoneySessionResult.Failure("Extension error");
    }
}