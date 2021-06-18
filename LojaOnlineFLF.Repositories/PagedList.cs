using System;
using System.Collections.Generic;
using System.Linq;

namespace LojaOnlineFLF.Repositories
{
    internal class PagedList<T>: IPagedList<T>
    {
        public IEnumerable<T> Items { get; }

        public int Total { get; }

        public int PageNumber { get; }
        
        public int PageSize { get; }

        public int PageCount => (Total / PageSize) + (Total % PageSize == 0 ? 0 : 1);

        public bool HasNextPage => this.PageCount > 0 && this.PageNumber < this.PageCount;

        public bool HasBeforePage => this.PageCount > 0 && this.PageNumber > 1;

        public PagedList(int pageNumber, int pageSize, IEnumerable<T> items, int total)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Items = items;
            this.Total = total;
        }

        public IPagedList<R> Transform<R>(Func<T, R> transformation)
        {
            if (transformation is null)
            {
                throw new ArgumentNullException(nameof(transformation));
            }

            var newList = this.Items.Select(transformation).ToList();

            return 
                new PagedList<R>
                    .Builder()
                    .WithPageNumber(this.PageNumber)
                    .WithPageSize(this.PageSize)
                    .WithTotal(this.Total)
                    .WithItems(newList)
                    .Build();
        }

        public class Builder
        {
            private int pageSize;
            private int pageNumber;
            private int total;
            private IEnumerable<T> items;

            public Builder WithPageSize(int pageSize)
            {
                this.pageSize = pageSize;
                return this;
            }

            public Builder WithPageNumber(int page)
            {
                this.pageNumber = page;
                return this;
            }

            public Builder WithTotal(int total)
            {
                this.total = total;
                return this;
            }

            public Builder WithItems(IEnumerable<T> items)
            {
                this.items = items;
                return this;
            }

            public IPagedList<T> Build()
            {
                return new PagedList<T>(this.pageNumber, this.pageSize, this.items, this.total);
            }
        }
    }
}