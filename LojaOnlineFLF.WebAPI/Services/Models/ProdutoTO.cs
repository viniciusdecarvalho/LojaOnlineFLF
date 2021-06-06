using System;
using LojaOnlineFLF.WebAPI.Services.Models;

namespace LojaOnlineFLF.WebAPI.Services.Models
{
    [ResultName("ProdutoCadastro")]
    public class ProdutoCadastroTO
    {
        public string Nome { get; set; }

        public string CodBarras { get; set; }

        public decimal? Preco { get; set; }
    }

    [ResultName("Produto")]
    public class ProdutoTO: ProdutoCadastroTO
    {
        public Guid Id { get; set; }
    }
}