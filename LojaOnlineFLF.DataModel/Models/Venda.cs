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

        public void Cancelar() =>
            this.Situacao?.Cancelar(this);

        public void Concluir() =>
            this.Situacao?.Concluir(this);

        public void Abrir() =>
            this.Situacao?.Abrir(this);

        public bool PodeExcluir() => this.Situacao?.PodeExcluir(this) ?? true;
    }
}
