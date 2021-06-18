using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;

namespace LojaOnlineFLF.Services
{
    internal class AuthService: IAuthService
    {
        private readonly IRefreshTokenService refreshTokenManager;
        private readonly SigningCredentials signingCredentials;

        public AuthService(
            IRefreshTokenService refreshTokenManager,
            SigningCredentials signingCredentials)
        {
            this.refreshTokenManager = refreshTokenManager;
            this.signingCredentials = signingCredentials;
        }

        public Autenticacao Autenticar(Afirmacao afirmacao)
        {
            try
            {
                DateTime dataCriacao = DateTime.UtcNow;
                DateTime expiracao = dataCriacao.AddHours(2);

                var tokenHandler = new JwtSecurityTokenHandler();

                ClaimsIdentity subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Name, afirmacao.Usuario),
                    new Claim(JwtRegisteredClaimNames.UniqueName, afirmacao.Regra),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                });

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    SigningCredentials = signingCredentials,
                    Subject = subject,
                    Expires = expiracao,
                    NotBefore = dataCriacao
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                string tokenString = tokenHandler.WriteToken(token);

                RefreshToken refreshToken = this.refreshTokenManager.Create(afirmacao.Usuario);

                Autenticacao autenticacao = new Autenticacao
                {
                    Usuario = afirmacao.Usuario,
                    DataCriacao = dataCriacao,
                    DataExpiracao = expiracao,
                    Token = tokenString,
                    RefreshToken = refreshToken.Token
                };

                this.refreshTokenManager.Save(refreshToken);

                return autenticacao;
            }
            catch(Exception e)
            {
                throw new ServiceException("falha ao tentar gerar informacoes de autenticacao", e);
            }
        }
    }
}
