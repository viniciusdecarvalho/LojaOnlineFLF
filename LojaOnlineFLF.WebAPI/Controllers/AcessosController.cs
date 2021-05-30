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
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> ValidarAcesso(Login acesso)
        {
            FuncionarioTO funcionario = await this.acessosService.ValidarAcessoAsync(acesso);

            if (funcionario is null)
            {
                return Unauthorized();
            }

            string token =
                this.authService.ObterToken(new AfirmacaoTO(acesso.Usuario, funcionario.Id.ToString()));

            return Ok(token);
        }
    }
}
