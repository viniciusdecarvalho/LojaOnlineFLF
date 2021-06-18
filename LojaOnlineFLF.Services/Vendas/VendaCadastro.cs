using System;

namespace LojaOnlineFLF.Services
{
    /// <summary>
    /// Parametros para nova venda
    /// </summary>
    public class VendaCadastro
    {
        /// <summary>
        /// Clientes
        /// </summary>
        public VendaCliente Cliente { get; set; }

        /// <summary>
        /// Identificador do funcionario
        /// </summary>
        public Guid FuncionarioId { get; set; }
    }
}