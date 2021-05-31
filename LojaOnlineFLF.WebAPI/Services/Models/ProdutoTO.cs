using System;
using LojaOnlineFLF.WebAPI.Services.Models;

namespace LojaOnlineFLF.WebAPI.Services.Models
{
    [ResultName("Produto")]
    public class ProdutoTO
    {
        public Guid? Id { get; set; }

        public string Nome { get; set; }

        public string CodBarras { get; set; }

        public decimal? Preco { get; set; }
    }
}