using System;
using FluentValidation;

namespace LojaOnlineFLF.WebAPI.Services.Models
{
    public static class RuleValidatorExtensions
    {
        public static IRuleBuilderOptions<T, string>
           DeveRespeitarFormatacaoCpf<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return
                ruleBuilder
                    .Matches(@"^\d{3}\.\d{3}\.\d{3}\-\d{2}$")                    
                    .WithMessage("'Cpf' informado nao esta no padrao [000.000.000-00]");
        }
    }
}
