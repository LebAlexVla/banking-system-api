using BankingSystem.Application.Abstractions.Persistence;
using BankingSystem.Application.Abstractions.Persistence.Queries;
using BankingSystem.Application.Contracts.UserSession;
using BankingSystem.Application.Contracts.UserSession.Operations;
using BankingSystem.Application.Mapping;
using BankingSystem.Domain.BankAccounts;
using BankingSystem.Domain.BankAccounts.Results;
using BankingSystem.Domain.Sessions;
using BankingSystem.Domain.ValueObjects;

namespace BankingSystem.Application.Services;

internal class UserSessionService : IUserSessionService
{
    private readonly IPersistenceContext _context;

    public UserSessionService(IPersistenceContext context)
    {
        _context = context;
    }

    public UserGetBalance.Response GetBalance(UserGetBalance.Request request)
    {
        UserSession? session = FindSession(request.UserSessionId);
        if (session is null)
        {
            return new UserGetBalance.Response.Failure("User session not found");
        }

        BankAccount? account = _context.BankAccounts
            .Query(new BankAccountIdQuery([session.AccountId])).FirstOrDefault();
        if (account is null)
        {
            return new UserGetBalance.Response.Failure("Account not found");
        }

        return new UserGetBalance.Response.Success(account.GetBalance().MapToDto());
    }

    public UserReplenish.Response Replenish(UserReplenish.Request request)
    {
        UserSession? session = FindSession(request.UserSessionId);
        if (session is null)
        {
            return new UserReplenish.Response.Failure("User session not found");
        }

        BankAccount? account = _context.BankAccounts
            .Query(new BankAccountIdQuery([session.AccountId])).FirstOrDefault();
        if (account is null)
        {
            return new UserReplenish.Response.Failure("Account not found");
        }

        account.Replenish(new Balance(request.Amount));

        return new UserReplenish.Response.Success();
    }

    public UserWithdrawMoney.Response WithdrawMoney(UserWithdrawMoney.Request request)
    {
        UserSession? session = FindSession(request.UserSessionId);
        if (session is null)
        {
            return new UserWithdrawMoney.Response.Failure("User session not found");
        }

        BankAccount? account = _context.BankAccounts
            .Query(new BankAccountIdQuery([session.AccountId])).FirstOrDefault();
        if (account is null)
        {
            return new UserWithdrawMoney.Response.Failure("Account not found");
        }

        WithdrawMoneyAccountResult result = account.WithdrawMoney(new Balance(request.Amount));

        if (result is WithdrawMoneyAccountResult.Failure(var message))
        {
            return new UserWithdrawMoney.Response.Failure(message);
        }

        return new UserWithdrawMoney.Response.Success();
    }

    public UserViewOperationsHistory.Response ViewOperationsHistory(UserViewOperationsHistory.Request request)
    {
        UserSession? session = FindSession(request.UserSessionId);
        if (session is null)
        {
            return new UserViewOperationsHistory.Response.Failure("User session not found");
        }

        BankAccount? account = _context.BankAccounts
            .Query(new BankAccountIdQuery([session.AccountId])).FirstOrDefault();
        if (account is null)
        {
            return new UserViewOperationsHistory.Response.Failure("Account not found");
        }

        return new UserViewOperationsHistory.Response.Success(account.OperationsHistory.MapToDto());
    }

    private UserSession? FindSession(string userSessionId)
    {
        var sessionId = Guid.Parse(userSessionId);

        return _context.UserSessions.Query(new UserSessionQuery(sessionId));
    }
}