using FluentValidation;
using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.DataModel.Repositories;
using LojaOnlineFLF.WebAPI.Services;
using LojaOnlineFLF.WebAPI.Services.Models;
using Microsoft.Extensions.DependencyInjection;

namespace LojaOnlineFLF.WebAPI
{
    public static class StartupDependencyInjectExtentions
    {        
        public static IServiceCollection AddDependencyInjectConfig(this IServiceCollection services)
        {
            //Repositories
            services.AddScoped<IRepositoryFactory, RepositoryFactory>();
            services.AddScoped<IAcessosRepository>(servicesProvider => {
                var factory = servicesProvider.GetService<IRepositoryFactory>();
                return factory.Create<IAcessosRepository>();
            });
            services.AddScoped<IFuncionariosRepository>(servicesProvider => {
                var factory = servicesProvider.GetService<IRepositoryFactory>();
                return factory.Create<IFuncionariosRepository>();
            });
            services.AddScoped<IProdutosRepository>(servicesProvider => {
                var factory = servicesProvider.GetService<IRepositoryFactory>();
                return factory.Create<IProdutosRepository>();
            });
            services.AddScoped<ICargos>(servicesProvider => {
                var factory = servicesProvider.GetService<IFuncionariosRepository>();
                return factory.ObterCargosAsync().Result;
            });

            //Services
            services.AddScoped<IFuncionariosService, FuncionariosService>();
            services.AddScoped<IProdutosService, ProdutosService>();
            services.AddScoped<IAcessosService, AcessosService>();
            services.AddScoped<IAuthService, AuthService>();

            //Validators
            services.AddScoped<IValidator<FuncionarioTO>, FuncionarioValidator>();
            services.AddScoped<IValidator<ProdutoTO>, ProdutoValidator>();
            services.AddScoped<IValidator<Login>, AcessoValidator>();

            //services.AddTransient<ProblemDetailsFactory, CustomProblemDetailsFactory>();

            return services;
        }
    }
}
