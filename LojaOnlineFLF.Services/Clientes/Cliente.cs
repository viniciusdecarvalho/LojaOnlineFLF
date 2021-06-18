using System;

namespace LojaOnlineFLF.Services
{
    /// <summary>
    /// Informcoes de cliente
    /// </summary>
    public class Cliente: ClienteCadastro
    {
        /// <summary>
        /// Identificador
        /// </summary>
        public Guid? Id { get; set; }
    }
}