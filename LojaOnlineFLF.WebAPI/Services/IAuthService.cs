using LojaOnlineFLF.WebAPI.Services.Models;

namespace LojaOnlineFLF.WebAPI.Services
{
    /// <summary>
    /// Permitir autenticacao e geracao de token
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Gerar informacoes de autenticacao
        /// </summary>
        /// <param name="afirmacao"></param>
        /// <returns></returns>
        public Autenticacao Autenticar(AfirmacaoTO afirmacao);
    }
}