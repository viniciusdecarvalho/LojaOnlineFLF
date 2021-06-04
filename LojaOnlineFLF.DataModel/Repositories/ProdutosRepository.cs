using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaOnlineFLF.DataModel.Models;
using LojaOnlineFLF.DataModel.Providers;
using Microsoft.EntityFrameworkCore;

namespace LojaOnlineFLF.DataModel.Repositories
{
    internal class ProdutosRepository : IProdutosRepository, IRepositoryPossuiVendaBehavior<Produto>
    {
        private RepositoryEF<Produto, Guid> produtos;

        public ProdutosRepository(LojaEFContext context)
        {
            this.produtos = new RepositoryEF<Produto, Guid>(context);
        }

        public async Task AtualizarAsync(Produto produto)
        {
            await this.produtos.AtualizarAsync(produto);
        }

        public async Task<bool> ContemAsync(Guid id)
        {
            return await this.produtos.ContemAsync(id);
        }

        public async Task IncluirAsync(Produto produto)
        {
            await this.produtos.IncluirAsync(produto);
        }

        public async Task<IEnumerable<Produto>> ListarTodosAsync()
        {
            return await this.produtos.Query
                            .Where(p => p.Ativo)
                            .AsNoTracking()
                            .ToListAsync();
        }

        public async Task<Produto> ObterAsync(Guid id)
        {
            return await this.produtos.ObterAsync(id);
        }

        public async Task<Produto> ObterPorCodigoDeBarrasAsync(string codigoBarras)
        {
            if (codigoBarras is null)
            {
                throw new ArgumentNullException(nameof(codigoBarras));
            }

            return await this.produtos.Query
                                .Where(p => p.CodigoBarras == codigoBarras)
                                .AsNoTracking()
                                .FirstOrDefaultAsync();
        }

        public async Task<bool> PossuiVendas(Produto produto)
        {
            return 
                await this.produtos.Context
                                    .Set<Venda>()
                                    .Include(v => v.Itens)
                                    .AnyAsync(v => v.Itens.Any(i => i.Equals(produto.Id)));
        }

        public async Task RemoverAsync(Guid id)
        {
            var produto = await this.produtos.ObterAsync(id);

            if (produto is null)
            {
                throw new InvalidOperationException("produto nao encontrado");
            }

            if (await this.PossuiVendas(produto))
            {
                throw new InvalidOperationException("produto possui vendas registradas");
            }

            produto.Ativo = false;

            await this.AtualizarAsync(produto);
        }
    }
}
