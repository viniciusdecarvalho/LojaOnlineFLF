using System;
using System.Collections.Generic;

namespace LojaOnlineFLF.DataModel.Models
{
    public class VendaItem
    {
        public Guid Id { get; set; }

        public Produto Produto { get; set; }

        public decimal Valor { get; set; }

        public int Quantidade { get; set; }        
    }
}