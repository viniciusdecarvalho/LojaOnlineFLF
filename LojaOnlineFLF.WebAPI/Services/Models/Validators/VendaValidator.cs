using System;
using FluentValidation;

namespace LojaOnlineFLF.WebAPI.Services.Models
{
    ///<summary>
    /// Validacoes da venda
    ///</summary>
    public class VendaValidator : AbstractValidator<VendaTO>
    {
        ///<summary>
        /// Construtor padrao
        ///</summary>
        public VendaValidator(IValidator<VendaTO.ItemTO> validatorVendaItem)
        {
            this.RuleFor(x => x.Data)
                .GreaterThanOrEqualTo(DateTime.Now.Date);

            this.RuleFor(x => x.FuncionarioId)
                .NotNull();

            this.RuleForEach(x => x.Itens)
                .SetValidator(validatorVendaItem);
        }

        ///<summary>
        /// Validacoes dos itens da venda
        ///</summary>
        public class ItemValidator : AbstractValidator<VendaTO.ItemTO>
        {
            private const string ProdutoInvalidoMensagem = "produto invalido";

            ///<summary>
            /// Construtor padrao
            ///</summary>
            public ItemValidator(IProdutosService produtosService)
            {
                this.RuleFor(x => x.ProdutoId)
                    .NotNull()
                    .MustAsync(async (x, c) => await produtosService.ContemAsync(x.GetValueOrDefault(Guid.Empty)))
                    .WithMessage(ProdutoInvalidoMensagem);

                this.RuleFor(x => x.Quantidade)
                    .NotNull()
                    .GreaterThanOrEqualTo(0);
            }
        }
    }
}