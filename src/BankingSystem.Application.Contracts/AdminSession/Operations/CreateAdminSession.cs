using BankingSystem.Application.Contracts.AdminSession.Models;

namespace BankingSystem.Application.Contracts.AdminSession.Operations;

public static class CreateAdminSession
{
    public readonly record struct Request(string Password);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(AdminSessionDto AdminSession) : Response;

        public sealed record Failure(string Message) : Response;
    }
}