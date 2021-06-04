using AutoMapper;
using LojaOnlineFLF.DataModel.Models;

namespace LojaOnlineFLF.WebAPI.Services.Models.Mappers
{
    public class VendaMapperProfile : Profile
    {
        public VendaMapperProfile()
        {
            CreateMap<Venda, VendaCadastroTO>()
                .ReverseMap();

            CreateMap<Venda, VendaCadastradaTO>()
                .ReverseMap();

            CreateMap<VendaItem, VendaTO.ItemTO>()
                .ReverseMap();

            CreateMap<Venda, VendaTO>()
                .ForMember(x => x.Situacao, opt => opt.MapFrom(o => o.Situacao.Nome))
                .ReverseMap();
        }
    }
}
