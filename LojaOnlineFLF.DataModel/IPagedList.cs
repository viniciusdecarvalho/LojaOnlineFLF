using System;
using System.Collections.Generic;

namespace LojaOnlineFLF.DataModel
{
    public interface IPagedList<T>
    {
        IEnumerable<T> Items { get; }

        int Total { get; }

        int PageNumber { get; }

        int PageSize { get; }

        int PageCount { get; }

        bool HasNextPage { get; }

        bool HasBeforePage { get; }

        IPagedList<R> Transform<R>(Func<T, R> transformation);
    }
}