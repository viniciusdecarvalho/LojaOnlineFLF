using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LojaOnlineFLF.DataModel.Models;

namespace LojaOnlineFLF.Repositories
{    
    internal class Cargos: ICargos
    {
        public Cargo Operacional { get; set; }

        public Cargo Gerente { get; set; }

        public Cargos(Cargo gerente, Cargo operacional, params Cargo[] outros)
        {
            this.Gerente = gerente;
            this.Operacional = operacional;

            this.cargos = Enumerable.Concat(new Cargo[]{ Operacional, Gerente }, outros);
        }

        private readonly IEnumerable<Cargo> cargos;

        public Cargo Of(string nome)
        {
            if (nome is null)
            {
                throw new ArgumentNullException(nameof(nome));
            }

            var cargos = new Cargo[]{ Operacional, Gerente };

            return cargos.FirstOrDefault(c => c.Nome.ToLower().Equals(nome.ToLower())) ?? throw new InvalidOperationException($"cargo invalido - {nome}");
        }

        public bool IsValid(string nome) 
        {
            try
            {
                this.Of(nome);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerator<Cargo> GetEnumerator()
        {
            return this.cargos.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.cargos.GetEnumerator();
        }

        public override string ToString()
        {
            return new StringBuilder().AppendJoin(", ", this).ToString();
        }
    }
}
