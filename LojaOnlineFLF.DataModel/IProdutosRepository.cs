using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LojaOnlineFLF.DataModel.Models;

namespace LojaOnlineFLF.DataModel
{
    public interface IProdutosRepository:
        IRepositoryAddBehavior<Produto>,
        IRepositoryUpdateBehavior<Produto>,
        IRepositoryListAllBehavior<Produto>,
        IRepositoryGetByIdBehavior<Produto, Guid>,
        IRepositoryRemoveByIdBehavior<Guid>
    {
        Task<Produto> ObterPorCodigoDeBarrasAsync(string codigoBarras);

        Task<bool> ContemCodigoBarrasAsync(string codigoBarras);
    }
}