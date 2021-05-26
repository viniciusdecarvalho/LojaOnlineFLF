using System;
using System.Text.Json.Serialization;
using FluentValidation;

namespace LojaOnlineFLF.WebAPI.Services.Models
{
    ///<summary>
    /// Validacoes do funcionario
    ///</summary>
    public class FuncionarioValidator : AbstractValidator<FuncionarioTO>
    {
        ///<summary>
        /// Construtor padrao
        ///</summary>
        public FuncionarioValidator()
        {
            this.RuleFor(x => x.Nome)
                .Length(5, 50)
                .WithMessage("Nome deve ter de 5 a 50 caracteres");

            this.RuleFor(x => x.Cpf)
                .NotEmpty().Matches("")
                .WithMessage("CPF invalido");

            this.RuleFor(x => x.DataInicio)
                .NotEmpty()
                .WithMessage("DataInicio obrigatorio");

            this.RuleFor(x => x.DataFim)
                .Must((f, df) => !df.HasValue || ( df.HasValue && df >= f.DataInicio))
                .WithMessage("DataFim deve ser posterior a DataInicio");
        }
    }
}