using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.WebAPI.Services.Models;

namespace LojaOnlineFLF.WebAPI.Services
{
    /// <summary>
    /// Operacoes para manter produtos
    /// </summary>
    public interface IProdutosService
    {
        /// <summary>
        /// Recuperar todos os produtos de determinada paginacao
        /// </summary>
        /// <param name="paginacao"></param>
        /// <returns>Produtos da pagina informada</returns>
        Task<IPagedList<ProdutoTO>> ObterTodosAsync(Paginacao paginacao);

        /// <summary>
        /// Recuperar produto por id
        /// </summary>
        /// <param name="id">Identificador do produto</param>
        /// <returns>Produto</returns>
        Task<ProdutoTO> ObterPorIdAsync(Guid id);

        /// <summary>
        /// Recuperar produto por codigo de barras
        /// </summary>
        /// <param name="codigoBarras"></param>
        /// <returns></returns>
        Task<ProdutoTO> ObterPorCodigoBarrasAsync(string codigoBarras);

        /// <summary>
        /// Adicionar novo produto
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        Task<ProdutoTO> AdicionarAsync(ProdutoCadastroTO produto);

        /// <summary>
        /// Atualizar produto
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        Task AtualizarAsync(ProdutoTO produto);

        /// <summary>
        /// REmover produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task RemoverAsync(Guid id);

        /// <summary>
        /// Verificar se existe produto com id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> ContemAsync(Guid id);

        /// <summary>
        /// Verificar se existe produto com id
        /// </summary>
        /// <param name="codigoBarras"></param>
        /// <returns></returns>
        Task<bool> ContemCodigoBarrasAsync(string codigoBarras);
    }
}