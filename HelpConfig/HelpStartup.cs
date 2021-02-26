using Domain.Interfaces.Generics;
using Infrastructure.Repository.Generics;
using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces.InterfaceConta;
using Infrastructure.Repository.Repositories;
using ApplicationApp.Interfaces;
using ApplicationApp.OpenApp;
using Domain.Interfraces.InterfaceServices;
using Domain.Services;

namespace HelpConfig
{
    public static class HelpStartup
    {
        public static void ConfigureSingleton(IServiceCollection services)
        {
            // INTERFACE E REPOSITORIO
            services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGenerics<>));
            services.AddSingleton<IConta, RepositoryConta>();

            // INTERFACE APLICAÇÃO
            services.AddSingleton<InterfaceContaApp, AppConta>();

            // SERVIÇO DOMINIO
            services.AddSingleton<IServiceConta, ServiceConta>();

        }
    }
}
