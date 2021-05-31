using System;
using System.Threading.Tasks;

namespace LojaOnlineFLF.DataModel
{
    public interface IRepositoryRemoveByIdBehavior<T> where T: class
    {
        Task RemoverAsync(Guid id);
    }
}
