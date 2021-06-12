using LojaOnlineFLF.DataModel;
using System.Collections;
using System.Collections.Generic;

namespace LojaOnlineFLF.WebAPI.Services
{
    /// <summary>
    /// Retorno de recursos com suporte a paginacao
    /// </summary>
    /// <typeparam name="T"></typeparam>    
    public abstract class PagedResource<T>: IPagedResource<T> where T: class
    {
        private readonly IPagedList<T> pagedList;
        private readonly string resource;
        private readonly Paginacao paginacao;

        /// <summary>
        /// Construtor padrao
        /// </summary>
        /// <param name="pagedList"></param>
        /// <param name="paginacao"></param>
        /// <param name="resource"></param>
        public PagedResource(IPagedList<T> pagedList, Paginacao paginacao, string resource)
        {
            this.pagedList = pagedList;
            this.paginacao = paginacao;
            this.resource = resource;
        }

        /// <summary>
        /// Items retornados para a pagina atual
        /// </summary>
        public IEnumerable<T> Items => this.pagedList.Items;

        /// <summary>
        /// Total de items do recurso
        /// </summary>
        public int Total => this.pagedList.Total;

        /// <summary>
        /// Numero da pagina
        /// </summary>
        public int PageNumber => this.pagedList.PageNumber;

        /// <summary>
        /// Tamanho da pagina
        /// </summary>
        public int PageSize => this.pagedList.PageSize;

        /// <summary>
        /// Total de paginas disponiveis para o recurso
        /// </summary>
        public int PageCount => this.pagedList.PageCount;

        /// <summary>
        /// Caminho para a proxima pagina, caso exista
        /// </summary>
        public string NextPage => this.pagedList.HasNextPage ? this.paginacao.NextPage(resource) : null;

        /// <summary>
        /// Caminho para a pagina anterior, caso exista
        /// </summary>
        public string BeforePage => this.pagedList.HasBeforePage ? this.paginacao.BeforePage(resource) : null;
    }
}
