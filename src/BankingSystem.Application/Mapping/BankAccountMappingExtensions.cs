using BankingSystem.Application.Contracts.AdminSession.Models;
using BankingSystem.Domain.BankAccounts;

namespace BankingSystem.Application.Mapping;

public static class BankAccountMappingExtensions
{
    public static BankAccountDto MapToDto(this BankAccount bankAccount)
        => new BankAccountDto(bankAccount.Number.Value);
}