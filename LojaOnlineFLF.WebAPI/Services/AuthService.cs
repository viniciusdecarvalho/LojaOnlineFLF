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
            /*
            //cria token (header + payload >> direitos + signature)
            var direitos = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, afirmacao.Usuario),
                new Claim(JwtRegisteredClaimNames.Jti, afirmacao.Key)
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKey));
            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                claims: direitos,
                signingCredentials: credenciais,
                expires: DateTime.Now.AddHours(8)
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
            */

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
