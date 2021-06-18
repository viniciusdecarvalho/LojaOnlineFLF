using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaOnlineFLF.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITokenEncriptService : IService
    {
        SigningCredentials GetCredentials();
    }
}
