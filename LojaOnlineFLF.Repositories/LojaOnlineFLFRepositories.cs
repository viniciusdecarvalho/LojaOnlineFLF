using LojaOnlineFLF.DataModel.Models;
using LojaOnlineFLF.DataModel.Providers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace LojaOnlineFLF.Repositories
{
    public static class LojaOnlineFLFRepositories
    {
        public static IServiceCollection AddRepositoriesDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAcessosRepository>(provider => {
                var ctx = provider.GetService<LojaEFContext>();
                var sign = provider.GetService<SignInManager<Acesso>>();
                var user = provider.GetService<UserManager<Acesso>>();
                var acesso = new AcessosRepository(ctx, sign, user);

                return new AcessoAdminRepository(acesso);
            });

            services.AddScoped<IFuncionariosRepository, FuncionariosRepository>();
            services.AddScoped<IProdutosRepository, ProdutosRepository>();
            services.AddScoped<IClientesRepository, ClientesRepository>();
            services.AddScoped<IVendasRepository, VendasRepository>();

            services.AddScoped<ICargos>(provider => {
                var repository = provider.GetService<IFuncionariosRepository>();
                return repository.ObterCargosAsync().GetAwaiter().GetResult();
            });

            return services;
        }
    }
}
