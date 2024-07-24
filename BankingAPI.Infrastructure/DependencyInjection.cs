using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace BankingAPI.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.Load("BankingAPI.Application"));
            return services;
        }
    }
}