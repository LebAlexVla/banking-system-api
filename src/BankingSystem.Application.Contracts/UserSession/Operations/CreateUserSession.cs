using BankingSystem.Application.Contracts.UserSession.Models;

namespace BankingSystem.Application.Contracts.UserSession.Operations;

public static class CreateUserSession
{
    public readonly record struct Request(long AccountNumber, long PinCode);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(UserSessionDto UserSessionDto) : Response;

        public sealed record Failure(string Message) : Response;
    }
}