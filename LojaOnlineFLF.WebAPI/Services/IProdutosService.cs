using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LojaOnlineFLF.WebAPI.Services.Models;

namespace LojaOnlineFLF.WebAPI.Services
{
    public interface IProdutosService
    {
        Task<IEnumerable<ProdutoTO>> ObterTodosAsync();

        Task<ProdutoTO> ObterPorIdAsync(Guid id);

        Task<ProdutoTO> AdicionarAsync(ProdutoTO produto);

        Task AtualizarAsync(ProdutoTO produto);

        Task RemoverAsync(ProdutoTO produto);

        Task<bool> ContemAsync(Guid id);
    }
}