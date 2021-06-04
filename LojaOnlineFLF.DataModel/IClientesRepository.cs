using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LojaOnlineFLF.DataModel.Models;

namespace LojaOnlineFLF.DataModel
{
    public interface IClientesRepository :
        IRepositoryAddBehavior<Cliente>,
        IRepositoryUpdateBehavior<Cliente>,
        IRepositoryGetByIdBehavior<Cliente, Guid>,
        IRepositoryRemoveByIdBehavior<Guid>
    {
        Task<IEnumerable<Cliente>> ObterPorCpfAsync(string cpf);        
    }
}