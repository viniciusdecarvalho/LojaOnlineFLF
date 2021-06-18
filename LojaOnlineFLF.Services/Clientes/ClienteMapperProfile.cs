using AutoMapper;
using LojaOnlineFLF.DataModel.Models;

namespace LojaOnlineFLF.Services
{
    internal class ClienteMapperProfile : Profile
    {
        public ClienteMapperProfile()
        {
            CreateMap<DataModel.Models.Cliente, Cliente>()
                .ReverseMap();
        }
    }
}
