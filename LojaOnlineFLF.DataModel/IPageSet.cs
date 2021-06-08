namespace LojaOnlineFLF.DataModel
{
    public interface IPageSet
    {
        int Current { get; }

        int PageSize { get; }
    }
}