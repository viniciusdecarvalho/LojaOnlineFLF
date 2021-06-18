using System;

namespace LojaOnlineFLF.Services
{
    ///<summary>
    /// Funcionario 
    ///</summary>
    public class Funcionario: FuncionarioCadastro
    {
        ///<summary>
        /// Id do cargo
        ///</summary>
        public Guid? Id { get; set; }
    }
}