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
        private readonly RepositoryEF<Funcionario, Guid> funcionarios;
        private readonly RepositoryEF<Cargo, Guid> cargos;

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

        public async Task<IPagedList<Funcionario>> ListarTodosAsync(IPageSet page)
        {
            return await this.funcionarios
                                .Query
                                .Include(f => f.Cargo)
                                .Where(f => f.Ativo)
                                .AsNoTracking()
                                .WithPageSet(page)
                                .ToPagedListAsync();
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

        public Task<ICargos> ObterCargosAsync()
        {
            var gerente = new Cargo { Id = Cargo.Operacional, Nome = nameof(Cargo.Operacional) };
            var operacional = new Cargo { Id = Cargo.Gerente, Nome = nameof(Cargo.Gerente) };

            var cargos = new Cargos(gerente: gerente, operacional: operacional);

            return Task.FromResult<ICargos>(cargos);
        }

        public async Task<bool> ContemAsync(Guid id)
        {
            return await this.funcionarios.ContemAsync(id);
        }
    }
}
