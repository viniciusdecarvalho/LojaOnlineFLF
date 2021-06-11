using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LojaOnlineFLF.DataModel
{
    internal static class PagedQueryableExtensions
    {
        public static IPagedQuery<T> WithPageSet<T>(this IQueryable<T> source, IPageSet page)
        {
            return new PagedQuery<T>(source, page);
        }

        public static IPagedQuery<T> WithPageSet<T>(this IQueryable<T> source, int pageNumber = 1, int pageSize = 25)
        {
            return new PagedQuery<T>(source, pageNumber, pageSize);
        }
    }
}