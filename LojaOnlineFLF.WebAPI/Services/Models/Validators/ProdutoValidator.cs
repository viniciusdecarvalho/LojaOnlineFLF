using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;

namespace LojaOnlineFLF.WebAPI.Services.Models
{
    ///<summary>
    /// Validacoes do produto para novo cadastro
    ///</summary>
    internal class ProdutoCadastroValidator : AbstractValidator<ProdutoCadastroTO>
    {
        private const string CodigoBarrasExistenteMensagem = "produto com codigo de barras informado ja existe";

        private readonly IProdutosService produtosService;

        ///<summary>
        /// Construtor padrao
        ///</summary>
        public ProdutoCadastroValidator(
            IProdutosService produtosService
            )
        {
            this.produtosService = produtosService;

            this.RuleFor(x => x.Nome)
                .Length(5, 50);

            this.RuleFor(x => x.Preco)
                .NotNull()
                .GreaterThan(decimal.Zero);

            this.RuleFor(x => x.CodBarras)
                .MustAsync(NaoDeveExistirCodigoBarrasJaCadastradoAsync)
                .WithMessage(CodigoBarrasExistenteMensagem);
        }

        private async Task<bool> NaoDeveExistirCodigoBarrasJaCadastradoAsync(string codigoBarras, CancellationToken token)
        {
            bool contem = await this.produtosService.ContemCodigoBarrasAsync(codigoBarras);

            return await Task.FromResult(!contem);
        }
    }

    ///<summary>
    /// Validacoes do produto para novo cadastro
    ///</summary>
    public class ProdutoValidator : AbstractValidator<ProdutoTO>
    {
        private const string CodigoBarrasExistenteMensagem = "produto com codigo de barras informado ja existe";
        private readonly IProdutosService produtosService;

        ///<summary>
        /// Construtor padrao
        ///</summary>
        public ProdutoValidator(
            IProdutosService produtosService
            )
        {
            this.produtosService = produtosService;

            this.RuleFor(x => x.Nome)
                .Length(5, 50);

            this.RuleFor(x => x.Preco)
                .NotNull()
                .GreaterThan(decimal.Zero);

            this.RuleFor(x => x.CodBarras)
                .MustAsync(NaoDeveExistirCodigoBarrasJaCadastradoAsync())
                .WithMessage(CodigoBarrasExistenteMensagem);
        }

        private Func<ProdutoTO, string, CancellationToken, Task<bool>> NaoDeveExistirCodigoBarrasJaCadastradoAsync()
        {
            return async (x, c, a) =>
            {
                var produtoPorId = await produtosService.ObterPorIdAsync(x.Id);
                var produtoPorCodigoBarras = await produtosService.ObterPorCodigoBarrasAsync(c);

                return produtoPorId.Equals(produtoPorCodigoBarras);
            };
        }
    }
}