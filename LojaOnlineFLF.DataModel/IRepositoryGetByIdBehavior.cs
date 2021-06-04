using System;
using System.Threading.Tasks;

namespace LojaOnlineFLF.DataModel
{
    public interface IRepositoryGetByIdBehavior<T, E> where T: EntityKey<E>
    {
        Task<T> ObterAsync(E id);

        Task<bool> ContemAsync(E id);
    }
}
