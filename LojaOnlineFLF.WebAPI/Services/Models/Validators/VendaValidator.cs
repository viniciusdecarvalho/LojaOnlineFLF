using System;
using FluentValidation;

namespace LojaOnlineFLF.WebAPI.Services.Models
{
    ///<summary>
    /// Validacoes da venda
    ///</summary>
    internal class VendaValidator : AbstractValidator<VendaTO>
    {
        private const string ProdutoInvalidoMensagem = "produto invalido";
        private const string VendaInvalidoMensagem = "venda invalido";

        ///<summary>
        /// Construtor padrao
        ///</summary>
        public VendaValidator(
            IValidator<VendaTO.ItemTO> validatorVendaItem)
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
            ///<summary>
            /// Construtor padrao
            ///</summary>
            public ItemValidator(IProdutosService produtosService)
            {
                this.RuleFor(x => x.ProdutoId)
                    .NotNull()
                    .MustAsync((x, c) => produtosService.ContemAsync(x))
                    .WithMessage(ProdutoInvalidoMensagem);

                this.RuleFor(x => x.Quantidade)
                    .NotNull()
                    .GreaterThanOrEqualTo(0);
            }
        }

        ///<summary>
        /// Validacoes dos itens da venda
        ///</summary>
        public class IdentificadorProdutoValidator : AbstractValidator<IdentificadorProdutoTO>
        {
            ///<summary>
            /// Construtor padrao
            ///</summary>
            public IdentificadorProdutoValidator(
                IProdutosService produtosService,
                IVendasService vendasService)
            {
                this.RuleFor(x => x.Id)
                    .NotNull()
                    .NotEmpty()
                    .MustAsync((x, c) => vendasService.ContemAsync(x))
                    .WithMessage(VendaInvalidoMensagem);

                this.RuleFor(x => x.CodigoBarras)
                    .NotNull()
                    .NotEmpty()
                    .MustAsync((x, c) => produtosService.ContemCodigoBarrasAsync(x))
                    .WithMessage(ProdutoInvalidoMensagem);

                this.RuleFor(x => x.Quantidade)
                    .NotNull()
                    .GreaterThanOrEqualTo(0);
            }
        }
    }
}