using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaOnlineFLF.DataModel.Models;
using LojaOnlineFLF.DataModel.Providers;
using Microsoft.EntityFrameworkCore;

namespace LojaOnlineFLF.DataModel.Repositories
{
    internal class ClientesRepository : IClientesRepository
    {
        private readonly LojaEFContext context;

        public ClientesRepository(LojaEFContext context)
        {
            this.context = context;
        }

        public async Task AtualizarAsync(Cliente entity)
        {
            await Task.Run(() =>
                context.Set<Cliente>().Update(entity)
            );
        }

        public async Task IncluirAsync(Cliente entity)
        {
            await context.Set<Cliente>().AddAsync(entity);
        }

        public async Task<Cliente> ObterAsync(Guid id)
        {
            var produtos = await context.Clientes
                                        .Where(f => f.Id == id)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync();

            return produtos;
        }

        public async Task RemoverAsync(Guid id)
        {
            var cliente = await this.ObterAsync(id);

            this.context.Set<Cliente>().Remove(cliente);
        }
    }
}
