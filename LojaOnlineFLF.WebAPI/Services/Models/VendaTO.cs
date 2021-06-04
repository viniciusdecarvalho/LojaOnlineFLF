using System;
using System.Collections.Generic;
using LojaOnlineFLF.WebAPI.Services.Models;

namespace LojaOnlineFLF.WebAPI.Services.Models
{
    [ResultName("VendaCadastro")]
    public class VendaCadastroTO
    {
        public Guid? ClienteId { get; set; }

        public Guid? FuncionarioId { get; set; }
    }

    [ResultName("VendaCadastrada")]
    public class VendaCadastradaTO: VendaCadastroTO
    {
        public Guid Id { get; set; }
    }

    [ResultName("Venda")]
    public class VendaTO : VendaCadastradaTO
    {
        public DateTime Data { get; set; }

        public string Situacao { get; set; }

        public ICollection<ItemTO> Itens { get; set; } = new List<ItemTO>();

        [ResultName("ItemVenda")]
        public class ItemTO
        {
            public Guid? ProdutoId { get; set; }

            public int? Quantidade { get; set; }

            public decimal? Valor { get; set; }
        }
    }
}