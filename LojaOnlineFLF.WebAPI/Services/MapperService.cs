using System;
using AutoMapper;

namespace LojaOnlineFLF.WebAPI.Services
{
    public class MapperService: IMapperService
    {
        private readonly IMapper mapper;

        public MapperService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public TDestination Map<TDestination>(object source)
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

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
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
