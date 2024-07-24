using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace BankingAPI.Infrastructure
{
    // Static class for setting up dependency injection
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Register MediatR with the application assembly
            services.AddMediatR(Assembly.Load("BankingAPI.Application"));
            return services;
        }
    }
}