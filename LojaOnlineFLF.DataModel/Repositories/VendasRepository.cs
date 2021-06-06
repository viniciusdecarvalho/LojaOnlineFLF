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
        private RepositoryEF<Venda, Guid> vendas;

        public VendasRepository(LojaEFContext context)
        {
            this.vendas = new RepositoryEF<Venda, Guid>(context);
        }

        public async Task AtualizarAsync(Venda venda)
        {
            await this.vendas.AtualizarAsync(venda);
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

            if (!venda.Itens.Any())
            {
                throw new InvalidOperationException("venda nao possui itens");
            }

            venda.Concluir();

            await this.AtualizarAsync(venda);

            return venda;
        }

        public async Task<Venda> ReabrirAsync(Guid id)
        {
            var venda = await this.ObterAsync(id);
            ChecarVenda(venda);

            venda.Abrir();

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

        public async Task IncluirAsync(Venda venda)
        {            
            await this.vendas.IncluirAsync(venda);
        }

        public async Task<Venda> AlterarItemAsync(Guid id, VendaItem item)
        {
            ChecarItemVenda(item);
            var venda = await this.ObterAsync(id);
            ChecarVenda(venda);

            this.AlterarItem(venda, item);

            return venda;
        }

        internal void AlterarItem(Venda venda, VendaItem item)
        {
            var itens = venda.Itens.Where(i => i.Produto.Id.Equals(item.Produto.Id)).ToList();

            foreach (var it in itens)
            {
                it.Venda = null;
                venda.Itens.Remove(it);

                this.vendas.Context.Entry(it).State = EntityState.Deleted;
            }

            if (item.Quantidade > 0)
            {
                item.Venda = venda;
                venda.Itens.Add(item);

                this.vendas.Context.Entry(item).State = EntityState.Added;
            }
        }

        private void ChecarItemVenda(VendaItem item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item), "item nao informado");
            }
        }

        public async Task<Venda> ObterAsync(Guid id)
        {
            return await
                this.vendas.Query
                    .Include(v => v.Cliente)
                    .Include(v => v.Funcionario)
                    .Include(v => v.Itens).ThenInclude(i=> i.Produto)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<IEnumerable<Venda>> ObterPorCpfClienteAsync(string cpf)
        {
            var vendas =
                await this.vendas.Query
                        .Include(v => v.Cliente)
                        .Include(v => v.Funcionario)
                        .Where(v => v.Cliente.Cpf.Equals(cpf))
                        .AsNoTracking()
                        .ToListAsync();

            return vendas;
        }

        public async Task<IEnumerable<Venda>> ObterPorFuncionarioIdAsync(Guid id)
        {
            var vendas =
                await this.vendas.Query
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
                await this.vendas.Query
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

            await this.vendas.RemoverAsync(id);
        }

        public async Task<IEnumerable<Venda>> ObterTodasPorDataAsync(DateTime data)
        {
            var vendas =
                await this.vendas.Query
                        .Include(v => v.Cliente)
                        .Include(v => v.Funcionario)
                        .Where(v => v.Data == data)
                        .OrderBy(v => v.Data).ThenBy(v => v.Funcionario.Nome)
                        .AsNoTracking()
                        .ToListAsync();

            return vendas;
        }

        public async Task<VendaItem> CriarVendaItemAsync(Guid produtoId, int? quantidade)
        {
            var produto = await this.vendas.Context.Set<Produto>().FindAsync(produtoId);

            VendaItem vendaItem = new VendaItem()
            {
                Produto = produto,
                Valor = produto.PrecoVenda,
                Quantidade = quantidade.Value
            };

            return await Task.FromResult(vendaItem);
        }

        public async Task<bool> ContemAsync(Guid id)
        {
            return await this.vendas.ContemAsync(id);
        }
    }
}
