using System;
using FluentValidation;
using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.Repositories;

namespace LojaOnlineFLF.Services
{
    ///<summary>
    /// Validacoes dos itens da venda
    ///</summary>
    internal class VendaItemValidator : AbstractValidator<VendaItem>
    {
        private const string VendaInvalidaMensagem = "registro de venda invalido";
        private const string ProdutoInvalidoMensagem = "registro de produto invalido";

        ///<summary>
        /// Construtor padrao
        ///</summary>
        public VendaItemValidator(
            IProdutosRepository produtosRepository)
        {
            this.RuleFor(x => x.ProdutoId)
                .NotNull()
                .NotEqual(Guid.Empty)
                .WithMessage(ProdutoInvalidoMensagem)
                .MustAsync((x, c) => produtosRepository.ContemAsync(x))
                .WithMessage(ProdutoInvalidoMensagem);

            this.RuleFor(x => x.Quantidade)
                .NotNull()
                .GreaterThanOrEqualTo(0);
        }
    }
}