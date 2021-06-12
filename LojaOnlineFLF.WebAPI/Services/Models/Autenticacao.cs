using System;
using System.ComponentModel;

namespace LojaOnlineFLF.WebAPI.Services.Models
{
    /// <summary>
    /// Retorno da resposta de autenticao
    /// </summary>
    [ResultName("Autenticacao")]
    public class Autenticacao
    {
        /// <summary>
        /// Nome de usuario usado na autenticacao
        /// </summary>
        public string Usuario { get; set; }

        /// <summary>
        /// Token gerado na autenticacao, deve ser utilizado para acessar recursos nao publicos
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Data limite de uso do Token
        /// </summary>
        public DateTime DataExpiracao { get; internal set; }

        /// <summary>
        /// Data da autenticacao e egeracao do token
        /// </summary>
        public DateTime DataCriacao { get; internal set; }

        /// <summary>
        /// Token que pode ser utilizado para atualizar a autenticacao
        /// </summary>
        public string RefreshToken { get; internal set; }
    }
}
