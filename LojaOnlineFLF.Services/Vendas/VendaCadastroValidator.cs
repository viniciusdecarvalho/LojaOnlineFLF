using System;
using FluentValidation;
using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.Repositories;

namespace LojaOnlineFLF.Services
{
    ///<summary>
    /// Validacoes da venda
    ///</summary>
    internal class VendaCadastroValidator : AbstractValidator<VendaCadastro>
    {
        ///<summary>
        /// Construtor padrao
        ///</summary>
        public VendaCadastroValidator(
            IFuncionariosRepository funcionariosRepository
            )
        {
            const string FuncionarioInvalidoMensagem = "funcionario invalido";
            this.RuleFor(x => x.FuncionarioId)
                .NotNull()
                .MustAsync((x, c) => funcionariosRepository.ContemAsync(x))
                .WithMessage(FuncionarioInvalidoMensagem);

            this.RuleFor(x => x.Cliente)
                .ChildRules(c => c.RuleFor(x => x.Cpf)
                                  .DeveRespeitarFormatacaoCpf());
        }
    }
}