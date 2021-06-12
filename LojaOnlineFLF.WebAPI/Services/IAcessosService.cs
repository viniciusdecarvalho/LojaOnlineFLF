using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LojaOnlineFLF.WebAPI.Services.Models;

namespace LojaOnlineFLF.WebAPI.Services
{
    ///<summary>
    /// servicos de funcionarios padrao
    ///</summary>
    public interface IAcessosService
    {
        /// <summary>
        /// Validar autenticacao por Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns>Funcionario Logado</returns>
        Task<FuncionarioTO> ValidarAcessoAsync(Login login);

        /// <summary>
        /// Valida o token de atualizacao de autenticacao
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns>Funcionario logado</returns>
        Task<FuncionarioTO> ValidarTokenAsync(RefreshToken refreshToken);

        /// <summary>
        /// Permitir incluir parametros de acesso para um funcionario
        /// </summary>
        /// <param name="funcionario"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        Task IncluirAcessoAsync(FuncionarioTO funcionario, Login login);

        /// <summary>
        /// Alterar parametros de acesso de um funcionario
        /// </summary>
        /// <param name="funcionario"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        Task AlterarAcessoAsync(FuncionarioTO funcionario, LoginAlteracao login);
    }
}