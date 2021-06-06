using System;

namespace LojaOnlineFLF.WebAPI.Services.Models
{
    [ResultName("Item")]
    public class VendaItemTO
    {
        public Guid VendaId { get; set; }

        public Guid ProdutoId { get; set; }

        public int? Quantidade { get; set; }
    }
}