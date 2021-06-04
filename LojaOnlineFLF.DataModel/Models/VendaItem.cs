using System;
using System.Collections.Generic;

namespace LojaOnlineFLF.DataModel.Models
{
    public class VendaItem : EntityKey<Guid>
    {
        public Produto Produto { get; set; }

        public decimal Valor { get; set; }

        public int Quantidade { get; set; }

        public Venda Venda { get; set; }
    }
}