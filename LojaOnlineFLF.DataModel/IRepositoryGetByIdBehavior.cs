using System;
using System.Threading.Tasks;

namespace LojaOnlineFLF.DataModel
{
    public interface IRepositoryGetByIdBehavior<T> where T: class
    {
        Task<T> ObterAsync(Guid id);
    }
}
