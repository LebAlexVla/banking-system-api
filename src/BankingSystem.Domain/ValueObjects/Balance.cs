namespace BankingSystem.Domain.ValueObjects;

public readonly record struct Balance
{
    public Balance(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("Balance must be not negative");

        Value = value;
    }

    public decimal Value { get; }

    public static Balance Default => new(0);

    public static bool operator >(Balance left, Balance right)
        => left.Value > right.Value;

    public static bool operator >=(Balance left, Balance right)
        => left.Value >= right.Value;

    public static bool operator <=(Balance left, Balance right)
        => left.Value <= right.Value;

    public static bool operator <(Balance left, Balance right)
        => left.Value < right.Value;

    public Balance DecreaseBy(Balance balance)
    {
        return new Balance(Value - balance.Value);
    }

    public Balance IncreaseBy(Balance balance)
    {
        return new Balance(Value + balance.Value);
    }
}