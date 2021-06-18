using FluentValidation;

namespace LojaOnlineFLF.Services
{
    ///<summary>
    /// Validacoes do funcionario
    ///</summary>
    internal class ClienteValidator : AbstractValidator<ClienteCadastro>
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