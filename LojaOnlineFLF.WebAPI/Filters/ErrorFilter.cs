using System;
using LojaOnlineFLF.WebAPI.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LojaOnlineFLF.WebAPI.Filters
{
    ///<summary>
    /// Controle de transacoes
    ///</summary>
    public class ErrorFilter : ExceptionFilterAttribute
    {
        ///<summary>
        /// Construtor padrao
        ///</summary>
        public ErrorFilter()
        {
        }

        ///<summary>
        /// Identificar excecoes nao tratadas e gerar retorno padrao
        ///</summary>
        public override void OnException(ExceptionContext context)
        {
            var result = new BadRequestObjectResult(new ErrorInfoTO {
                Info = context.Exception.Message,
                Detalhes = context.Exception.ToString()
            });

            context.Result = result;
        }
    }
}