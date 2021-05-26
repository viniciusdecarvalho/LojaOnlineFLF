using System;
using System.ComponentModel;

namespace LojaOnlineFLF.WebAPI.Services.Models
{
    ///<summary>
    /// Funcionario
    ///</summary>
    [ResultName("Funcionario")]
    public class FuncionarioTO
    {
        ///<summary>
        /// Id do cargo
        ///</summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nome do funcionario
        /// </summary>
        /// <example>Joao Carlos</example>
        public string Nome { get; set; }

        /// <summary>
        /// NUmero do CPF do Funcionario formatado
        /// </summary>
        /// <example>777.963.666-44</example>
        public string Cpf { get; set; }

        ///<summary>
        /// Cargo do functionario
        ///</summary>
        ///<example>1 - Operacional, 2 - Gerente</example>
        public CargoTO Cargo { get; set; }

        /// <summary>
        /// Data de inicio do funcionario
        /// </summary>
        /// <example>2021-05-01</example>
        public DateTime? DataInicio { get; set; }

        /// <summary>
        /// Data de encerramento do funcionario
        /// </summary>
        /// <example>2021-05-30</example>
        public DateTime? DataFim { get; set; }
    }
}