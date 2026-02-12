using BankingSystem.Domain.ValueObjects;

namespace BankingSystem.Application.Abstractions.Persistence.Queries;

public sealed record BankAccountNumberQuery(AccountNumber[] AccountNumber);