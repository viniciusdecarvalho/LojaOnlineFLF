using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaOnlineFLF.Services
{
    internal class ClienteValidators: IClienteValidators
    {
        private readonly IValidator<ClienteCadastro> clienteValidator;

        public ClienteValidators(IValidator<ClienteCadastro> clienteValidator)
        {
            this.clienteValidator = clienteValidator;
        }

        public Task ValidateAndThrowAsync(ClienteCadastro cliente)
        {
            return this.clienteValidator.ValidateAndThrowAsync(cliente);
        }
    }
}
