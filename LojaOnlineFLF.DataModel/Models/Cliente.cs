using System;
using System.Collections.Generic;

namespace LojaOnlineFLF.DataModel.Models
{
    public class Cliente
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Fone { get; set; }

        public ICollection<Venda> Vendas { get; set; } = new List<Venda>();
    }
}
