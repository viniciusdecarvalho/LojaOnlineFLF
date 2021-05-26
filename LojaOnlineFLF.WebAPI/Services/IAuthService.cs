using LojaOnlineFLF.WebAPI.Services.Models;

namespace LojaOnlineFLF.WebAPI.Services
{
    public interface IAuthService
    {
        public string ObterToken(AfirmacaoTO afirmacao);
    }
}