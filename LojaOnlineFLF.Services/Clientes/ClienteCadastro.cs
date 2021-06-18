using System;

namespace LojaOnlineFLF.Services
{
    /// <summary>
    /// Informcoes de cliente
    /// </summary>
    public class ClienteCadastro
    {        
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