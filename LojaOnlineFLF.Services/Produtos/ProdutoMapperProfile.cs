using System;
using AutoMapper;
using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.DataModel.Models;

namespace LojaOnlineFLF.Services
{
    internal class ProdutoMapperProfile : Profile
    {
        public ProdutoMapperProfile()
        {
            CreateMap<DataModel.Models.Produto, ProdutoCadastro>()
                .ForMember(x => x.CodBarras, opt => opt.MapFrom(o => o.CodigoBarras))
                .ForMember(x => x.Preco, opt => opt.MapFrom(o => o.PrecoVenda))
                .ReverseMap();

            CreateMap<DataModel.Models.Produto, Produto>()
                .ForMember(x => x.CodBarras, opt => opt.MapFrom(o => o.CodigoBarras))
                .ForMember(x => x.Preco, opt => opt.MapFrom(o => o.PrecoVenda))
                .ReverseMap();
        }
    }
}
