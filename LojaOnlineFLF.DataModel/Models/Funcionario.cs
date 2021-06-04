using System;
using System.Collections.Generic;

namespace LojaOnlineFLF.DataModel.Models
{
    ///<summary>
    /// Funcionario
    ///</summary>
    public class Funcionario : EntityKey<Guid>
    {
        /// <summary>
        /// Nome do funcionario
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// NUmero do CPF do Funcionario formatado
        /// </summary>
        public string Cpf { get; set; }

        ///<summary>
        /// Cargo do functionario
        ///</summary>
        public Cargo Cargo { get; set; }

        /// <summary>
        /// Data de inicio do funcionario
        /// </summary>
        public DateTime? DataInicio { get; set; }

        /// <summary>
        /// Data de encerramento do funcionario
        /// </summary>
        public DateTime? DataFim { get; set; }

        /// <summary>
        /// Data de encerramento do funcionario
        /// </summary>        
        public bool Ativo { get; set; } = true;

        public ICollection<Venda> Vendas { get; set; } = new List<Venda>();
    }
}