using BankingSystem.Application;
using BankingSystem.Infrastructure.Authentication;
using BankingSystem.Infrastructure.Authentication.Configuration;
using BankingSystem.Infrastructure.Persistence;
using BankingSystem.Presentation.Http;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructurePersistence()
    .AddInfrastructureAuthentication()
    .AddPresentationHttp();

builder.Services.Configure<SystemOptions>(
    builder.Configuration.GetSection("System"));

builder.Services.AddSwaggerGen().AddEndpointsApiExplorer();

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();