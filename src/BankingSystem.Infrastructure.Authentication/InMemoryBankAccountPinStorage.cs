using BankingSystem.Application.Abstractions.Authentication;
using BankingSystem.Domain.ValueObjects;

namespace BankingSystem.Infrastructure.Authentication;

public class InMemoryBankAccountPinStorage : IBankAccountPinStorage, IBankAccountPinVerifier
{
    private readonly Dictionary<AccountNumber, long> _pins = [];

    public void SetPin(AccountNumber accountNumber, long pin)
    {
        _pins[accountNumber] = pin;
    }

    public bool Verify(AccountNumber accountNumber, long pin)
    {
        return _pins[accountNumber] == pin;
    }
}