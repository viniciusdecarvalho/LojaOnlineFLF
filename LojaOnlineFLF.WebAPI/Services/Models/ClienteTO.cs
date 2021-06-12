using System;
using LojaOnlineFLF.WebAPI.Services.Models;

namespace LojaOnlineFLF.WebAPI.Services.Models
{
    /// <summary>
    /// Informcoes de cliente
    /// </summary>
    [ResultName("Cliente")]
    public class ClienteTO
    {
        /// <summary>
        /// Identificador
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Nome do cliente
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Cpf do cliente
        /// </summary>
        public string Cpf { get; set; }

        /// <summary>
        /// Fone do cliente
        /// </summary>
        public string Fone { get; set; }
    }
}