using System;
using AutoMapper;
using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.DataModel.Models;
using LojaOnlineFLF.Repositories;

namespace LojaOnlineFLF.Services
{
    internal class FuncionarioMapperProfile: Profile
    {
        public FuncionarioMapperProfile(ICargos cargos)
        {
            CreateMap<DataModel.Models.Funcionario, Funcionario>()
                .ForMember(x => x.Cargo, opt => opt.MapFrom(o => o.Cargo.Nome));

            CreateMap<Funcionario, DataModel.Models.Funcionario>()
                .ForMember(x => x.Cargo, opt => opt.MapFrom(o => cargos.Of(o.Cargo.ToString())));
        }
    }
}
