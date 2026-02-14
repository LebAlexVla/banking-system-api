using BankingSystem.Application.Abstractions.Authentication;
using BankingSystem.Configuration;
using Microsoft.Extensions.Options;

namespace BankingSystem.Infrastructure.Authentication;

public class AdminPasswordVerifier : IAdminPasswordVerifier
{
    private readonly SystemOptions _options;

    public AdminPasswordVerifier(IOptions<SystemOptions> options)
    {
        _options = options.Value;
    }

    public bool Verify(string password)
    {
        return _options.AdminPassword == password;
    }
}