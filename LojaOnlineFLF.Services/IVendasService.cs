using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaOnlineFLF.Services
{
    /// <summary>
    /// Operacoes de vendas
    /// </summary>
    public interface IVendasService : IService
    {
        /// <summary>
        /// Recuperar venda por id
        /// </summary>
        /// <param name="vendaId"></param>
        /// <returns></returns>
        Task<Venda> ObterPorIdAsync(Guid vendaId);

        /// <summary>
        /// Recuperar vendas de um cpf de cliente
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        Task<IEnumerable<Venda>> ObterPorCpfClienteAsync(string cpf);

        /// <summary>
        /// Alterar itens da venda
        /// </summary>
        /// <param name="id"></param>
        /// <param name="itens"></param>
        /// <returns></returns>
        Task<Venda> AlterarItensAsync(Guid id, params VendaItem[] itens);

        /// <summary>
        /// Cancelar venda, alterar situacao da venda para cancelado. Nao é possivel alterar itens da venda
        /// </summary>
        /// <param name="venda"></param>
        /// <returns></returns>
        Task CancelarVendaAsync(Venda venda);

        /// <summary>
        /// Concluir venda, alterar situação da venda para concluido. Nao é possivel alterar itens da venda
        /// </summary>
        /// <param name="venda"></param>
        /// <returns></returns>
        Task ConcluirVendaAsync(Venda venda);

        /// <summary>
        /// Iniciar nova venda
        /// </summary>
        /// <param name="venda"></param>
        /// <returns></returns>
        Task<Venda> AdicionarAsync(VendaCadastro venda);

        /// <summary>
        /// Reabrir venda, voltar situacao da venda para aberto, perimite alterar itens
        /// </summary>
        /// <param name="venda"></param>
        /// <returns></returns>
        Task<Venda> ReabrirVendaAsync(Venda venda);

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
        Task<Venda> AlterarVendaAsync(VendaCadastrada venda);

        /// <summary>
        /// Recuperar venda para data informada
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<IEnumerable<Venda>> ObterVendasPorData(DateTime data);
    }
}