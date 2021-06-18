using System;
using FluentValidation;
using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.Repositories;

namespace LojaOnlineFLF.Services
{
    ///<summary>
    /// Validacoes da venda
    ///</summary>
    internal class VendaValidator : AbstractValidator<Venda>
    {
        private const string ProdutoInvalidoMensagem = "produto invalido";

        ///<summary>
        /// Construtor padrao
        ///</summary>
        public VendaValidator(
            IValidator<Venda.ItemTO> validatorVendaItem)
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
        internal class ItemValidator : AbstractValidator<Venda.ItemTO>
        {
            ///<summary>
            /// Construtor padrao
            ///</summary>
            public ItemValidator(IProdutosRepository produtosRepository)
            {
                this.RuleFor(x => x.ProdutoId)
                    .NotNull()
                    .MustAsync((x, c) => produtosRepository.ContemAsync(x))
                    .WithMessage(ProdutoInvalidoMensagem);

                this.RuleFor(x => x.Quantidade)
                    .NotNull()
                    .GreaterThanOrEqualTo(0);
            }
        }
    }
}