namespace LojaOnlineFLF.Repositories
{
    public class PageSet: IPageSet
    {
        public int Current { get; set; } = 1;

        public int PageSize { get; set; } = 25;

        private PageSet() { }

        public static IPageSet Create(int current, int size)
        {
            return new PageSet { Current = current, PageSize = size };
        }
    }
}