using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaOnlineFLF.DataModel.Models;
using LojaOnlineFLF.DataModel.Providers;
using Microsoft.EntityFrameworkCore;

namespace LojaOnlineFLF.DataModel.Repositories
{
    internal class ProdutosRepository : IProdutosRepository
    {
        private readonly LojaEFContext context;

        public ProdutosRepository(LojaEFContext context)
        {
            this.context = context;
        }

        public async Task AtualizarAsync(Produto entity)
        {
            await Task.Run(() =>
                context.Set<Produto>().Update(entity)
            );
        }

        public async Task IncluirAsync(Produto entity)
        {
            await context.Set<Produto>().AddAsync(entity);
        }

        public async Task<IEnumerable<Produto>> ListarAsync()
        {
            return await context.Produtos
                                .Where(p => p.Ativo)
                                .AsNoTracking()
                                .ToListAsync();
        }

        public async Task<Produto> ObterAsync(Guid id)
        {
            var produtos = await context.Produtos
                                           .Where(f => f.Id == id)
                                           .AsNoTracking()
                                           .FirstOrDefaultAsync();

            return produtos;
        }

        public async Task<Produto> ObterPorCodigoDeBarrasAsync(string codigoBarras)
        {
            if (codigoBarras is null)
            {
                throw new ArgumentNullException(nameof(codigoBarras));
            }

            return await context.Produtos
                                .Where(p => p.CodigoBarras == codigoBarras)
                                .AsNoTracking()
                                .FirstOrDefaultAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var produto = await this.ObterAsync(id);

            if (produto is null)
            {
                throw new InvalidOperationException("funcionario nao encontrado");
            }

            produto.Ativo = false;

            await this.AtualizarAsync(produto);
        }
    }
}
