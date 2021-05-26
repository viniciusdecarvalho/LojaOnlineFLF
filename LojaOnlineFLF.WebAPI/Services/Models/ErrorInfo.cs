using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LojaOnlineFLF.WebAPI.Services.Models
{
    [ResultName("Error")]
    public class ErrorInfoTO
    {
        public string Info { get; set; }

        public string Detalhes { get; set; }
    }
}