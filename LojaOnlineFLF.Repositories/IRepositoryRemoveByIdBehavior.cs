using System;
using System.Threading.Tasks;

namespace LojaOnlineFLF.Repositories
{
    public interface IRepositoryRemoveByIdBehavior<E>
    {
        Task RemoverAsync(E id);
    }
}
