using BankingSystem.Application.Abstractions.Persistence.Queries;
using BankingSystem.Domain.BankAccounts;

namespace BankingSystem.Application.Abstractions.Persistence.Repositories;

public interface IBankAccountRepository
{
    BankAccount Save(BankAccount bankAccount);

    IEnumerable<BankAccount> Query(BankAccountQuery query);
}