namespace LojaOnlineFLF.Services
{
    /// <summary>
    /// Construir regras de geracao de autenticacao
    /// </summary>
    /// TODO:Permitir a inclusao de claims
    public class Afirmacao
    {
        /// <summary>
        /// Construtor padrao
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="regra"></param>
        public Afirmacao(string usuario, string regra)
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