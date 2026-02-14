using BankingSystem.Domain.ValueObjects;

namespace BankingSystem.Application.Abstractions.Authentication;

public interface IBankAccountPinStorage
{
    void SetPin(AccountNumber accountNumber, long pin);
}