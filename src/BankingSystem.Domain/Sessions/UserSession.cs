using BankingSystem.Domain.BankAccounts;

namespace BankingSystem.Domain.Sessions;

public class UserSession
{
    public UserSession(Guid sessionId, BankAccountId accountId)
    {
        SessionId = sessionId;
        AccountId = accountId;
    }

    public Guid SessionId { get; }

    public BankAccountId AccountId { get; }
}
