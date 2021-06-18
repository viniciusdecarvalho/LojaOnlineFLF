using System;

namespace LojaOnlineFLF.Services
{
    /// <summary>
    /// Parametros para alterar os itens de uma venda
    /// </summary>
    public class VendaItem
    {
        /// <summary>
        /// Identificador do produto
        /// </summary>
        public Guid ProdutoId { get; set; }

        /// <summary>
        /// Quantidade
        /// </summary>
        public int? Quantidade { get; set; }
    }
}