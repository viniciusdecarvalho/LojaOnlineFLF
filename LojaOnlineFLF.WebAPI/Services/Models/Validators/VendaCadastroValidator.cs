using System;
using FluentValidation;
using LojaOnlineFLF.DataModel;

namespace LojaOnlineFLF.WebAPI.Services.Models
{
    ///<summary>
    /// Validacoes da venda
    ///</summary>
    public class VendaCadastroValidator : AbstractValidator<VendaCadastroTO>
    {
        ///<summary>
        /// Construtor padrao
        ///</summary>
        public VendaCadastroValidator(
            IFuncionariosService funcionariosService
            )
        {
            const string FuncionarioInvalidoMensagem = "funcionario invalido";
            this.RuleFor(x => x.FuncionarioId)
                .NotNull()
                .MustAsync((x, c) => funcionariosService.ContemAsync(x))
                .WithMessage(FuncionarioInvalidoMensagem);

            this.RuleFor(x => x.Cliente)
                .ChildRules(c => c.RuleFor(x => x.Cpf)
                                  .DeveRespeitarFormatacaoCpf());
        }
    }
}