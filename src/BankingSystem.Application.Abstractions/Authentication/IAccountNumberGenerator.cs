using BankingSystem.Domain.ValueObjects;

namespace BankingSystem.Application.Abstractions.Generation;

public interface IAccountNumberGenerator
{
    AccountNumber Generate();
}