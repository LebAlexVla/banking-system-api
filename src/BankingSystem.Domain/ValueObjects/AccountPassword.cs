namespace BankingSystem.Domain.ValueObjects;

public sealed record AccountPassword
{
    public AccountPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("Password cannot be null or whitespace.", nameof(password));
        }

        Value = password;
    }

    public string Value { get; }
}