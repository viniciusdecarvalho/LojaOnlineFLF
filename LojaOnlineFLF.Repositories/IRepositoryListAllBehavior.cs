using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaOnlineFLF.Repositories
{
    public interface IRepositoryListAllBehavior<T> where T: class
    {
        Task<IPagedList<T>> ListarTodosAsync(IPageSet page);
    }
}
