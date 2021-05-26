using System;
using System.IO;
using FluentValidation;
using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.DataModel.Models;
using LojaOnlineFLF.WebAPI.Services;
using LojaOnlineFLF.WebAPI.Services.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace LojaOnlineFLF.WebAPI
{
    public static class StartupDependencyInjectExtentions
    {        
        public static IServiceCollection AddDependencyInjectConfig(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryFactory, RepositoryFactory>();
            services.AddTransient<IFuncionariosRepository>(servicesProvider => {
                var factory = servicesProvider.GetService<IRepositoryFactory>();
                return factory.CreateFuncionarios();
            });
            services.AddTransient<IAcessosRepository>(servicesProvider => {
                var factory = servicesProvider.GetService<IRepositoryFactory>();
                return factory.CreateAcessos();
            });
            services.AddTransient<ICargos>(servicesProvider => {
                var factory = servicesProvider.GetService<IFuncionariosRepository>();
                return factory.ObterCargosAsync().Result;
            });
            services.AddTransient<IFuncionariosService, FuncionariosService>();
            services.AddTransient<IAcessosService, AcessosService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IValidator<FuncionarioTO>, FuncionarioValidator>();
            services.AddTransient<IValidator<Login>, AcessoValidator>();

            return services;
        }
    }
}
