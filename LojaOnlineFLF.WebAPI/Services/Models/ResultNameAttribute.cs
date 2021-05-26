using System;
namespace LojaOnlineFLF.WebAPI.Services.Models
{
    [AttributeUsage(AttributeTargets.All)]
    public class ResultNameAttribute: Attribute
    {
        public ResultNameAttribute(string nameAs)
        {
            NameAs = nameAs;
        }

        public string NameAs { get; }
    }
}
