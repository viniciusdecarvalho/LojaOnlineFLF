using System;
using System.Text.Json.Serialization;
using FluentValidation;
using LojaOnlineFLF.Repositories;

namespace LojaOnlineFLF.Services
{
    ///<summary>
    /// Validacoes do funcionario
    ///</summary>
    internal class FuncionarioValidator : AbstractValidator<FuncionarioCadastro>
    {
        ///<summary>
        /// Construtor padrao
        ///</summary>
        public FuncionarioValidator(ICargos cargos)
        {
            if (cargos is null)
            {
                throw new ArgumentNullException(nameof(cargos));
            }

            this.RuleFor(x => x.Nome)
                .Length(5, 50);

            this.RuleFor(x => x.Cpf)
                .NotEmpty()
                .NotNull()
                .DeveRespeitarFormatacaoCpf();

            this.RuleFor(x => x.Cargo)
                .NotEmpty()
                .NotNull()
                .Must((f, c) => cargos.IsValid(c))
                .WithMessage($"invalido. possiveis: [{cargos}]");

            this.RuleFor(x => x.DataInicio)
                .NotNull();

            this.RuleFor(x => x.DataFim)
                .Must((f, df) => !df.HasValue || ( df.HasValue && df >= f.DataInicio))
                .WithMessage("'DataFim' deve ser posterior a 'DataInicio'");            
        }
    }
}