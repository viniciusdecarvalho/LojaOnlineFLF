using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LojaOnlineFLF.DataModel.Models;

namespace LojaOnlineFLF.DataModel
{
    public interface IVendasRepository :
        IRepositoryAddBehavior<Venda>,
        IRepositoryUpdateBehavior<Venda>,
        IRepositoryGetByIdBehavior<Venda>,
        IRepositoryRemoveByIdBehavior<Venda>
    {
        Task<IEnumerable<Venda>> ObterPorClienteAsync(Guid id);

        Task<IEnumerable<Venda>> ObterPorFuncionarioIdAsync(Guid id);

        Task<IEnumerable<Venda>> ObterTodasEmAbertoAsync();

        Task<Venda> IncluirItem(Guid id, VendaItem item);

        Task<Venda> RemoverItem(Guid id, VendaItem item);

        Task<Venda> ReabrirAsync(Guid id);

        Task<Venda> CancelarAsync(Guid id);

        Task<Venda> ConcluirAsync(Guid id);
    }
}