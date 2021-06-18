using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaOnlineFLF.Services
{
    internal class FuncionarioValidators : IFuncionarioValidators
    {
        private readonly IValidator<FuncionarioCadastro> funcionarioValidator;

        public FuncionarioValidators(IValidator<FuncionarioCadastro> funcionarioValidator)
        {
            this.funcionarioValidator = funcionarioValidator;
        }

        public Task ValidateAndThrowAsync(FuncionarioCadastro funcionario)
        {
            return this.funcionarioValidator.ValidateAndThrowAsync(funcionario);
        }
    }
}
