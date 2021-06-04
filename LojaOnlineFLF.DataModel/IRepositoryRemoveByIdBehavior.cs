using System;
using System.Threading.Tasks;

namespace LojaOnlineFLF.DataModel
{
    public interface IRepositoryRemoveByIdBehavior<E>
    {
        Task RemoverAsync(E id);
    }
}
