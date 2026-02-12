using BankingSystem.Domain.BankAccounts;

namespace BankingSystem.Application.Abstractions.Persistence.Queries;

public sealed record BankAccountIdQuery(BankAccountId[] Ids);