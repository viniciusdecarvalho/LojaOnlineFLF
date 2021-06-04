using System;
using System.Threading.Tasks;

namespace LojaOnlineFLF.DataModel
{
    public interface IRepositoryPossuiVendaBehavior<T> where T: class
    {
        Task<bool> PossuiVendas(T entity);
    }
}
