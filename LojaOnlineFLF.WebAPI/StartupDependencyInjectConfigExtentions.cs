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
            services.AddScoped<IClientesRepository>(servicesProvider => {
                var factory = servicesProvider.GetService<IRepositoryFactory>();
                return factory.Create<IClientesRepository>();
            });
            services.AddScoped<IVendasRepository>(servicesProvider => {
                var factory = servicesProvider.GetService<IRepositoryFactory>();
                return factory.Create<IVendasRepository>();
            });
            services.AddScoped<ICargos>(servicesProvider => {
                var factory = servicesProvider.GetService<IFuncionariosRepository>();
                return factory.ObterCargosAsync().Result;
            });

            //Services
            services.AddScoped<IFuncionariosService, FuncionariosService>();
            services.AddScoped<IAcessosService, AcessosService>();
            services.AddScoped<IProdutosService, ProdutosService>();
            services.AddScoped<IClientesService, ClientesService>();
            services.AddScoped<IVendasService, VendasService>();
            services.AddScoped<IAuthService, AuthService>();

            //Validators
            services.AddScoped<IValidator<FuncionarioTO>, FuncionarioValidator>();
            services.AddScoped<IValidator<Login>, AcessoValidator>();
            services.AddScoped<IValidator<ProdutoTO>, ProdutoValidator>();
            services.AddScoped<IValidator<ClienteTO>, ClienteValidator>();
            services.AddScoped<IValidator<VendaTO>, VendaValidator>();
            services.AddScoped<IValidator<VendaTO.ItemTO>, VendaValidator.ItemValidator>();
            services.AddScoped<IValidator<VendaItemTO>, VendaItemValidator>();

            //services.AddTransient<ProblemDetailsFactory, CustomProblemDetailsFactory>();

            return services;
        }
    }
}
