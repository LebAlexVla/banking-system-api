using BankingSystem.Application.Abstractions.Generation;
using BankingSystem.Domain.ValueObjects;

namespace BankingSystem.Infrastructure.Authentication;

public class AccountNumberGenerator : IAccountNumberGenerator
{
    private long _number = long.MaxValue;

    public AccountNumber Generate()
    {
        _number--;

        return new AccountNumber(_number);
    }
}