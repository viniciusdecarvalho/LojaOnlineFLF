using System.Threading.Tasks;

namespace LojaOnlineFLF.DataModel
{
    public interface IPagedQuery<T>
    {
        public IPagedList<T> ToPagedList();

        public Task<IPagedList<T>> ToPagedListAsync();
    }
}