using BankingSystem.Domain.BankAccounts.Results;
using BankingSystem.Domain.ValueObjects;

namespace BankingSystem.Domain.BankAccounts;

public class BankAccount
{
    private readonly AccountPassword _password;

    private readonly List<OperationType> _operationsHistory;

    private Balance _balance;

    public BankAccount(AccountPassword password, AccountNumber number, Balance balance, BankAccountId id)
    {
        _password = password;

        Number = number;
        _balance = balance;
        Id = id;

        _operationsHistory = [];
    }

    public BankAccountId Id { get; }

    public AccountNumber Number { get; }

    public IEnumerable<OperationType> OperationsHistory => _operationsHistory;

    public bool ComparePassword(string password)
    {
        return _password.Value == password;
    }

    public Balance GetBalance()
    {
        _operationsHistory.Add(new OperationType.GetBalanceOperation(_balance));

        return _balance;
    }

    public void Replenish(Balance balance)
    {
        _operationsHistory.Add(new OperationType.ReplenishOperation(_balance));

        _balance = _balance.IncreaseBy(balance);
    }

    public WithdrawMoneyResult WithdrawMoney(Balance balance)
    {
        if (_balance < balance)
        {
            return new WithdrawMoneyResult.Failure("Not enough money");
        }

        _operationsHistory.Add(new OperationType.WithdrawMoneyOperation(_balance));

        _balance = _balance.DecreaseBy(balance);

        return new WithdrawMoneyResult.Success();
    }
}