using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LojaOnlineFLF.DataModel.Models;

namespace LojaOnlineFLF.Repositories
{
    public interface IClientesRepository :
        IRepositoryAddBehavior<Cliente>,
        IRepositoryUpdateBehavior<Cliente>,
        IRepositoryGetByIdBehavior<Cliente, Guid>,
        IRepositoryRemoveByIdBehavior<Guid>
    {
        Task<Cliente> ObterPorCpfAsync(string cpf);

        Task<Cliente> ObterPorFoneAsync(string fone);
    }
}