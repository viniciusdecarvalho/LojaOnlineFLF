using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using LojaOnlineFLF.DataModel.Models;

namespace LojaOnlineFLF.WebAPI.Services
{
    public interface IMapperService
    {
        TDestination Map<TDestination>(object source);

        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}
