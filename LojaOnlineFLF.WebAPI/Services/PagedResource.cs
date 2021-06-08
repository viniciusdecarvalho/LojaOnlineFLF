using System;
using System.Collections.Generic;
using LojaOnlineFLF.DataModel;

namespace LojaOnlineFLF.WebAPI.Services
{
    public class PagedResource<T> where T: class
    {
        private readonly IPagedList<T> pagedList;
        private readonly string resource;
        private readonly Paginacao paginacao;

        public PagedResource(IPagedList<T> pagedList, Paginacao paginacao, string resource)
        {
            this.pagedList = pagedList;
            this.paginacao = paginacao;
            this.resource = resource;
        }

        public IEnumerable<T> Items => this.pagedList.Items;

        public int Total => this.pagedList.Total;

        public int PageNumber => this.pagedList.PageNumber;

        public int PageSize => this.pagedList.PageSize;

        public int PageCount => this.pagedList.PageCount;

        public string NextPage => this.pagedList.HasNextPage ? this.paginacao.NextPage(resource) : null;

        public string BeforePage => this.pagedList.HasBeforePage ? this.paginacao.BeforePage(resource) : null;
    }
}
