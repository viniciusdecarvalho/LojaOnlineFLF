namespace LojaOnlineFLF.DataModel
{
    public sealed class PageSet: IPageSet
    {
        public int Current { get; set; }

        public int PageSize { get; set; } = 10;

        private PageSet() { }

        public static IPageSet Create(int current, int size)
        {
            return new PageSet { Current = current, PageSize = size };
        }
    }
}