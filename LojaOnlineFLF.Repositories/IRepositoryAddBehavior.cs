using System;
using System.Threading.Tasks;

namespace LojaOnlineFLF.Repositories
{
    public interface IRepositoryAddBehavior<T> where T: class
    {
        Task IncluirAsync(T entity);
    }
}
