using FluentValidation;

namespace LojaOnlineFLF.Services
{
    internal class PaginacaoValidator : AbstractValidator<IPageParameters>
    {
        public PaginacaoValidator()
        {
            this.RuleFor(x => x.NumeroPagina)
                .LessThanOrEqualTo(0);

            this.RuleFor(x => x.TamanhoPagina)
                .LessThanOrEqualTo(0);
        }
    }
}