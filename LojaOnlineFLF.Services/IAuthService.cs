using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;

namespace LojaOnlineFLF.Services
{
    /// <summary>
    /// Permitir autenticacao e geracao de token
    /// </summary>
    public interface IAuthService : IService
    {
        /// <summary>
        /// Gerar informacoes de autenticacao
        /// </summary>
        /// <param name="afirmacao"></param>
        /// <returns></returns>
        Autenticacao Autenticar(Afirmacao afirmacao);
    }
}