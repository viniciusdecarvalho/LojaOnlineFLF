using System;
using AutoMapper;
using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.DataModel.Models;

namespace LojaOnlineFLF.WebAPI.Services.Models.Mappers
{
    public class ClienteMapperProfile : Profile
    {
        public ClienteMapperProfile()
        {
            CreateMap<Cliente, ClienteTO>()
                .ReverseMap();
        }
    }
}
