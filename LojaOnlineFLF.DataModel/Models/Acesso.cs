using System;
using Microsoft.AspNetCore.Identity;

namespace LojaOnlineFLF.DataModel.Models
{
    ///<summary>
    /// Usuario para acesso
    ///</summary>
    public partial class Acesso: IdentityUser
    {
        public Funcionario Funcionario { get; set; }
    }
}
