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
        public Autenticacao Autenticar(AfirmacaoTO afirmacao)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(K.Auth.SecurityKey);
                var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

                ClaimsIdentity subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Name, afirmacao.Usuario),
                    new Claim(JwtRegisteredClaimNames.Jti, afirmacao.Regra)
                });

                DateTime dataCriacao = DateTime.UtcNow;
                DateTime expiracao = dataCriacao.AddHours(2);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    SigningCredentials = credentials,
                    Subject = subject,
                    Expires = expiracao,
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                string tokenString = tokenHandler.WriteToken(token);

                Autenticacao autenticacao = new Autenticacao
                {
                    Usuario = afirmacao.Usuario,
                    DataCriacao = dataCriacao,
                    DataExpiracao = expiracao,
                    Token = tokenString
                };

                return autenticacao;
            }
            catch(Exception e)
            {
                throw new ServiceException("falha ao tentar gerar informacoes de autenticacao", e);
            }
        }
    }
}
