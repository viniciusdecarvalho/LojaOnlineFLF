namespace LojaOnlineFLF.WebAPI.Services.Models
{
    /// <summary>
    /// Parametros para atualizar token de acesso
    /// </summary>
    public class RefreshToken
    {
        /// <summary>
        /// Nome de usuario para autenticacao
        /// </summary>
        public string Usuario { get; set; }

        /// <summary>
        /// Token para identificacao
        /// </summary>
        public string Token { get; set; }
    }
}