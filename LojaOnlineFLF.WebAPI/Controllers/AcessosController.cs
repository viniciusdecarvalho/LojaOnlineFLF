using System.Collections.Generic;
using System.Threading.Tasks;
using LojaOnlineFLF.WebAPI.Services;
using LojaOnlineFLF.WebAPI.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaOnlineFLF.WebAPI.Controllers
{
    /// <summary>
    /// Controle de acesso
    /// </summary>
    [ApiController]
    [AllowAnonymous]
    [Consumes(K.MediaTypes.AplicationJson)]
    [Produces(K.MediaTypes.AplicationJson)]
    [Route("api/login")]
    public class AcessosController: ControllerBase
    {
        private readonly IAcessosService acessosService;
        private readonly IAuthService authService;

        /// <summary>
        /// Construtor padrao
        /// </summary>
        public AcessosController(
            IAcessosService acessosService,
            IAuthService authService)
        {
            this.acessosService = acessosService;
            this.authService = authService;
        }

        /// <summary>
        /// Realizar login, recuperar token de acesso ao servico
        /// </summary>
        /// <remarks>Gerar token para acesso ao restante da api. Incluir token como cabecalho das requisicoes no atributo Authorization, com valor 'Bearer ' seguido do token recuperado</remarks>
        [HttpPost]
        [ProducesResponseType(typeof(Autenticacao), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ValidarAcesso(Login acesso)
        {
            FuncionarioTO funcionario = await this.acessosService.ValidarAcessoAsync(acesso);

            if (funcionario is null)
            {
                return Unauthorized();
            }

            var autenticacao =
                this.authService.Autenticar(new AfirmacaoTO(acesso.Usuario, funcionario.Id.ToString()));            

            return base.Ok(autenticacao);
        }

        /// <summary>
        /// Realizar login, recuperar token de acesso ao servico
        /// </summary>
        /// <remarks>Reautenticar, apos expiracao do token utilizando chave com refresh token</remarks>
        [HttpPost("refresh")]
        [ProducesResponseType(typeof(Autenticacao), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AtualizarTokenAcesso(RefreshToken token)
        {
            FuncionarioTO funcionario = await this.acessosService.ValidarTokenAsync(token);

            if (funcionario is null)
            {
                return BadRequest("token nao validado");
            }

            var autenticacao =
                this.authService.Autenticar(new AfirmacaoTO(token.Usuario, funcionario.Id.ToString()));

            return base.Ok(autenticacao);
        }
    }
}
