using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaOnlineFLF.DataModel.Models;
using LojaOnlineFLF.DataModel.Providers;
using Microsoft.EntityFrameworkCore;

namespace LojaOnlineFLF.DataModel.Repositories
{
    internal class ClientesRepository : IClientesRepository, IRepositoryPossuiVendaBehavior<Cliente>
    {
        private RepositoryEF<Cliente, Guid> clientes;

        public ClientesRepository(LojaEFContext context)
        {
            this.clientes = new RepositoryEF<Cliente, Guid>(context);
        }

        public async Task AtualizarAsync(Cliente entity)
        {
            await this.clientes.AtualizarAsync(entity);
        }

        public async Task<bool> ContemAsync(Guid id)
        {
            return await this.clientes.ContemAsync(id);
        }

        public async Task IncluirAsync(Cliente entity)
        {
            await this.clientes.IncluirAsync(entity);
        }

        public async Task<Cliente> ObterAsync(Guid id)
        {
            return await this.clientes.ObterAsync(id);
        }

        public async Task<IEnumerable<Cliente>> ObterPorCpfAsync(string cpf)
        {
            var clientes =
                await this.clientes.Query
                                    .Where(f => f.Cpf.Equals(cpf))
                                    .AsNoTracking()
                                    .ToListAsync();

            return clientes;
        }

        public async Task<bool> PossuiVendas(Cliente cliente)
        {
            var possuiVendas =
                await this.clientes.Context
                            .Set<Venda>()
                            .AnyAsync(v => v.ClienteId.Equals(cliente.Id));

            return possuiVendas;
        }

        public async Task RemoverAsync(Guid id)
        {
            var cliente = await this.clientes.ObterAsync(id);

            if (cliente is null)
            {
                throw new InvalidOperationException("cliente nao encontrado");
            }

            if (await this.PossuiVendas(cliente))
            {
                throw new InvalidOperationException("cliente possui vendas registradas");
            }

            await this.clientes.RemoverAsync(id);
        }
    }
}
