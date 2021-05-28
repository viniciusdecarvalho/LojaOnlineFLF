namespace LojaOnlineFLF.WebAPI.Services.Models
{
    ///<summary>
    /// Parametros para acesso
    ///</summary>
    [ResultName("Login")]
    public class Login
    {
        ///<summary>
        /// Nome de usuario para login
        ///</summary>
        public string Usuario { get; set; }

        ///<summary>
        /// Senha para acesso
        ///</summary>
        public string Senha { get; set; }
    }
}