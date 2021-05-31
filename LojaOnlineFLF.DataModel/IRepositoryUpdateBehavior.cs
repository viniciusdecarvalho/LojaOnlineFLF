using System;
using System.Threading.Tasks;

namespace LojaOnlineFLF.DataModel
{
    public interface IRepositoryUpdateBehavior<T> where T: class
    {
        Task AtualizarAsync(T entity);
    }
}
