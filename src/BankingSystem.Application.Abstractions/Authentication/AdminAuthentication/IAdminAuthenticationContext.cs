namespace BankingSystem.Application.Abstractions.Authentication.AdminAuthentication;

public interface IAdminAuthenticationContext
{
    IAdminPasswordHashProvider PasswordHashProvider { get; }

    IAdminPasswordVerifier PasswordVerifier { get; }
}