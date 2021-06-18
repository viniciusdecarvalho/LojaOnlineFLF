using System;
using System.Threading.Tasks;

namespace LojaOnlineFLF.Repositories
{
    public interface IRepositoryPossuiVendaBehavior<T> where T: class
    {
        Task<bool> PossuiVendas(T entity);
    }
}
