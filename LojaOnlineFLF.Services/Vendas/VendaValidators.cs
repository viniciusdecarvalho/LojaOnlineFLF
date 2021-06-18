using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaOnlineFLF.Services
{
    internal class VendaValidators: IVendaValidators
    {
        private readonly IValidator<VendaCadastro> vendaCadastroToValidator;
        private readonly IValidator<VendaCadastrada> vendaCadastradaToValidator;
        private readonly IValidator<Venda> vendaToValidator;
        private readonly IValidator<VendaItem> vendaItemToValidator;

        public VendaValidators(
            IValidator<VendaCadastro> vendaCadastroToValidator,
            IValidator<VendaCadastrada> vendaCadastradaToValidator,
            IValidator<Venda> vendaToValidator,
            IValidator<VendaItem> vendaItemToValidator
            )
        {
            this.vendaCadastroToValidator = vendaCadastroToValidator;
            this.vendaCadastradaToValidator = vendaCadastradaToValidator;
            this.vendaToValidator = vendaToValidator;
            this.vendaItemToValidator = vendaItemToValidator;
        }

        public Task ValidateAndThrowAsync(VendaCadastro venda) => 
            this.vendaCadastroToValidator.ValidateAndThrowAsync(venda);

        public Task ValidateAndThrowAsync(VendaCadastrada venda) =>
            this.vendaCadastradaToValidator.ValidateAndThrowAsync(venda);

        public Task ValidateAndThrowAsync(Venda venda) =>
            this.vendaToValidator.ValidateAndThrowAsync(venda);

        public Task ValidateAndThrowAsync(params VendaItem[] items)
        {
            var validations = items.SelectMany(v => this.vendaItemToValidator.Validate(v).Errors).ToList();

            if(validations.Any())
            {
                throw new ValidationException("erros de validacao", validations);
            }

            return Task.CompletedTask;
        }
    }
}
