using System;

namespace LojaOnlineFLF.Services
{
    /// <summary>
    /// Resultado do cadastro de nova venda
    /// </summary>
    public class VendaCadastrada: VendaCadastro
    {
        /// <summary>
        /// Identificador da venda
        /// </summary>
        public Guid Id { get; set; }
    }
}