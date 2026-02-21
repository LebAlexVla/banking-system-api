using BankingSystem.Domain.BankAccounts.Results;
using BankingSystem.Domain.ValueObjects;

namespace BankingSystem.Domain.BankAccounts;

public class BankAccount
{
    private readonly List<OperationType> _operationsHistory;

    private Balance _balance;

    public BankAccount(AccountNumber number, BankAccountId id)
    {
        Number = number;
        Id = id;

        _balance = Balance.Default;
        _operationsHistory = [];
    }

    public BankAccountId Id { get; set; }

    public AccountNumber Number { get; }

    public IEnumerable<OperationType> OperationsHistory => _operationsHistory;

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

    public WithdrawMoneyAccountResult WithdrawMoney(Balance balance)
    {
        if (_balance < balance)
        {
            return new WithdrawMoneyAccountResult.Failure("Not enough money");
        }

        _operationsHistory.Add(new OperationType.WithdrawMoneyOperation(_balance));

        _balance = _balance.DecreaseBy(balance);

        return new WithdrawMoneyAccountResult.Success();
    }
}