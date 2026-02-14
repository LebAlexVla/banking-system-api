namespace BankingSystem.Application.Abstractions.Authentication;

public interface IAdminPasswordVerifier
{
    bool Verify(string password);
}