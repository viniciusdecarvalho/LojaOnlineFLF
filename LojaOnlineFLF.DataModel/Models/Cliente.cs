using System;
namespace LojaOnlineFLF.DataModel.Models
{
    public class Cliente
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Fone { get; set; }
    }
}
