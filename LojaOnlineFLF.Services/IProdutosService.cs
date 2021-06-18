using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.Repositories;
using System;
using System.Threading.Tasks;

namespace LojaOnlineFLF.Services
{
    /// <summary>
    /// Operacoes para manter produtos
    /// </summary>
    public interface IProdutosService : IService
    {
        /// <summary>
        /// Recuperar todos os produtos de determinada paginacao
        /// </summary>
        /// <param name="paginacao"></param>
        /// <returns>Produtos da pagina informada</returns>
        Task<IPagedList<Produto>> ObterTodosAsync(IPageParameters paginacao);

        /// <summary>
        /// Recuperar produto por id
        /// </summary>
        /// <param name="id">Identificador do produto</param>
        /// <returns>Produto</returns>
        Task<Produto> ObterPorIdAsync(Guid id);

        /// <summary>
        /// Recuperar produto por codigo de barras
        /// </summary>
        /// <param name="codigoBarras"></param>
        /// <returns></returns>
        Task<Produto> ObterPorCodigoBarrasAsync(string codigoBarras);

        /// <summary>
        /// Adicionar novo produto
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        Task<Produto> AdicionarAsync(ProdutoCadastro produto);

        /// <summary>
        /// Atualizar produto
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        Task AtualizarAsync(Produto produto);

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