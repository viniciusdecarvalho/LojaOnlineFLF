using LojaOnlineFLF.WebAPI.Services.Models;

namespace LojaOnlineFLF.WebAPI.Services
{
    public interface IAuthService
    {
        public Autenticacao Autenticar(AfirmacaoTO afirmacao);
    }
}