using BankingSystem.Domain.BankAccounts;
using BankingSystem.Domain.Sessions.Results;
using BankingSystem.Domain.ValueObjects;

namespace BankingSystem.Domain.Sessions;

public class UserSession
{
    private readonly BankAccount _account;

    public UserSession(Guid sessionId, BankAccount bankAccount)
    {
        SessionId = sessionId;
        _account = bankAccount;
    }

    public Guid SessionId { get; }

    public IEnumerable<OperationType> OperationsHistory => _account.OperationsHistory;

    public Balance GetBalance()
    {
        return _account.GetBalance();
    }

    public void Replenish(Balance balance)
    {
        _account.Replenish(balance);
    }

    public WithdrawMoneySessionResult WithdrawMoney(Balance balance)
    {
        return _account.WithdrawMoney(balance).Then();
    }
}
