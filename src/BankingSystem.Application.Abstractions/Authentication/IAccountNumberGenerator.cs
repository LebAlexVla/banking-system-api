using BankingSystem.Domain.ValueObjects;

namespace BankingSystem.Application.Abstractions.Authentication;

public interface IAccountNumberGenerator
{
    AccountNumber Generate();
}