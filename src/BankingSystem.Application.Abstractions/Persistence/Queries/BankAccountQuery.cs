using BankingSystem.Domain.BankAccounts;
using SourceKit.Generators.Builder.Annotations;

namespace BankingSystem.Application.Abstractions.Persistence.Queries;

[GenerateBuilder]
public sealed partial record BankAccountQuery(BankAccountId[] Ids);