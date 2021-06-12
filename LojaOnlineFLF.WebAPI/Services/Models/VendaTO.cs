using System;
using System.Collections.Generic;
using LojaOnlineFLF.WebAPI.Services.Models;

namespace LojaOnlineFLF.WebAPI.Services.Models
{
    /// <summary>
    /// Cliente da venda
    /// </summary>
    [ResultName("VendaCliente")]
    public class VendaClienteTO
    {
        /// <summary>
        /// CPF do cliente
        /// </summary>
        public string Cpf { get; set; }

        /// <summary>
        /// Fone do cliente
        /// </summary>
        public string Fone { get; set; }
    }

    /// <summary>
    /// Parametros para nova venda
    /// </summary>
    [ResultName("VendaCadastro")]
    public class VendaCadastroTO
    {
        /// <summary>
        /// Clientes
        /// </summary>
        public VendaClienteTO Cliente { get; set; }

        /// <summary>
        /// Identificador do funcionario
        /// </summary>
        public Guid FuncionarioId { get; set; }
    }

    /// <summary>
    /// Resultado do cadastro de nova venda
    /// </summary>
    [ResultName("VendaCadastrada")]
    public class VendaCadastradaTO: VendaCadastroTO
    {
        /// <summary>
        /// Identificador da venda
        /// </summary>
        public Guid Id { get; set; }
    }

    /// <summary>
    /// Representa uma venda em seu estado atual
    /// </summary>
    [ResultName("Venda")]
    public class VendaTO : VendaCadastradaTO
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
        [ResultName("ItemVenda")]
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