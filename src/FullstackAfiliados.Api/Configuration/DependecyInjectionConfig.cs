using FullstackAfiliados.Business.Interfaces;
using FullstackAfiliados.Business.Services;
using FullstackAfiliados.Data.Context;
using FullstackAfiliados.Data.Repositories;

namespace FullstackAfiliados.Api.Configuration;

public static class DependecyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        services.AddScoped<FullstackAfiliadosDbContext>();
        
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        
        services.AddScoped<ITransactionService, TransactionService>();
        
        return services;
    }
}