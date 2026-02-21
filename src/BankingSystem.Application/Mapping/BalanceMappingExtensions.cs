using BankingSystem.Application.Contracts.UserSession.Models;
using BankingSystem.Domain.ValueObjects;

namespace BankingSystem.Application.Mapping;

public static class BalanceMappingExtensions
{
    public static BankAccountBalanceDto MapToDto(this Balance balance)
        => new BankAccountBalanceDto(balance.Value);
}