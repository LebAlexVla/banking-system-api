namespace BankingSystem.Domain.ValueObjects;

public sealed record AccountNumber
{
    public AccountNumber(long value)
    {
        if (value < 0)
            throw new ArgumentException("Account number must be not negative");

        Value = value;
    }

    public long Value { get; }
}