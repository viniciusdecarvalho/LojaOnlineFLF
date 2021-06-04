using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaOnlineFLF.DataModel.Models;
using LojaOnlineFLF.DataModel.Providers;
using Microsoft.EntityFrameworkCore;

namespace LojaOnlineFLF.DataModel.Repositories
{
    internal class FuncionariosRepository: IFuncionariosRepository
    {
        private RepositoryEF<Funcionario, Guid> funcionarios;
        private RepositoryEF<Cargo, Guid> cargos;

        public FuncionariosRepository(LojaEFContext context)
        {
            this.funcionarios = new RepositoryEF<Funcionario, Guid>(context);
            this.cargos = new RepositoryEF<Cargo, Guid>(context);
        }

        public async Task AtualizarAsync(Funcionario funcionario)
        {
            await this.funcionarios.AtualizarAsync(funcionario);
        }

        public async Task IncluirAsync(Funcionario funcionario)
        {
            await this.funcionarios.IncluirAsync(funcionario);
        }

        public async Task<IEnumerable<Funcionario>> ListarTodosAsync()
        {
            return await this.funcionarios.Query
                                .Include(f => f.Cargo)
                                .Where(f => f.Ativo)
                                .AsNoTracking()
                                .ToListAsync();
        }

        public async Task<Funcionario> ObterAsync(Guid id)
        {
            return await this.funcionarios.ObterAsync(id);
        }

        public async Task<Funcionario> ObterPorCpfAsync(string cpf)
        {
            return await this.funcionarios.Query
                            .Where(f => f.Cpf.Equals(cpf))
                            .AsNoTracking()
                            .FirstOrDefaultAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var funcionario = await this.ObterAsync(id);

            if (funcionario is null)
            {
                throw new InvalidOperationException("funcionario nao encontrado");
            }

            funcionario.Ativo = false;

            await this.AtualizarAsync(funcionario);
        }

        public async Task<ICargos> ObterCargosAsync()
        {
            var cargos = await this.cargos.Query.ToListAsync();

            var gerente = cargos.FirstOrDefault(c => c.Id == Cargo.Gerente);
            var operacional = cargos.FirstOrDefault(c => c.Id == Cargo.Operacional);

            return new Cargos(gerente: gerente, operacional: operacional);
        }

        public async Task<bool> ContemAsync(Guid id)
        {
            return await this.funcionarios.ContemAsync(id);
        }
    }
}
