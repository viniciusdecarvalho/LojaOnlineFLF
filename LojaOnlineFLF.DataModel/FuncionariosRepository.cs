using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaOnlineFLF.DataModel.Models;
using LojaOnlineFLF.DataModel.Providers;
using Microsoft.EntityFrameworkCore;

namespace LojaOnlineFLF.DataModel
{
    internal class FuncionariosRepository: IFuncionariosRepository
    {
        private readonly LojaEFContext context;

        public FuncionariosRepository(LojaEFContext context)
        {
            this.context = context;
        }

        public async Task AtualizarAsync(Funcionario funcionario)
        {
            await Task.Run(() =>
                context.Set<Funcionario>().Update(funcionario)
            );
        }

        public async Task IncluirAsync(Funcionario funcionario)
        {
            await context.Set<Funcionario>().AddAsync(funcionario);
        }

        public async Task<IEnumerable<Funcionario>> ListarAsync()
        {
            return await context.Funcionarios.Where(f => f.Ativo).AsNoTracking().ToListAsync();
        }

        public async Task<Funcionario> ObterAsync(Guid id)
        {
            var funcionario = await context.Funcionarios.Where(f => f.Id == id).AsNoTracking().FirstOrDefaultAsync();

            return funcionario;
        }

        public async Task<Funcionario> ObterPorCpfAsync(string cpf)
        {
            return await context.Funcionarios
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
            var cargos = await this.context.Cargos.ToListAsync();

            return new Cargos
            {
                Operacional = cargos.FirstOrDefault(c => c.Id == Cargo.Operacional),
                Gerente = cargos.FirstOrDefault(c => c.Id == Cargo.Gerente)
            };
        }
    }
}
