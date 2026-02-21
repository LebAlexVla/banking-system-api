using BankingSystem.Domain.ValueObjects;

namespace BankingSystem.Domain.BankAccounts;

public abstract record OperationType
{
    private OperationType() { }

    public sealed record GetBalanceOperation(Balance Amount) : OperationType;

    public sealed record WithdrawMoneyOperation(Balance Amount) : OperationType;

    public sealed record ReplenishOperation(Balance Amount) : OperationType;
}