using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.Repositories;

namespace LojaOnlineFLF.Services
{
    ///<summary>
    /// Validacoes do produto para novo cadastro
    ///</summary>
    internal class ProdutoValidator : AbstractValidator<Produto>
    {
        private const string CodigoBarrasExistenteMensagem = "produto com codigo de barras informado ja existe";
        private readonly IProdutosRepository produtosRepository;

        ///<summary>
        /// Construtor padrao
        ///</summary>
        public ProdutoValidator(
            IProdutosRepository produtosRepository
            )
        {
            this.produtosRepository = produtosRepository;

            this.RuleFor(x => x.Nome)
                .Length(5, 50);

            this.RuleFor(x => x.Preco)
                .NotNull()
                .GreaterThan(decimal.Zero);

            this.RuleFor(x => x.CodBarras)
                .MustAsync(NaoDeveExistirCodigoBarrasJaCadastradoAsync())
                .WithMessage(CodigoBarrasExistenteMensagem);
        }

        private Func<Produto, string, CancellationToken, Task<bool>> NaoDeveExistirCodigoBarrasJaCadastradoAsync()
        {
            return async (x, c, a) =>
            {
                var produtoPorId = await produtosRepository.ObterAsync(x.Id);
                var produtoPorCodigoBarras = await produtosRepository.ObterPorCodigoDeBarrasAsync(c);

                return produtoPorId.Equals(produtoPorCodigoBarras);
            };
        }
    }
}