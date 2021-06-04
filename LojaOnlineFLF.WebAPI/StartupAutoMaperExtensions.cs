using AutoMapper;
using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.WebAPI.Services.Models.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace LojaOnlineFLF.WebAPI
{
    public static class StartupAutoMaperExtensions
    {
        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {           
            services.AddScoped<IMapper>(factory => {
                var cargos = factory.GetService<ICargos>();

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new FuncionarioMapperProfile(cargos));
                    cfg.AddProfile(new ProdutoMapperProfile());
                    cfg.AddProfile(new ClienteMapperProfile());
                    cfg.AddProfile(new VendaMapperProfile());
                });

                IMapper mapper = config.CreateMapper();

                return mapper;
            }); 

            return services;
        }
    }
}
