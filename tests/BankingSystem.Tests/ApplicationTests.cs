using BankingSystem.Application.Abstractions.Persistence;
using BankingSystem.Application.Abstractions.Persistence.Queries;
using BankingSystem.Application.Contracts.UserSession.Operations;
using BankingSystem.Application.Services;
using BankingSystem.Domain.BankAccounts;
using BankingSystem.Domain.Sessions;
using BankingSystem.Domain.ValueObjects;
using NSubstitute;
using Xunit;

namespace BankingSystem.Tests;

public class ApplicationTests
{
    [Fact]
    public void WithdrawEnoughMoneySuccess()
    {
        IPersistenceContext persistence = Substitute.For<IPersistenceContext>();

        var bankAccountId = new BankAccountId(222);
        var bankAccount = new BankAccount(new AccountNumber(111), bankAccountId);
        bankAccount.Replenish(new Balance(999));
        persistence.BankAccounts.Query(Arg.Any<BankAccountIdQuery>()).Returns([bankAccount]);

        var userSessionId = Guid.NewGuid();
        var userSession = new UserSession(userSessionId, bankAccountId);
        persistence.UserSessions.Query(Arg.Any<UserSessionQuery>()).Returns(userSession);

        var userSessionService = new UserSessionService(persistence);
        UserWithdrawMoney.Response response = userSessionService
            .WithdrawMoney(new UserWithdrawMoney.Request(userSessionId.ToString(), 998));

        Assert.IsType<UserWithdrawMoney.Response.Success>(response);
        Assert.Equal(1, bankAccount.GetBalance().Value);
    }

    [Fact]
    public void WithdrawNotEnoughMoneyFailure()
    {
        IPersistenceContext persistence = Substitute.For<IPersistenceContext>();

        var bankAccountId = new BankAccountId(222);
        var bankAccount = new BankAccount(new AccountNumber(111), bankAccountId);
        persistence.BankAccounts.Query(Arg.Any<BankAccountIdQuery>()).Returns([bankAccount]);

        var userSessionId = Guid.NewGuid();
        var userSession = new UserSession(userSessionId, bankAccountId);
        persistence.UserSessions.Query(Arg.Any<UserSessionQuery>()).Returns(userSession);

        var userSessionService = new UserSessionService(persistence);
        UserWithdrawMoney.Response response = userSessionService
            .WithdrawMoney(new UserWithdrawMoney.Request(userSessionId.ToString(), 998));

        Assert.IsType<UserWithdrawMoney.Response.Failure>(response);
    }

    [Fact]
    public void ReplenishMoneySuccess()
    {
        IPersistenceContext persistence = Substitute.For<IPersistenceContext>();

        var bankAccountId = new BankAccountId(222);
        var bankAccount = new BankAccount(new AccountNumber(111), bankAccountId);
        persistence.BankAccounts.Query(Arg.Any<BankAccountIdQuery>()).Returns([bankAccount]);

        var userSessionId = Guid.NewGuid();
        var userSession = new UserSession(userSessionId, bankAccountId);
        persistence.UserSessions.Query(Arg.Any<UserSessionQuery>()).Returns(userSession);

        var userSessionService = new UserSessionService(persistence);
        UserReplenish.Response response = userSessionService
            .Replenish(new UserReplenish.Request(userSessionId.ToString(), 999));

        Assert.IsType<UserReplenish.Response.Success>(response);
        Assert.Equal(999, bankAccount.GetBalance().Value);
    }
}