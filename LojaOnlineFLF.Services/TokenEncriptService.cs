using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaOnlineFLF.Services
{
    internal class TokenEncriptService : ITokenEncriptService
    {
        private readonly SigningCredentials signingCredentials;

        public TokenEncriptService(SigningCredentials signingCredentials)
        {
            this.signingCredentials = signingCredentials;
        }

        public SigningCredentials GetCredentials()
        {
            return signingCredentials;
        }
    }
}
