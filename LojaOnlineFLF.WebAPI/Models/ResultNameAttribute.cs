using System;
namespace LojaOnlineFLF.WebAPI.Services.Models
{
    /// <summary>
    /// Alterar nome de exibicao na geração da documentacao do Swagger
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class ResultNameAttribute: Attribute
    {
        /// <summary>
        /// Construtor padrao
        /// </summary>
        /// <param name="nameAs"></param>
        public ResultNameAttribute(string nameAs)
        {
            NameAs = nameAs;
        }

        /// <summary>
        /// Nome utilizado para identificar o tipo
        /// </summary>
        public string NameAs { get; }
    }
}
