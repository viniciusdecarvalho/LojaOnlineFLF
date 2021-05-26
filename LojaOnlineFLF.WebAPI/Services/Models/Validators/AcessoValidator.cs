using System;
using System.Text.Json.Serialization;
using FluentValidation;

namespace LojaOnlineFLF.WebAPI.Services.Models
{
    ///<summary>
    /// Validacoes do funcionario
    ///</summary>
    public class AcessoValidator : AbstractValidator<Login>
    {
        ///<summary>
        /// Construtor padrao
        ///</summary>
        public AcessoValidator()
        {
            this.RuleFor(x => x.Usuario)
                .NotNull()
                .NotEmpty()
                .WithMessage("Usuario nao informado");

            this.RuleFor(x => x.Senha)
                .NotNull()
                .NotEmpty()
                .WithMessage("Senha nao informada");
        }
    }
}