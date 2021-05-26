using System.Threading.Tasks;
using LojaOnlineFLF.DataModel.Models;

namespace LojaOnlineFLF.DataModel
{
    public interface IAcessosRepository
    {
        Task RegistrarAsync(Acesso acesso, string senha);

        Task AlterarAsync(Acesso acesso, string senhaAtual, string novaSenha);

        Task<Funcionario> LoginAsync(string usuario, string senha);
    }
}