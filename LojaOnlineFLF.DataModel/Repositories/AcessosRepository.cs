using System;
using System.Linq;
using System.Threading.Tasks;
using LojaOnlineFLF.DataModel.Models;
using LojaOnlineFLF.DataModel.Providers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LojaOnlineFLF.DataModel.Repositories
{
    internal class AcessosRepository: IAcessosRepository
    {
        private readonly LojaEFContext context;
        private readonly SignInManager<Acesso> signInManager;
        private readonly UserManager<Acesso> userManager;

        public AcessosRepository(
            LojaEFContext context,
            SignInManager<Acesso> signInManager,
            UserManager<Acesso> _userManager)
        {
            this.context = context;
            this.signInManager = signInManager;
            userManager = _userManager;
        }

        public async Task<Funcionario> LoginAsync(string usuario, string senha)
        {
            var acesso = await this.context.Acessos
                                   .Include(a => a.Funcionario)
                                   .FirstOrDefaultAsync(a => a.UserName == usuario);

            var signIn = await this.signInManager.CheckPasswordSignInAsync(acesso, senha, false);            

            if (!signIn.Succeeded)
            {
                throw new LogUsuarioOuSenhaInvalidoException();
            }

            Funcionario funcionario = acesso.Funcionario;

            if (funcionario is null)
            {
                throw new RegistroNaoEncontradoException("funcionario nao identificado");
            }

            if (!funcionario.Ativo || funcionario.DataFim < DateTime.Now)
            {
                throw new FuncionarioDesligadoOuInativoException();
            }

            return funcionario;
        }

        public async Task RegistrarAsync(Acesso acesso, string senha)
        {
            var creation = await this.userManager.CreateAsync(acesso, senha);

            if (!creation.Succeeded)
            {
                var erros = creation.Errors.Select(e => string.Format("{0}: {1}", e.Code, e.Description)).ToArray();

                throw new InvalidOperationException($"{string.Join(", ", erros)}");
            }
        }

        public async Task AlterarAsync(Acesso acesso, string senhaAtual, string novaSenha)
        {
            var change = await this.userManager.ChangePasswordAsync(acesso, senhaAtual, novaSenha);

            if (!change.Succeeded)
            {
                var erros = change.Errors.Select(e => string.Format("{0}: {1}", e.Code, e.Description)).ToArray();

                throw new InvalidOperationException($"{string.Join(", ", erros)}");
            }
        }
    }
}
