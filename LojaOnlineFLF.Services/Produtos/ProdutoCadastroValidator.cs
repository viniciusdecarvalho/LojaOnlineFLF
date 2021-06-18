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
    internal class ProdutoCadastroValidator : AbstractValidator<ProdutoCadastro>
    {
        private const string CodigoBarrasExistenteMensagem = "produto com codigo de barras informado ja existe";

        private readonly IProdutosRepository produtosRepository;

        ///<summary>
        /// Construtor padrao
        ///</summary>
        public ProdutoCadastroValidator(
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
                .MustAsync(NaoDeveExistirCodigoBarrasJaCadastradoAsync)
                .WithMessage(CodigoBarrasExistenteMensagem);
        }

        private async Task<bool> NaoDeveExistirCodigoBarrasJaCadastradoAsync(string codigoBarras, CancellationToken token)
        {
            bool contem = await this.produtosRepository.ContemCodigoBarrasAsync(codigoBarras);

            return await Task.FromResult(!contem);
        }
    }
}