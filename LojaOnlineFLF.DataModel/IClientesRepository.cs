using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LojaOnlineFLF.DataModel.Models;

namespace LojaOnlineFLF.DataModel
{
    public interface IClientesRepository:
        IRepositoryAddBehavior<Cliente>,
        IRepositoryUpdateBehavior<Cliente>,
        IRepositoryGetByIdBehavior<Cliente>,
        IRepositoryRemoveByIdBehavior<Cliente>
    {
    }
}