using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaOnlineFLF.DataModel.Models;
using LojaOnlineFLF.DataModel.Providers;
using Microsoft.EntityFrameworkCore;

namespace LojaOnlineFLF.DataModel.Repositories
{
    public class VendasRepository: IVendasRepository
    {
        private readonly LojaEFContext context;

        public VendasRepository(LojaEFContext context)
        {
            this.context = context;
        }

        public async Task AtualizarAsync(Venda entity)
        {
            await Task.FromResult(
                this.context.Set<Venda>().Update(entity));
        }

        public async Task<Venda> CancelarAsync(Guid id)
        {
            var venda = await this.ObterAsync(id);
            ChecarVenda(venda);

            venda.Cancelar();

            await this.AtualizarAsync(venda);

            return venda;
        }

        public async Task<Venda> ConcluirAsync(Guid id)
        {
            var venda = await this.ObterAsync(id);
            ChecarVenda(venda);

            venda.Concluir();

            await this.AtualizarAsync(venda);

            return venda;
        }

        private static void ChecarVenda(Venda venda)
        {
            if (venda is null)
            {
                throw new InvalidOperationException("registro de venda nao encontrado");
            }
        }

        public async Task<Venda> ReabrirAsync(Guid id)
        {
            var venda = await this.ObterAsync(id);
            ChecarVenda(venda);

            venda.Abrir();

            await this.AtualizarAsync(venda);

            return venda;
        }

        public async Task IncluirAsync(Venda entity)
        {
            await this.context.Set<Venda>().AddAsync(entity);
        }

        public async Task<Venda> IncluirItem(Guid id, VendaItem item)
        {
            ChecarItemVenda(item);
            var venda = await this.ObterAsync(id);
            ChecarVenda(venda);

            venda.Itens.Add(item);

            await this.AtualizarAsync(venda);

            return venda;
        }

        public async Task<Venda> RemoverItem(Guid id, VendaItem item)
        {
            throw new NotImplementedException();
        }

        private static void ChecarItemVenda(VendaItem item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }
        }

        public async Task<Venda> ObterAsync(Guid id)
        {
            return await this.context.Set<Venda>().FindAsync(id);
        }

        public async Task<IEnumerable<Venda>> ObterPorClienteAsync(Guid id)
        {
            var vendas =
                await this.context.Vendas
                        .Include(v => v.Cliente)
                        .Include(v => v.Funcionario)
                        .Where(v => v.Cliente.Id.Equals(id))
                        .AsNoTracking()
                        .ToListAsync();

            return vendas;
        }

        public async Task<IEnumerable<Venda>> ObterPorFuncionarioIdAsync(Guid id)
        {
            var vendas =
                await this.context.Vendas
                        .Include(v => v.Cliente)
                        .Include(v => v.Funcionario)
                        .Where(v => v.Funcionario.Id.Equals(id))
                        .AsNoTracking()
                        .ToListAsync();

            return vendas;
        }

        public async Task<IEnumerable<Venda>> ObterTodasEmAbertoAsync()
        {
            var vendas =
                await this.context.Vendas
                        .Include(v => v.Cliente)
                        .Include(v => v.Funcionario)
                        .Where(v => v.Situacao.Codigo == VendaSituacao.Aberta.Codigo)
                        .AsNoTracking()
                        .ToListAsync();

            return vendas;
        }        

        public async Task RemoverAsync(Guid id)
        {
            var venda = await this.ObterAsync(id);
            ChecarVenda(venda);

            if (!venda.PodeExcluir())
            {
                throw new InvalidOperationException("venda nao pode ser excluida");
            }

            this.context.Set<Venda>().Remove(venda);
        }
    }
}
