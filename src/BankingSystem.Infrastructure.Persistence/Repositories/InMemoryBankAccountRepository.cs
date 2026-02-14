using BankingSystem.Application.Abstractions.Persistence.Queries;
using BankingSystem.Application.Abstractions.Persistence.Repositories;
using BankingSystem.Domain.BankAccounts;
using BankingSystem.Domain.ValueObjects;

namespace BankingSystem.Infrastructure.Persistence.Repositories;

public class InMemoryBankAccountRepository : IBankAccountRepository
{
    private readonly Dictionary<AccountNumber, BankAccount> _accountsByNumber = [];
    private readonly Dictionary<BankAccountId, BankAccount> _accountsById = [];

    public BankAccount Save(BankAccount bankAccount)
    {
        if (bankAccount.Id == default)
            bankAccount.Id = new BankAccountId(_accountsById.Count + 1);

        _accountsByNumber[bankAccount.Number] = bankAccount;
        _accountsById[bankAccount.Id] = bankAccount;

        return _accountsById[bankAccount.Id];
    }

    public IEnumerable<BankAccount> Query(BankAccountIdQuery query)
    {
        if (query.Ids.Length == 0)
            return _accountsById.Values;

        return query.Ids
            .Where(id => _accountsById.TryGetValue(id, out _))
            .Select(id => _accountsById[id]);
    }

    public IEnumerable<BankAccount> Query(BankAccountNumberQuery query)
    {
        if (query.AccountNumbers.Length == 0)
            return _accountsByNumber.Values;

        return query.AccountNumbers
            .Where(accountNumber => _accountsByNumber.TryGetValue(accountNumber, out _))
            .Select(accountNumber => _accountsByNumber[accountNumber]);
    }
}