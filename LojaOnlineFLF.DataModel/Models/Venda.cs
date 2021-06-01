using System;
using System.Collections.Generic;

namespace LojaOnlineFLF.DataModel.Models
{
    public class Venda
    {
        public Guid Id { get; set; }

        public DateTime Data { get; set; }

        public Cliente Cliente { get; set; }

        public Funcionario Funcionario { get; set; }

        public VendaSituacao Situacao { get; set; }

        public ICollection<VendaItem> Itens { get; set; } = new List<VendaItem>();

        internal void Cancelar() => 
            this.Situacao?.Cancelar(this);

        internal void Concluir() =>
            this.Situacao?.Concluir(this);

        internal void Abrir() =>
            this.Situacao?.Abrir(this);

        internal bool PodeExcluir() => this.Situacao?.PodeExcluir(this) ?? true;
    }
}
