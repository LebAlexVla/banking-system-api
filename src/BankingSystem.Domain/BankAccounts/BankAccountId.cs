namespace BankingSystem.Domain.BankAccounts;

public readonly record struct BankAccountId(long Value)
{
    public static readonly BankAccountId Default = new(default);
}