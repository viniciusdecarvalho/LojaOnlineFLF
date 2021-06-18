namespace LojaOnlineFLF.Services
{
    /// <summary>
    /// Parametros para informar novo produto
    /// </summary>
    public class ProdutoCadastro
    {
        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Codigo de Barras
        /// </summary>
        public string CodBarras { get; set; }

        /// <summary>
        /// Preco
        /// </summary>
        public decimal? Preco { get; set; }
    }
}