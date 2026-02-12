namespace BankingSystem.Application.Abstractions.Authentication.AdminAuthentication;

public interface IAdminPasswordHashProvider
{
    string GetPasswordHash();
}