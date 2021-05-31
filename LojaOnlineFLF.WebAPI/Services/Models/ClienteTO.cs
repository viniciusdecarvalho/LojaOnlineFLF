using System;
using LojaOnlineFLF.WebAPI.Services.Models;

namespace LojaOnlineFLF.WebAPI.Services.Models
{
    [ResultName("Cliente")]
    public class ClienteTO
    {
        public Guid? Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Fone { get; set; }
    }
}