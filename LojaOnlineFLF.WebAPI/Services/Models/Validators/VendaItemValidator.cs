using System;
using FluentValidation;

namespace LojaOnlineFLF.WebAPI.Services.Models
{
    ///<summary>
    /// Validacoes dos itens da venda
    ///</summary>
    public class VendaItemValidator : AbstractValidator<VendaItemTO>
    {
        private const string VendaInvalidaMensagem = "registro de venda invalido";
        private const string ProdutoInvalidoMensagem = "registro de produto invalido";

        ///<summary>
        /// Construtor padrao
        ///</summary>
        public VendaItemValidator(
            IVendasService vendasService,
            IProdutosService produtosService)
        {
            this.RuleFor(x => x.VendaId)
                .NotNull()
                .NotEqual(Guid.Empty)
                .WithMessage(VendaInvalidaMensagem)
                .MustAsync(async (x, c) => {
                    return await vendasService.ObterPorIdAsync(x.GetValueOrDefault(Guid.Empty)) != null;
                })
                .WithMessage(VendaInvalidaMensagem);

            this.RuleFor(x => x.ProdutoId)
                .NotNull()
                .NotEqual(Guid.Empty)
                .WithMessage(ProdutoInvalidoMensagem)
                .MustAsync(async (x, c) => {
                    return await produtosService.ObterPorIdAsync(x.GetValueOrDefault(Guid.Empty)) != null;
                })
                .WithMessage(ProdutoInvalidoMensagem);

            this.RuleFor(x => x.Quantidade)
                .NotNull()
                .GreaterThanOrEqualTo(0);
        }
    }
}