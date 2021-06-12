using System;
using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.WebAPI.Services.Models;

namespace LojaOnlineFLF.WebAPI.Services.Models
{
    /// <summary>
    /// Parametros para informar novo produto
    /// </summary>
    [ResultName("ProdutoCadastro")]
    public class ProdutoCadastroTO
    {
        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Codigo de Barras
        /// </summary>
        public string CodBarras { get; set; }

        /// <summary>
        /// Preco
        /// </summary>
        public decimal? Preco { get; set; }
    }

    /// <summary>
    /// Produto persistido no sistema
    /// </summary>
    [ResultName("Produto")]
    public class ProdutoTO: ProdutoCadastroTO
    {
        /// <summary>
        /// Identificador
        /// </summary>
        public Guid Id { get; set; }
    }

    /// <summary>
    /// Paginacao de produtos
    /// </summary>
    [ResultName("ProdutosComPaginacao")]
    public class ProdutosComPaginacao : PagedResource<ProdutoTO>
    {
        /// <summary>
        /// Construtor padrao
        /// </summary>
        /// <param name="produtos"></param>
        /// <param name="paginacao"></param>
        /// <param name="resource"></param>
        public ProdutosComPaginacao(IPagedList<ProdutoTO> produtos, Paginacao paginacao, string resource) : base(produtos, paginacao, resource)
        {
        }
    }
}