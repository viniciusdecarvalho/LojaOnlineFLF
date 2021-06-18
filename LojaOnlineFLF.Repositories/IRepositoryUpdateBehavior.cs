using System;
using System.Threading.Tasks;

namespace LojaOnlineFLF.Repositories
{
    public interface IRepositoryUpdateBehavior<T> where T: class
    {
        Task AtualizarAsync(T entity);
    }
}
