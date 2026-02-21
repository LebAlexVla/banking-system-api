using BankingSystem.Application.Contracts.AdminSession;
using BankingSystem.Application.Contracts.AdminSession.Models;
using BankingSystem.Application.Contracts.AdminSession.Operations;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BankingSystem.Presentation.Http.Controllers;

[ApiController]
[Route("api/admin")]
public sealed class AdminSessionController : ControllerBase
{
    private readonly IAdminSessionCreateService _adminSessionCreateService;
    private readonly IAdminSessionService _adminSessionService;

    public AdminSessionController(IAdminSessionCreateService adminSessionCreateService, IAdminSessionService adminSessionService)
    {
        _adminSessionCreateService = adminSessionCreateService;
        _adminSessionService = adminSessionService;
    }

    [HttpPost("session")]
    public ActionResult<AdminSessionDto> CreateSession(string password)
    {
        var request = new CreateAdminSession.Request(password);
        CreateAdminSession.Response response = _adminSessionCreateService.Create(request);

        return response switch
        {
            CreateAdminSession.Response.Success success => Ok(success.AdminSession),
            CreateAdminSession.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("session/account")]
    public ActionResult<BankAccountDto> CreateAccount(string adminSessionId, long pinCode)
    {
        var request = new CreateBankAccount.Request(adminSessionId, pinCode);
        CreateBankAccount.Response response = _adminSessionService.CreateBankAccount(request);

        return response switch
        {
            CreateBankAccount.Response.Success success => Ok(success.Account),
            CreateBankAccount.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }
}