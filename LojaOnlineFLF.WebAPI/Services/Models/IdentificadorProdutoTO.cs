using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LojaOnlineFLF.WebAPI.Services.Models
{
    /// <summary>
    /// Parametros para alterar quantidade de produto em uma venda
    /// </summary>
    public class IdentificadorProdutoTO
    {
        /// <summary>
        /// VendaId, identificador da venda
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Codigo de barras do produto
        /// </summary>
        public string CodigoBarras { get; set; }

        /// <summary>
        /// Quantidade do produto na venda
        /// </summary>
        public int? Quantidade { get; set; }
    }
}
