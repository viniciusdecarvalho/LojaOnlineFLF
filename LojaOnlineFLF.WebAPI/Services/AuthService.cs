using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LojaOnlineFLF.WebAPI.Services.Models;
using Microsoft.IdentityModel.Tokens;

namespace LojaOnlineFLF.WebAPI.Services
{
    public class AuthService: IAuthService
    {
        public AuthService()
        {
        }

        public string ObterToken(AfirmacaoTO afirmacao)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(K.Auth.SecurityKey);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = credentials,
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, afirmacao.Usuario),
                    new Claim(ClaimTypes.Role, afirmacao.Regra)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
