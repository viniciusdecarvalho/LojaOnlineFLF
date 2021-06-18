using System.Threading.Tasks;

namespace LojaOnlineFLF.Services
{
    ///<summary>
    /// servicos de funcionarios padrao
    ///</summary>
    public interface IAcessosService: IService
    {
        /// <summary>
        /// Validar autenticacao por Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns>Funcionario Logado</returns>
        Task<Funcionario> ValidarAcessoAsync(Login login);

        /// <summary>
        /// Valida o token de atualizacao de autenticacao
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns>Funcionario logado</returns>
        Task<Funcionario> ValidarTokenAsync(RefreshToken refreshToken);

        /// <summary>
        /// Permitir incluir parametros de acesso para um funcionario
        /// </summary>
        /// <param name="funcionario"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        Task IncluirAcessoAsync(Funcionario funcionario, Login login);

        /// <summary>
        /// Alterar parametros de acesso de um funcionario
        /// </summary>
        /// <param name="funcionario"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        Task AlterarAcessoAsync(Funcionario funcionario, LoginAlteracao login);
    }
}