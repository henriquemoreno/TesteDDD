using Microsoft.Extensions.DependencyInjection;
using Teste.DDD.Domain.Interfaces.Repository;
using Teste.DDD.Domain.Interfaces.Service;
using Teste.DDD.Domain.Services;
using Teste.DDD.Infra.Data.Context;
using Teste.DDD.Infra.Data.Interfaces;
using Teste.DDD.Infra.Data.Repository;
using Teste.DDD.Infra.Data.UoW;
using TesteDDD.Application.Interfaces;
using TesteDDD.Application.Services;

namespace TesteDDD.UI.Site.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MyContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            return services;
        }
    }
}
