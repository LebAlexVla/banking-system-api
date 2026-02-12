using BankingSystem.Application.Abstractions.Authentication.AdminAuthentication;
using BankingSystem.Application.Abstractions.Persistence;
using BankingSystem.Application.Contracts.AdminSession;
using BankingSystem.Application.Contracts.AdminSession.Models;
using BankingSystem.Application.Contracts.AdminSession.Operations;
using BankingSystem.Domain.Sessions;

namespace BankingSystem.Application.Services;

public class AdminSessionCreateService : IAdminSessionCreateService
{
    private readonly IAdminAuthenticationContext _adminAuthenticationContext;
    private readonly IPersistenceContext _persistenceContext;

    public AdminSessionCreateService(IAdminAuthenticationContext adminAuthenticationContext, IPersistenceContext persistenceContext)
    {
        _adminAuthenticationContext = adminAuthenticationContext;
        _persistenceContext = persistenceContext;
    }

    public CreateAdminSession.Response Create(CreateAdminSession.Request request)
    {
        string passwordHash = _adminAuthenticationContext.PasswordHashProvider.GetPasswordHash();
        if (!_adminAuthenticationContext.PasswordVerifier.Verify(passwordHash, request.Password))
        {
            return new CreateAdminSession.Response.Failure("Invalid admin password");
        }

        var adminSessionId = Guid.NewGuid();
        var adminSession = new AdminSession(adminSessionId);
        _persistenceContext.AdminSession.Save(adminSession);

        return new CreateAdminSession.Response.Success(new AdminSessionDto(adminSessionId.ToString()));
    }
}