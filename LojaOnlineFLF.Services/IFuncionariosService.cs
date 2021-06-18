using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.Repositories;
using System;
using System.Threading.Tasks;

namespace LojaOnlineFLF.Services
{
    ///<summary>
    /// servicos de funcionarios
    ///</summary>
    public interface IFuncionariosService : IService
    {
        ///<summary>
        /// Adicionar novo funcionario
        ///</summary>
        Task<Funcionario> AdicionarAsync(FuncionarioCadastro funcionario);

        ///<summary>
        /// Adicionar novo funcionario
        ///</summary>
        Task AtualizarAsync(Funcionario funcionario);

        ///<summary>
        /// Adicionar novo funcionario
        ///</summary>
        Task RemoverAsync(Guid id);

        ///<summary>
        /// Buscar funcionario por id
        ///</summary>
        Task<Funcionario> ObterPorIdAsync(Guid id);

        ///<summary>
        /// Buscar todos os funcionarios
        ///</summary>
        Task<IPagedList<Funcionario>> ObterTodosAsync(IPageParameters paginacao);

        /// <summary>
        /// true para cliente com id informado existir, false caso contrario
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        Task<bool> ContemAsync(Guid id);
    }
}