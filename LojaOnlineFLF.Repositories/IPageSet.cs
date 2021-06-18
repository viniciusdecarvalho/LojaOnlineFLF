namespace LojaOnlineFLF.Repositories
{
    public interface IPageSet
    {
        int Current { get; }

        int PageSize { get; }
    }
}