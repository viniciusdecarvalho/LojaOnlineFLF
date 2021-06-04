using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LojaOnlineFLF.DataModel.Models;

namespace LojaOnlineFLF.DataModel
{
    public interface IVendasRepository :
        IRepositoryAddBehavior<Venda>,
        IRepositoryUpdateBehavior<Venda>,
        IRepositoryGetByIdBehavior<Venda, Guid>,
        IRepositoryRemoveByIdBehavior<Guid>
    {
        Task<IEnumerable<Venda>> ObterPorCpfClienteAsync(string cpf);

        Task<IEnumerable<Venda>> ObterPorFuncionarioIdAsync(Guid id);

        Task<IEnumerable<Venda>> ObterTodasEmAbertoAsync();

        Task<IEnumerable<Venda>> ObterTodasPorDataAsync(DateTime data);

        Task<Venda> AlterarItemAsync(Guid id, VendaItem item);

        Task<Venda> ReabrirAsync(Guid id);

        Task<Venda> CancelarAsync(Guid id);

        Task<Venda> ConcluirAsync(Guid id);

        Task<VendaItem> CriarVendaItemAsync(Guid produtoId, int? quantidade);
    }
}