using System;

namespace LojaOnlineFLF.Services
{
    ///<summary>
    /// Novo Funcionario
    ///</summary>
    public class FuncionarioCadastro
    {
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
        public string Cargo { get; set; }

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