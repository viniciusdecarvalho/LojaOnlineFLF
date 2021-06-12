using System;
using AutoMapper;
using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.DataModel.Models;

namespace LojaOnlineFLF.WebAPI.Services.Models.Mappers
{
    internal class FuncionarioMapperProfile: Profile
    {
        public FuncionarioMapperProfile(ICargos cargos)
        {
            CreateMap<Funcionario, FuncionarioTO>()
                .ForMember(x => x.Cargo, opt => opt.MapFrom(o => o.Cargo.Nome));

            CreateMap<FuncionarioTO, Funcionario>()
                .ForMember(x => x.Cargo, opt => opt.MapFrom(o => cargos.Of(o.Cargo.ToString())));
        }
    }
}
