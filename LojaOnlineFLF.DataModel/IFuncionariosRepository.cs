using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LojaOnlineFLF.DataModel.Models;

namespace LojaOnlineFLF.DataModel
{
    public interface IFuncionariosRepository
    {
        Task IncluirAsync(Funcionario funcionario);

        Task AtualizarAsync(Funcionario funcionario);

        Task RemoverAsync(Guid id);

        Task<IEnumerable<Funcionario>> ListarAsync();

        Task<Funcionario> ObterAsync(Guid id);

        Task<Funcionario> ObterPorCpfAsync(string usuario);

        Task<ICargos> ObterCargosAsync();
    }
}
