namespace LojaOnlineFLF.WebAPI.Services.Models
{
    [ResultName("AlteracaoLogin")]
    public class LoginAlteracao
    {
        public string Usuario { get; set; }

        public string SenhaAtual { get; set; }

        public string NovaSenha { get; set; }
    }
}