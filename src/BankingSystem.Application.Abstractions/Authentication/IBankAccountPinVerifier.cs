using BankingSystem.Domain.ValueObjects;

namespace BankingSystem.Application.Abstractions.Authentication;

public interface IBankAccountPinVerifier
{
    bool Verify(AccountNumber accountNumber, long pin);
}