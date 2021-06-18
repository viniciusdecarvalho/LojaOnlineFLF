using System;
using System.Threading.Tasks;
using LojaOnlineFLF.DataModel.Models;

namespace LojaOnlineFLF.Repositories
{
    internal class AcessoAdminRepository : IAcessosRepository
    {
        private const string admin = "admin";
        private const string id = "03b03673-83dd-4bb5-8e3e-2f8de44f8d24";

        private readonly IAcessosRepository acessosRepository;

        public AcessoAdminRepository(IAcessosRepository acessosRepository)
        {
            this.acessosRepository = acessosRepository;
        }

        public async Task<Funcionario> LoginAsync(string usuario, string senha)
        {
            if (admin.Equals(usuario) && admin.Equals(senha))
            {
                return await CreateAdmin();
            }

            return await this.acessosRepository.LoginAsync(usuario, senha);
        }

        private Task<Funcionario> CreateAdmin()
        {
            return Task.FromResult(new Funcionario { Nome = admin, Id = Guid.Parse(id) });
        }

        public async Task RegistrarAsync(Acesso acesso, string senha)
        {
            await this.acessosRepository.RegistrarAsync(acesso, senha);
        }

        public async Task AlterarAsync(Acesso acesso, string senhaAtual, string novaSenha)
        {
            await this.acessosRepository.AlterarAsync(acesso, senhaAtual, novaSenha);
        }

        public Task<Funcionario> ObterFuncionarioAsync(string userName)
        {
            if (userName.Equals(admin))
            {
                return CreateAdmin();
            }

            return this.acessosRepository.ObterFuncionarioAsync(userName);
        }
    }
}
