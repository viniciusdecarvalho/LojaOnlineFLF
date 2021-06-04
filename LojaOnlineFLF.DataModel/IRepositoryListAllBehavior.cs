using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaOnlineFLF.DataModel
{
    public interface IRepositoryListAllBehavior<T> where T: class
    {
        Task<IEnumerable<T>> ListarTodosAsync();
    }
}
