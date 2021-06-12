using System;
using AutoMapper;
using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.DataModel.Models;

namespace LojaOnlineFLF.WebAPI.Services.Models.Mappers
{
    internal class ProdutoMapperProfile : Profile
    {
        public ProdutoMapperProfile()
        {
            CreateMap<Produto, ProdutoCadastroTO>()
                .ForMember(x => x.CodBarras, opt => opt.MapFrom(o => o.CodigoBarras))
                .ForMember(x => x.Preco, opt => opt.MapFrom(o => o.PrecoVenda))
                .ReverseMap();

            CreateMap<Produto, ProdutoTO>()
                .ForMember(x => x.CodBarras, opt => opt.MapFrom(o => o.CodigoBarras))
                .ForMember(x => x.Preco, opt => opt.MapFrom(o => o.PrecoVenda))
                .ReverseMap();
        }
    }
}
