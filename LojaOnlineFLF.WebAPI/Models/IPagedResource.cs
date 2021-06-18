using System.Collections.Generic;

namespace LojaOnlineFLF.WebAPI.Models
{
    /// <summary>
    /// Retorno de recursos com suporte a paginacao
    /// </summary>
    /// <typeparam name="T"></typeparam>    
    public interface IPagedResource<T>
    {
        /// <summary>
        /// Items retornados para a pagina atual
        /// </summary>
        IEnumerable<T> Items { get; }

        /// <summary>
        /// Total de items do recurso
        /// </summary>
        public int Total { get; }

        /// <summary>
        /// Numero da pagina
        /// </summary>
        public int PageNumber { get; }

        /// <summary>
        /// Tamanho da pagina
        /// </summary>
        public int PageSize { get; }

        /// <summary>
        /// Total de paginas disponiveis para o recurso
        /// </summary>
        public int PageCount { get; }

        /// <summary>
        /// Caminho para a proxima pagina, caso exista
        /// </summary>
        public string NextPage { get; }

        /// <summary>
        /// Caminho para a pagina anterior, caso exista
        /// </summary>
        public string BeforePage { get; }
    }
}
