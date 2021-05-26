namespace LojaOnlineFLF.WebAPI.Services.Models
{
    public class AfirmacaoTO
    {
        public AfirmacaoTO(string usuario, string regra)
        {
            Usuario = usuario;
            Regra = regra;
        }

        public string Usuario { get; }
        public string Regra { get; }
    }
}