using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaOnlineFLF.Services
{
    internal class ProdutoValidators : IProdutoValidators
    {
        private readonly IValidator<ProdutoCadastro> produtoCadastroValidator;
        private readonly IValidator<Produto> produtoValidator;

        public ProdutoValidators(
            IValidator<ProdutoCadastro> produtoCadastroValidator,
            IValidator<Produto> produtoValidator)
        {
            this.produtoCadastroValidator = produtoCadastroValidator;
            this.produtoValidator = produtoValidator;
        }

        public Task ValidateAndThrowAsync(ProdutoCadastro produto)
        {
            return this.produtoCadastroValidator.ValidateAndThrowAsync(produto);
        }

        public Task ValidateAndThrowAsync(Produto produto)
        {
            return this.produtoValidator.ValidateAndThrowAsync(produto);
        }
    }
}
