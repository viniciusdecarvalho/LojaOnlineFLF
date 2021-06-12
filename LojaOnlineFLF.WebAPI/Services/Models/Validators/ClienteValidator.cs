using FluentValidation;

namespace LojaOnlineFLF.WebAPI.Services.Models
{
    ///<summary>
    /// Validacoes do funcionario
    ///</summary>
    internal class ClienteValidator : AbstractValidator<ClienteTO>
    {
        ///<summary>
        /// Construtor padrao
        ///</summary>
        public ClienteValidator()
        {
            this.RuleFor(x => x.Nome)
                .Length(3, 255);
                        
            this.RuleFor(x => x.Cpf)
                .NotNull()
                .NotEmpty()
                .DeveRespeitarFormatacaoCpf();
        }
    }
}