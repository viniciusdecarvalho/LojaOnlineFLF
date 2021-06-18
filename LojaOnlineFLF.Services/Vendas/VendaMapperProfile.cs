using AutoMapper;
using LojaOnlineFLF.DataModel.Models;

namespace LojaOnlineFLF.Services
{
    internal class VendaMapperProfile : Profile
    {
        public VendaMapperProfile()
        {
            CreateMap<DataModel.Models.Cliente, VendaCliente>()
                .ReverseMap();

            CreateMap<DataModel.Models.Venda, VendaCadastro>()
                .ReverseMap();

            CreateMap<DataModel.Models.Venda, VendaCadastrada>()
                .ReverseMap();

            CreateMap<DataModel.Models.Venda, Venda>()
                .ForMember(x => x.Situacao, opt => opt.MapFrom(o => o.Situacao.Nome))
                .ReverseMap();

            CreateMap<DataModel.Models.VendaItem, Venda.ItemTO>()
                .ReverseMap();
        }
    }
}
