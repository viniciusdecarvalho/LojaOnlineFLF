using System;
using System.Linq;

namespace LojaOnlineFLF.DataModel.Models
{    
    internal class Cargos: ICargos
    {
        public Cargo Operacional { get; set; }

        public Cargo Gerente { get; set; }

        public Cargo Of(string nome)
        {
            var cargos = new Cargo[]{ Operacional, Gerente };

            return cargos.FirstOrDefault(c => c.Nome.Equals(nome)) ?? throw new InvalidOperationException($"cargo invalido - {nome}");
        }
    }
}
