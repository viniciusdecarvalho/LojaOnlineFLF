using System.Threading.Tasks;
using LojaOnlineFLF.DataModel.Models;

namespace LojaOnlineFLF.DataModel.Repositories
{
    internal class AcessoAdminRepository : IAcessosRepository
    {
        private readonly IAcessosRepository acessosRepository;

        public AcessoAdminRepository(IAcessosRepository acessosRepository)
        {
            this.acessosRepository = acessosRepository;
        }

        public async Task<Funcionario> LoginAsync(string usuario, string senha)
        {
            const string admin = "admin";
            if (admin.Equals(usuario) && admin.Equals(senha))
            {
                return new Funcionario { Nome = admin };
            }

            return await this.acessosRepository.LoginAsync(usuario, senha);
        }

        public async Task RegistrarAsync(Acesso acesso, string senha)
        {
            await this.acessosRepository.RegistrarAsync(acesso, senha);
        }

        public async Task AlterarAsync(Acesso acesso, string senhaAtual, string novaSenha)
        {
            await this.acessosRepository.AlterarAsync(acesso, senhaAtual, novaSenha);
        }
    }
}
