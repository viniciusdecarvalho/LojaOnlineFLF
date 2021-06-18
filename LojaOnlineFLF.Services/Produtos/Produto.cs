using System;

namespace LojaOnlineFLF.Services
{
    /// <summary>
    /// Produto persistido no sistema
    /// </summary>
    public class Produto: ProdutoCadastro
    {
        /// <summary>
        /// Identificador
        /// </summary>
        public Guid Id { get; set; }
    }
}