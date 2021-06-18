using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.Repositories;

namespace LojaOnlineFLF.Services
{
    internal static class PaginacaoExtensions
    {
        public static IPageSet ToPageSet(this IPageParameters paginacao)
        {
            int current = paginacao?.NumeroPagina ?? 1;
            int size = paginacao?.TamanhoPagina ?? 25;

            return PageSet.Create(
                current: current,
                size: size);
        }
    }
}
