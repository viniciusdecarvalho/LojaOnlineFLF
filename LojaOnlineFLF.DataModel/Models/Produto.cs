using System;
using System.Collections.Generic;

namespace LojaOnlineFLF.DataModel.Models
{
    public class Produto : EntityKey<Guid>
    {
        public string Nome { get; set; }

        public string CodigoBarras { get; set; }

        public decimal PrecoVenda { get; set; }

        public bool Ativo { get; set; } = true;
    }
}