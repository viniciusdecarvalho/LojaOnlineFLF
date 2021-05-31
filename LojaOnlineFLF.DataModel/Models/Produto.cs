﻿using System;

namespace LojaOnlineFLF.DataModel.Models
{
    public class Produto
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string CodigoBarras { get; set; }

        public decimal PrecoVenda { get; set; }

        public bool Ativo { get; set; } = true;
    }
}