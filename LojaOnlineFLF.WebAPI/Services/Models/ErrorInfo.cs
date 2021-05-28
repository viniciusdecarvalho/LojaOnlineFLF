using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LojaOnlineFLF.WebAPI.Services.Models
{
    [ResultName("Error")]
    public class ErrorInfoTO
    {
        ///<summary>
        /// Mensagem de erro
        ///</summary>
        public string Info { get; set; }

        ///<summary>
        /// Detalhes do erro, StackTrace
        ///</summary>
        public string Detalhes { get; set; }
    }
}