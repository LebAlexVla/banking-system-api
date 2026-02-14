using BankingSystem.Application.Abstractions.Authentication;
using BankingSystem.Application.Abstractions.Generation;
using Microsoft.Extensions.DependencyInjection;

namespace BankingSystem.Infrastructure.Authentication;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureAuthentication(this IServiceCollection collection)
    {
        collection.AddSingleton<IAdminPasswordVerifier, AdminPasswordVerifier>();
        collection.AddSingleton<IBankAccountPinStorage, InMemoryBankAccountPinStorage>();
        collection.AddSingleton<IBankAccountPinVerifier, InMemoryBankAccountPinStorage>();
        collection.AddSingleton<IAccountNumberGenerator, AccountNumberGenerator>();

        return collection;
    }
}