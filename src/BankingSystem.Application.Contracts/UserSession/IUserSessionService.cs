using BankingSystem.Application.Contracts.UserSession.Operations;

namespace BankingSystem.Application.Contracts.UserSession;

public interface IUserSessionService
{
    UserGetBalance.Response GetBalance(UserGetBalance.Request request);

    UserReplenish.Response Replenish(UserReplenish.Request request);

    UserWithdrawMoney.Response WithdrawMoney(UserWithdrawMoney.Request request);

    UserViewOperationsHistory.Response ViewOperationsHistory(UserViewOperationsHistory.Request request);
}