using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LojaOnlineFLF.WebAPI.Services.Models;

namespace LojaOnlineFLF.WebAPI.Services
{
    ///<summary>
    /// servicos de funcionarios
    ///</summary>
    public interface IFuncionariosService
    {
        ///<summary>
        /// Adicionar novo funcionario
        ///</summary>
        Task<FuncionarioTO> AdicionarAsync(FuncionarioTO funcionario);

        ///<summary>
        /// Adicionar novo funcionario
        ///</summary>
        Task AtualizarAsync(FuncionarioTO funcionario);

        ///<summary>
        /// Adicionar novo funcionario
        ///</summary>
        Task RemoverAsync(FuncionarioTO funcionario);

        ///<summary>
        /// Buscar funcionario por id
        ///</summary>
        Task<FuncionarioTO> ObterPorIdAsync(Guid id);

        ///<summary>
        /// Buscar todos os funcionarios
        ///</summary>
        Task<IEnumerable<FuncionarioTO>> ObterTodosAsync();
    }
}