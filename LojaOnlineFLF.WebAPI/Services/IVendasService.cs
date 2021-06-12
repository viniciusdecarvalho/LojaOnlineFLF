using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LojaOnlineFLF.WebAPI.Services.Models;

namespace LojaOnlineFLF.WebAPI.Services
{
    /// <summary>
    /// Operacoes de vendas
    /// </summary>
    public interface IVendasService
    {
        /// <summary>
        /// Recuperar venda por id
        /// </summary>
        /// <param name="vendaId"></param>
        /// <returns></returns>
        Task<VendaTO> ObterPorIdAsync(Guid vendaId);

        /// <summary>
        /// Recuperar vendas de um cpf de cliente
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        Task<IEnumerable<VendaTO>> ObterPorCpfClienteAsync(string cpf);

        /// <summary>
        /// Alterar itens da venda
        /// </summary>
        /// <param name="id"></param>
        /// <param name="itens"></param>
        /// <returns></returns>
        Task<VendaTO> AlterarItensAsync(Guid id, params VendaItemTO[] itens);

        /// <summary>
        /// Cancelar venda, alterar situacao da venda para cancelado. Nao é possivel alterar itens da venda
        /// </summary>
        /// <param name="venda"></param>
        /// <returns></returns>
        Task CancelarVendaAsync(VendaTO venda);

        /// <summary>
        /// Concluir venda, alterar situação da venda para concluido. Nao é possivel alterar itens da venda
        /// </summary>
        /// <param name="venda"></param>
        /// <returns></returns>
        Task ConcluirVendaAsync(VendaTO venda);

        /// <summary>
        /// Iniciar nova venda
        /// </summary>
        /// <param name="venda"></param>
        /// <returns></returns>
        Task<VendaTO> AdicionarAsync(VendaCadastroTO venda);

        /// <summary>
        /// Reabrir venda, voltar situacao da venda para aberto, perimite alterar itens
        /// </summary>
        /// <param name="venda"></param>
        /// <returns></returns>
        Task<VendaTO> ReabrirVendaAsync(VendaTO venda);

        /// <summary>
        /// Remover venda, somente enquando estiver em com situacao em aberto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task RemoverVendaAsync(Guid id);

        /// <summary>
        /// Verificar se venda existe por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> ContemAsync(Guid id);

        /// <summary>
        /// Alterar dados da venda
        /// </summary>
        /// <param name="venda"></param>
        /// <returns></returns>
        Task<VendaTO> AlterarVendaAsync(VendaCadastradaTO venda);

        /// <summary>
        /// Recuperar venda para data informada
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<IEnumerable<VendaTO>> ObterVendasPorData(DateTime data);
    }
}