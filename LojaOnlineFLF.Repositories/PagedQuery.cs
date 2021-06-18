using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LojaOnlineFLF.Repositories
{
    internal class PagedQuery<T>: IPagedQuery<T>
    {
        private readonly IQueryable<T> source;
        private int pageIndex;
        private int pageSize;
        private int startIndex;

        public PagedQuery(IQueryable<T> source, int pageIndex, int pageSize)
        {
            this.source = source;
            this.pageIndex = pageIndex;            
            this.pageSize = pageSize;

            this.startIndex = (pageIndex - 1) * pageSize;
        }

        public PagedQuery(IQueryable<T> source, IPageSet pageSet)
            : this(source, pageSet.Current, pageSet.PageSize) { }

        public IPagedList<T> ToPagedList()
        {
            var items = this.source.Skip(startIndex).Take(pageSize).ToList();

            var total = this.source.Count();

            return Create(items, total);
        }

        private IPagedList<T> Create(List<T> items, int total)
        {
            var pagedList =
                new PagedList<T>.Builder()
                    .WithPageNumber(pageIndex)
                    .WithPageSize(pageSize)
                    .WithTotal(total)
                    .WithItems(items)
                    .Build();

            return pagedList;
        }

        public async Task<IPagedList<T>> ToPagedListAsync()
        {
            var items = await this.source.Skip(startIndex).Take(pageSize).ToListAsync();

            var total = await this.source.CountAsync();

            return Create(items, total);
        }

        public IPagedQuery<T> WithPageSize(int pageSize)
        {
            if (pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize), "deve ser maior que zero.");
            }

            this.pageSize = pageSize;

            return this;
        }

        public IPagedQuery<T> WithPageResult(int pageNumber)
        {
            if (pageNumber <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize), "deve ser maior que zero.");
            }

            this.pageIndex = pageNumber;

            return this;
        }
    }
}