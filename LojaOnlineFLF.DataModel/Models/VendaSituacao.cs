using System;
using System.Collections.Generic;
using System.Linq;

namespace LojaOnlineFLF.DataModel.Models
{
    public abstract class VendaSituacao
    {
        public static readonly VendaSituacao Aberta = new VendaAberta();
        public static readonly VendaSituacao Concluida = new VendaConcluida();
        public static readonly VendaSituacao Cancelada = new VendaCancelada();

        internal static readonly IEnumerable<VendaSituacao> Situacoes
            = new VendaSituacao[] { Aberta, Concluida, Cancelada };

        internal const string VendaJaEstaAbertaMensagem = "venda ja esta aberta";
        internal const string VendaJaEstaCancelada = "venda ja esta cancelada";
        internal const string VendaJaEstaConcluida = "venda ja esta concluida";

        public int Codigo { get; set; }

        public string Nome { get; set; }

        public VendaSituacao(int codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }

        public override bool Equals(object obj)
        {
            if (obj is VendaSituacao situacao)
            {
                return this.Codigo.Equals(situacao?.Codigo);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Codigo.GetHashCode();
        }

        public override string ToString()
        {
            return $"{nameof(VendaSituacao)}({this.GetType().Name}[{this.Codigo}])";
        }

        public abstract void Abrir(Venda venda);

        public abstract void Concluir(Venda venda);

        public abstract void Cancelar(Venda venda);

        public virtual bool PodeExcluir(Venda venda) => false;

        public bool IsAberta => this.Equals(Aberta);
        public bool IsConcluida => this.Equals(Concluida);
        public bool IsCancelada => this.Equals(Cancelada);

        public static VendaSituacao From(int codigo)
        {
            return Situacoes.FirstOrDefault(s => s.Codigo == codigo) ?? throw new InvalidCastException("valor invalido para situacao venda");
        }
    }

    public class VendaAberta : VendaSituacao
    {
        public VendaAberta() : base(0, nameof(VendaAberta)) { }

        public override void Abrir(Venda venda) =>
            throw new InvalidOperationException(VendaJaEstaAbertaMensagem);

        public override void Cancelar(Venda venda) =>
            venda.Situacao = VendaSituacao.Cancelada;

        public override void Concluir(Venda venda) =>
            venda.Situacao = VendaSituacao.Concluida;

        public override bool PodeExcluir(Venda venda) => true;
    }

    public class VendaConcluida : VendaSituacao
    {
        public VendaConcluida() : base(1, nameof(VendaConcluida)) { }

        public override void Abrir(Venda venda) =>
            venda.Situacao = VendaSituacao.Aberta;

        public override void Cancelar(Venda venda) => 
            throw new InvalidOperationException(VendaJaEstaConcluida);

        public override void Concluir(Venda venda) =>
            throw new InvalidOperationException(VendaJaEstaConcluida);
    }

    public class VendaCancelada : VendaSituacao
    {
        public VendaCancelada() : base(2, nameof(VendaCancelada)) { }

        public override void Abrir(Venda venda) =>
            venda.Situacao = VendaSituacao.Aberta;

        public override void Cancelar(Venda venda) =>
            throw new InvalidOperationException(VendaJaEstaCancelada);

        public override void Concluir(Venda venda) =>
            throw new InvalidOperationException(VendaJaEstaCancelada);
    }
}
