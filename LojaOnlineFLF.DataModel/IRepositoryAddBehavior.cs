using System;
using System.Threading.Tasks;

namespace LojaOnlineFLF.DataModel
{
    public interface IRepositoryAddBehavior<T> where T: class
    {
        Task IncluirAsync(T entity);
    }
}
