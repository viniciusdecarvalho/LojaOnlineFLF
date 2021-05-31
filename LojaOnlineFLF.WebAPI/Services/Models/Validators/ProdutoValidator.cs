using FluentValidation;

namespace LojaOnlineFLF.WebAPI.Services.Models
{
    ///<summary>
    /// Validacoes do funcionario
    ///</summary>
    public class ProdutoValidator : AbstractValidator<ProdutoTO>
    {
        ///<summary>
        /// Construtor padrao
        ///</summary>
        public ProdutoValidator()
        {
            this.RuleFor(x => x.Nome)
                .Length(5, 50);
                        
            this.RuleFor(x => x.Preco)
                .NotNull()
                .GreaterThan(decimal.Zero);
        }
    }
}