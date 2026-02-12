namespace BankingSystem.Application.Abstractions.Authentication.AdminAuthentication;

public interface IAdminPasswordVerifier
{
    bool Verify(string password, string realPasswordHash);
}