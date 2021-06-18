using System.Threading.Tasks;

namespace LojaOnlineFLF.Repositories
{
    public interface IPagedQuery<T>
    {
        IPagedQuery<T> WithPageSize(int pageSize);

        IPagedQuery<T> WithPageResult(int pageNumber);

        IPagedList<T> ToPagedList();

        Task<IPagedList<T>> ToPagedListAsync();
    }
}