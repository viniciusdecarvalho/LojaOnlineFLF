using FluentValidation;
using LojaOnlineFLF.Services;
using LojaOnlineFLF.WebAPI.Models;
using Microsoft.Extensions.DependencyInjection;

namespace LojaOnlineFLF.WebAPI
{
    internal static class StartupDependencyInjectExtentions
    {        
        public static IServiceCollection AddDependencyInjectConfig(this IServiceCollection services)
        {
            services.AddServicesDependencies();

            //Action Validators
            services.AddScoped<IValidator<Paginacao>, PaginacaoValidator>();
            services.AddScoped<IValidator<IdentificadorProdutoTO>, IdentificadorProdutoValidator>();
            
            return services;
        }
    }
}
