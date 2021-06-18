using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaOnlineFLF.DataModel.Models;
using LojaOnlineFLF.DataModel.Providers;
using Microsoft.EntityFrameworkCore;

namespace LojaOnlineFLF.Repositories
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

        public async Task<ICargos> ObterCargosAsync()
        {
            var listaCargos = await this.cargos.Query.ToListAsync();

            Cargo cargoOperacionalPadrao = new Cargo { Id = Cargo.Operacional, Nome = nameof(Cargo.Operacional) };
            var operacional =
                listaCargos
                .DefaultIfEmpty(cargoOperacionalPadrao)
                .Where(c => c.Id.Equals(Cargo.Operacional))
                .FirstOrDefault();

            Cargo cargoGerentePadrao = new Cargo { Id = Cargo.Gerente, Nome = nameof(Cargo.Gerente) };
            var gerente =
                listaCargos
                .DefaultIfEmpty(cargoGerentePadrao)
                .Where(c => c.Id.Equals(Cargo.Gerente))
                .FirstOrDefault();

            var outros = listaCargos.Except(new Cargo[] { cargoGerentePadrao, cargoOperacionalPadrao }).ToArray();

            var cargos = new Cargos(gerente: gerente, operacional: operacional, outros: outros);

            return cargos;
        }

        public async Task<bool> ContemAsync(Guid id)
        {
            return await this.funcionarios.ContemAsync(id);
        }
    }
}
