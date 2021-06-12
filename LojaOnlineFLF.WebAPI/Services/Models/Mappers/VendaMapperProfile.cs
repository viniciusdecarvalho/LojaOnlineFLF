using AutoMapper;
using LojaOnlineFLF.DataModel.Models;

namespace LojaOnlineFLF.WebAPI.Services.Models.Mappers
{
    internal class VendaMapperProfile : Profile
    {
        public VendaMapperProfile()
        {
            CreateMap<Cliente, VendaClienteTO>()
                .ReverseMap();

            CreateMap<Venda, VendaCadastroTO>()
                .ReverseMap();

            CreateMap<Venda, VendaCadastradaTO>()
                .ReverseMap();

            CreateMap<Venda, VendaTO>()
                .ForMember(x => x.Situacao, opt => opt.MapFrom(o => o.Situacao.Nome))
                .ReverseMap();

            CreateMap<VendaItem, VendaTO.ItemTO>()
                .ReverseMap();
        }
    }
}
