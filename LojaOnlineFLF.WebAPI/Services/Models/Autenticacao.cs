using System;
namespace LojaOnlineFLF.WebAPI.Services.Models
{
    public class Autenticacao
    {
        public string Usuario { get; set; }

        public string Token { get; set; }
        public DateTime DataExpiracao { get; internal set; }
        public DateTime DataCriacao { get; internal set; }
    }
}
