using BankingSystem.Application.Abstractions.Authentication;

namespace BankingSystem.Infrastructure.Authentication;

public class AdminPasswordVerifier : IAdminPasswordVerifier
{
    public bool Verify(string password)
    {
        throw new NotImplementedException();
    }
}