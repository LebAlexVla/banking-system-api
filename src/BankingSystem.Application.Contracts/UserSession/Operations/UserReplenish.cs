namespace BankingSystem.Application.Contracts.UserSession.Operations;

public static class UserReplenish
{
    public readonly record struct Request(string UserSessionId, decimal Amount);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success() : Response;

        public sealed record Failure(string Message) : Response;
    }
}