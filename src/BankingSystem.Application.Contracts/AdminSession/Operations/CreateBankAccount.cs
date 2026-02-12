using BankingSystem.Application.Contracts.AdminSession.Models;

namespace BankingSystem.Application.Contracts.AdminSession.Operations;

public static class CreateBankAccount
{
    public readonly record struct Request(string AdminSessionId, string Password);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(BankAccountDto Account) : Response;

        public sealed record Failure(string Message) : Response;
    }
}