namespace BankingSystem.Domain.ValueObjects;

public sealed record Balance
{
    public Balance(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("Balance must be positive");

        Value = value;
    }

    public decimal Value { get; }
}