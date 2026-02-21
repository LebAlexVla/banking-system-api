using BankingSystem.Application.Contracts.UserSession.Models;

namespace BankingSystem.Application.Contracts.UserSession.Operations;

public static class UserViewOperationsHistory
{
    public readonly record struct Request(string UserSessionId);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(BankAccountOperationsHistoryDto Operations) : Response;

        public sealed record Failure(string Message) : Response;
    }
}