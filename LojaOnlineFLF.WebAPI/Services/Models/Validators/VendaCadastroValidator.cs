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
            IFuncionariosService funcionariosService,
            IClientesService clientesService
            )
        {
            const string FuncionarioInvalidoMensagem = "funcionario invalido";
            this.RuleFor(x => x.FuncionarioId)
                .NotNull()
                .MustAsync(async (x, c) => await funcionariosService.ContemAsync(x.GetValueOrDefault(Guid.Empty)))
                .WithMessage(FuncionarioInvalidoMensagem);

            this.RuleFor(x => x.ClienteId)
                .MustAsync(async (x, c) =>
                {
                    if (x == null)
                        return true;

                    return await clientesService.ContemAsync(x.GetValueOrDefault(Guid.Empty));
                })
                .WithMessage(FuncionarioInvalidoMensagem);
        }
    }
}