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
        Task RemoverAsync(Guid id);

        ///<summary>
        /// Buscar funcionario por id
        ///</summary>
        Task<FuncionarioTO> ObterPorIdAsync(Guid id);

        ///<summary>
        /// Buscar todos os funcionarios
        ///</summary>
        Task<IEnumerable<FuncionarioTO>> ObterTodosAsync();

        /// <summary>
        /// true para cliente com id informado existir, false caso contrario
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        Task<bool> ContemAsync(Guid id);
    }
}