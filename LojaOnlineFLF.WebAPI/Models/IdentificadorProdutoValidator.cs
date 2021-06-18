using FluentValidation;
using LojaOnlineFLF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaOnlineFLF.WebAPI.Models
{
    /// <summary>
    /// Validador para Identificador de produtos para uma venda
    /// </summary>
    public class IdentificadorProdutoValidator: AbstractValidator<IdentificadorProdutoTO>
    {
        private const string ProdutoInvalidoMensagem = "produto invalido";
        private const string VendaInvalidoMensagem = "venda invalido";

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
