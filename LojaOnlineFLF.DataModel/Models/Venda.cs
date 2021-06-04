using System;
using System.Collections.Generic;
using System.Linq;

namespace LojaOnlineFLF.DataModel.Models
{
    public class Venda : EntityKey<Guid>
    {
        public DateTime Data { get; set; } = DateTime.Now;

        public Cliente Cliente { get; set; }
        public Guid? ClienteId { get; set; }

        public Funcionario Funcionario { get; set; }
        public Guid FuncionarioId { get; set; }

        public VendaSituacao Situacao { get; set; } = VendaSituacao.Aberta;

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
