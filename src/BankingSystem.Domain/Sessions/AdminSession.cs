using BankingSystem.Domain.BankAccounts;
using BankingSystem.Domain.ValueObjects;

namespace BankingSystem.Domain.Sessions;

public class AdminSession
{
    public AdminSession(Guid sessionId)
    {
        SessionId = sessionId;
    }

    public Guid SessionId { get; }

    public BankAccount CreateBankAccount(AccountNumber number, BankAccountId id)
    {
        return new BankAccount(number, id);
    }
}