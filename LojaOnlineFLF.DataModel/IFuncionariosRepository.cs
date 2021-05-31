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
        IRepositoryGetByIdBehavior<Funcionario>,
        IRepositoryRemoveByIdBehavior<Funcionario>
    {        
        Task<Funcionario> ObterPorCpfAsync(string usuario);

        Task<ICargos> ObterCargosAsync();
    }
}
