using System;
using System.Collections.Generic;

namespace LojaOnlineFLF.Services
{
    /// <summary>
    /// Representa uma venda em seu estado atual
    /// </summary>
    public class Venda : VendaCadastrada
    {
        /// <summary>
        /// Data
        /// </summary>
        public DateTime Data { get; set; }

        /// <summary>
        /// Situacao
        /// </summary>
        public string Situacao { get; set; }

        /// <summary>
        /// Items da venda
        /// </summary>
        public ICollection<ItemTO> Itens { get; set; } = new List<ItemTO>();

        /// <summary>
        /// Item da venda
        /// </summary>
        public class ItemTO
        {
            /// <summary>
            /// Identificador do produto
            /// </summary>
            public Guid ProdutoId { get; set; }

            /// <summary>
            /// Quantidade
            /// </summary>
            public int Quantidade { get; set; }

            /// <summary>
            /// Valor do produto
            /// </summary>
            public decimal Valor { get; set; }
        }
    }
}