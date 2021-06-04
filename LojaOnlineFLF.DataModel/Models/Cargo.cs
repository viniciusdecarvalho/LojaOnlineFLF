using System;
using System.Collections.Generic;

namespace LojaOnlineFLF.DataModel.Models
{
    ///<summary>
    /// Cargos dos funcionarios
    ///</summary>
    public class Cargo: EntityKey<Guid>
    {
        public static readonly Guid Operacional = Guid.Parse("76cdf6d2-ec97-480f-b37e-a6e9e4df0d44");
        public static readonly Guid Gerente = Guid.Parse("685b1fde-d605-4dd4-9285-661be772ed66");

        ///<summary>
        /// Nome
        ///</summary>
        public string Nome { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();

        public override string ToString()
        {
            return this.Nome;
        }
    }
}