using System;
using System.Threading.Tasks;
using LojaOnlineFLF.DataModel;

namespace LojaOnlineFLF.Repositories
{
    public interface IRepositoryGetByIdBehavior<T, E> where T: EntityKey<E>
    {
        Task<T> ObterAsync(E id);

        Task<bool> ContemAsync(E id);
    }
}
