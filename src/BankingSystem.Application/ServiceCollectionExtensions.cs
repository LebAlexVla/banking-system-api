using BankingSystem.Application.Contracts.AdminSession;
using BankingSystem.Application.Contracts.UserSession;
using BankingSystem.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BankingSystem.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IAdminSessionCreateService, AdminSessionCreateService>();
        collection.AddScoped<IAdminSessionService, AdminSessionService>();
        collection.AddScoped<IUserSessionCreateService, UserSessionCreateService>();
        collection.AddScoped<IUserSessionService, UserSessionService>();

        return collection;
    }
}