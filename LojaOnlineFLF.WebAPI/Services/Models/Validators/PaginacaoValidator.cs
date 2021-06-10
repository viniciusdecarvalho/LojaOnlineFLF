using System;
using System.Text.Json.Serialization;
using FluentValidation;

namespace LojaOnlineFLF.WebAPI.Services.Models
{
    ///<summary>
    /// Validacoes do funcionario
    ///</summary>
    public class PaginacaoValidator : AbstractValidator<Paginacao>
    {
        ///<summary>
        /// Construtor padrao
        ///</summary>
        public PaginacaoValidator()
        {
            this.RuleFor(x => x.Current())
                .GreaterThan(0);

            this.RuleFor(x => x.PageSize())
                .GreaterThan(0);
        }
    }
}