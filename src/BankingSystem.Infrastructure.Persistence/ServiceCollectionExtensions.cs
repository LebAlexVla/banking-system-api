using BankingSystem.Application.Abstractions.Persistence;
using BankingSystem.Application.Abstractions.Persistence.Repositories;
using BankingSystem.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BankingSystem.Infrastructure.Persistence;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection collection)
    {
        collection.AddScoped<IPersistenceContext, InMemoryPersistenceContext>();

        collection.AddSingleton<IAdminSessionRepository, InMemoryAdminSessionRepository>();
        collection.AddSingleton<IUserSessionRepository, InMemoryUserSessionRepository>();
        collection.AddSingleton<IBankAccountRepository, InMemoryBankAccountRepository>();

        return collection;
    }
}