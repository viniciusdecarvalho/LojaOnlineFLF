using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LojaOnlineFLF.WebAPI.Services.Models;

namespace LojaOnlineFLF.WebAPI.Services
{
    public interface IVendasService
    {
        Task<VendaTO> ObterPorIdAsync(Guid vendaId);

        Task<IEnumerable<VendaTO>> ObterPorCpfClienteAsync(string cpf);

        Task<VendaTO> AlterarItemAsync(VendaTO venda, ProdutoTO produto, int? quantidade);

        Task CancelarVendaAsync(VendaTO venda);

        Task ConcluirVendaAsync(VendaTO venda);

        Task<VendaTO> AdicionarAsync(VendaCadastroTO venda);

        Task<VendaTO> ReabrirVendaAsync(VendaTO venda);

        Task RemoverVendaAsync(Guid id);

        Task<bool> ContemAsync(Guid id);

        Task<VendaTO> AlterarVendaAsync(VendaCadastradaTO venda);
    }
}