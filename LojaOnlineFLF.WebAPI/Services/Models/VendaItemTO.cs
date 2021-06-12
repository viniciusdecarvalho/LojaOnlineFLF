using System;

namespace LojaOnlineFLF.WebAPI.Services.Models
{
    /// <summary>
    /// Parametros para alterar os itens de uma venda
    /// </summary>
    [ResultName("Item")]
    public class VendaItemTO
    {
        /// <summary>
        /// Identificador da venda
        /// </summary>
        public Guid VendaId { get; set; }

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