namespace LojaOnlineFLF.WebAPI.Services.Models
{
    ///<summary>
    /// Parametros para alteracao do acesso
    ///</summary>
    [ResultName("AlteracaoLogin")]
    public class LoginAlteracao
    {
        ///<summary>
        /// Usuario para login
        ///</summary>
        public string Usuario { get; set; }

        ///<summary>
        /// Senha atual do usuario
        ///</summary>
        public string SenhaAtual { get; set; }

        ///<summary>
        /// Nova senha para acesso
        ///</summary>
        public string NovaSenha { get; set; }
    }
}