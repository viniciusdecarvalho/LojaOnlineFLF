namespace LojaOnlineFLF.WebAPI.Services.Models
{
    /// <summary>
    /// Construir regras de geracao de autenticacao
    /// </summary>
    public class AfirmacaoTO
    {
        /// <summary>
        /// Construtor padrao
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="regra"></param>
        public AfirmacaoTO(string usuario, string regra)
        {
            Usuario = usuario;
            Regra = regra;
        }

        /// <summary>
        /// Usuario da autenticacao
        /// </summary>
        public string Usuario { get; }

        /// <summary>
        /// Regra da autenticacao
        /// </summary>
        public string Regra { get; }
    }
}