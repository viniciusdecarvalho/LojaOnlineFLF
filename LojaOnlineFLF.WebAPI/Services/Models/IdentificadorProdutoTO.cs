using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LojaOnlineFLF.WebAPI.Services.Models
{
    public class IdentificadorProdutoTO
    {
        /// <summary>
        /// VendaId
        /// </summary>
        public Guid Id { get; set; }

        public string CodigoBarras { get; set; }

        public int? Quantidade { get; set; }
    }
}
