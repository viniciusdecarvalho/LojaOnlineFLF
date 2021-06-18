using System;
using AutoMapper;
using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.Repositories;

namespace LojaOnlineFLF.Services
{
    internal class MapperService: IMapperService
    {
        private readonly IMapper mapper;

        public MapperService(ICargos cargos)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new FuncionarioMapperProfile(cargos));
                cfg.AddProfile(new ProdutoMapperProfile());
                cfg.AddProfile(new ClienteMapperProfile());
                cfg.AddProfile(new VendaMapperProfile());
            });

            this.mapper = config.CreateMapper();
        }

        public TDestination Convert<TDestination>(object source)
        {
            try
            {
                return this.mapper.Map<TDestination>(source);
            }
            catch(Exception e)
            {
                throw new ServiceException($"falha na conversao entre objetos. [{source?.GetType().Name ?? "null"} -> {typeof(TDestination).Name}]", e);
            }
        }

        public TDestination Merge<TSource, TDestination>(TSource source, TDestination destination)
        {
            try
            {
                return this.mapper.Map(source, destination);
            }
            catch(Exception e)
            {
                throw new ServiceException($"falha na conversao entre objetos. [{typeof(TSource).Name} -> {typeof(TDestination).Name}]", e);
            }
        }
    }
}
