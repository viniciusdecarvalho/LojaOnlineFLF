namespace LojaOnlineFLF.Services
{
    /// <summary>
    /// Permitir parametros para paginacao
    /// </summary>
    public interface IPageParameters
    {
        /// <summary>
        /// Numero da pagina a ser exibida, quando nao informado igual a 1
        /// </summary>
        int? NumeroPagina { get; set; }

        /// <summary>
        /// Quantidade de registros por pagina, quando nao informado igual a 25
        /// </summary>
        int? TamanhoPagina { get; set; }
    }
}
