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

        Task<ProdutoTO> ObterPorCodigoBarrasAsync(string codigoBarras);

        Task<ProdutoTO> AdicionarAsync(ProdutoCadastroTO produto);

        Task AtualizarAsync(ProdutoTO produto);

        Task RemoverAsync(Guid id);

        Task<bool> ContemAsync(Guid id);

        Task<bool> ContemCodigoBarrasAsync(string codigoBarras);
    }
}