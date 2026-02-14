using BankingSystem.Application.Abstractions.Authentication;
using BankingSystem.Application.Abstractions.Persistence;
using BankingSystem.Application.Contracts.AdminSession;
using BankingSystem.Application.Contracts.AdminSession.Models;
using BankingSystem.Application.Contracts.AdminSession.Operations;
using BankingSystem.Domain.Sessions;

namespace BankingSystem.Application.Services;

public class AdminSessionCreateService : IAdminSessionCreateService
{
    private readonly IAdminPasswordVerifier _adminPasswordVerifier;
    private readonly IPersistenceContext _persistenceContext;

    public AdminSessionCreateService(IPersistenceContext persistenceContext, IAdminPasswordVerifier adminPasswordVerifier)
    {
        _persistenceContext = persistenceContext;
        _adminPasswordVerifier = adminPasswordVerifier;
    }

    public CreateAdminSession.Response Create(CreateAdminSession.Request request)
    {
        if (!_adminPasswordVerifier.Verify(request.Password))
        {
            return new CreateAdminSession.Response.Failure("Invalid admin password");
        }

        var adminSessionId = Guid.NewGuid();
        var adminSession = new AdminSession(adminSessionId);
        _persistenceContext.AdminSession.Save(adminSession);

        return new CreateAdminSession.Response.Success(new AdminSessionDto(adminSessionId.ToString()));
    }
}