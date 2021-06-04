using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LojaOnlineFLF.DataModel.Models;

namespace LojaOnlineFLF.DataModel
{
    public interface IFuncionariosRepository:
        IRepositoryAddBehavior<Funcionario>,
        IRepositoryUpdateBehavior<Funcionario>,
        IRepositoryListAllBehavior<Funcionario>,
        IRepositoryGetByIdBehavior<Funcionario, Guid>,
        IRepositoryRemoveByIdBehavior<Guid>
    {        
        Task<Funcionario> ObterPorCpfAsync(string usuario);

        Task<ICargos> ObterCargosAsync();
    }
}
