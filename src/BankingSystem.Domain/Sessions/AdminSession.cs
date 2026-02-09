using BankingSystem.Domain.Sessions.Results;

namespace BankingSystem.Domain.Sessions;

public class AdminSession
{
    public AdminSession(Guid sessionId)
    {
        SessionId = sessionId;
    }

    public Guid SessionId { get; }

    public CreateBankAccountResult CreateBankAccount()
    {
        throw new NotImplementedException();
    }
}