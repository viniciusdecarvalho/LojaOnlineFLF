using System;
using AutoMapper;
using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.WebAPI.Services.Models;
using Microsoft.Extensions.DependencyInjection;

namespace LojaOnlineFLF.WebAPI
{
    public static class StartupAutoMaperExtensions
    {
        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {           
            services.AddTransient<IMapper>(factory => {
                var cargos = factory.GetService<ICargos>();

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new FuncionarioMapperProfile(cargos));
                });

                IMapper mapper = config.CreateMapper();

                return mapper;
            }); 

            return services;
        }
    }
}
