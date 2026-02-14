using BankingSystem.Application.Contracts.UserSession;
using BankingSystem.Application.Contracts.UserSession.Models;
using BankingSystem.Application.Contracts.UserSession.Operations;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BankingSystem.Presentation.Http.Controllers;

[ApiController]
[Route("api/user")]
public sealed class UserSessionController : ControllerBase
{
    private readonly IUserSessionCreateService _userSessionCreateService;
    private readonly IUserSessionService _userSessionService;

    public UserSessionController(IUserSessionCreateService userSessionCreateService, IUserSessionService userSessionService)
    {
        _userSessionCreateService = userSessionCreateService;
        _userSessionService = userSessionService;
    }

    [HttpPost("session")]
    public ActionResult<UserSessionDto> CreateSession(long accountNumber, long pinCode)
    {
        var request = new CreateUserSession.Request(accountNumber, pinCode);
        CreateUserSession.Response response = _userSessionCreateService.Create(request);

        return response switch
        {
            CreateUserSession.Response.Success success => Ok(success.UserSessionDto),
            CreateUserSession.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("session/balance")]
    public ActionResult<BankAccountBalanceDto> GetBalance(string userSessionId)
    {
        var request = new UserGetBalance.Request(userSessionId);
        UserGetBalance.Response response = _userSessionService.GetBalance(request);

        return response switch
        {
            UserGetBalance.Response.Success success => Ok(success.Balance),
            UserGetBalance.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("session/replenish")]
    public ActionResult Replenish(string userSessionId, decimal amount)
    {
        var request = new UserReplenish.Request(userSessionId, amount);
        UserReplenish.Response response = _userSessionService.Replenish(request);

        return response switch
        {
            UserReplenish.Response.Success success => Ok(success),
            UserReplenish.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("session/withdraw")]
    public ActionResult WithdrawMoney(string userSessionId, decimal amount)
    {
        var request = new UserWithdrawMoney.Request(userSessionId, amount);
        UserWithdrawMoney.Response response = _userSessionService.WithdrawMoney(request);

        return response switch
        {
            UserWithdrawMoney.Response.Success success => Ok(success),
            UserWithdrawMoney.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("session/history")]
    public ActionResult<BankAccountOperationsHistoryDto> ViewOperationsHistory(string userSessionId)
    {
        var request = new UserViewOperationsHistory.Request(userSessionId);
        UserViewOperationsHistory.Response response = _userSessionService.ViewOperationsHistory(request);

        return response switch
        {
            UserViewOperationsHistory.Response.Success success => Ok(success.Operations),
            UserViewOperationsHistory.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }
}