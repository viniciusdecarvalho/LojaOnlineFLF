using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.WebAPI.Services;
using LojaOnlineFLF.WebAPI.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LojaOnlineFLF.WebAPI.Controllers
{
    ///<summary>
    /// Recursos de funcionarios
    ///</summary>
    [Authorize]
    [ApiController]
    [Consumes(K.MediaTypes.AplicationJson)]
    [Produces(K.MediaTypes.AplicationJson)]
    [Route(Rota)]
    public sealed class FuncionariosController : ControllerBase
    {
        public const string Rota = "api/funcionarios";

        private readonly ILogger<FuncionariosController> _logger;
        private readonly IAcessosService acessosService;
        private readonly IFuncionariosService funcionariosService;

        ///<summary>
        /// Construtor padrao
        ///</summary>
        public FuncionariosController(
            ILogger<FuncionariosController> logger,
            IAcessosService acessosService,
            IFuncionariosService funcionariosService)
        {
            _logger = logger;
            this.acessosService = acessosService;
            this.funcionariosService = funcionariosService;
        }

        /// <summary>
        /// Recuperar todos os funcionarios
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResource<FuncionarioTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ObterFuncionarios([FromQuery] Paginacao paginacao)
        {
            IPagedList<FuncionarioTO> funcionarios = await this.funcionariosService.ObterTodosAsync(paginacao);

            var page = new PagedResource<FuncionarioTO>(funcionarios, paginacao, Rota);

            return Ok(page);
        }
        
        /// <summary>
        /// Recuperar funcionario por {id}
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FuncionarioTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterFuncionarioPorId([FromRoute] Guid id)
        {
            FuncionarioTO funcionario = await this.funcionariosService.ObterPorIdAsync(id);

            if (funcionario is null)
            {
                return NotFound();
            }

            return Ok(funcionario);
        }

        /// <summary>
        /// Adicionar funcionario
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(FuncionarioTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AdicionarFuncionario([FromBody] FuncionarioTO funcionario)
        {
            FuncionarioTO novoFuncionario = await this.funcionariosService.AdicionarAsync(funcionario);

            return Created($"api/funcionarios/{novoFuncionario.Id}", novoFuncionario);
        }

        /// <summary>
        /// Atualizar funcionario por {id}
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(FuncionarioTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AtualizarFuncionario([FromRoute]Guid id, [FromBody] FuncionarioTO funcionario)
        {       
            await this.funcionariosService.AtualizarAsync(funcionario);

            return Ok(funcionario);
        }

        /// <summary>
        /// Remover funcionario por {id}
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoverFuncionario([FromRoute] Guid id)
        {
            FuncionarioTO funcionario = await this.funcionariosService.ObterPorIdAsync(id);

            if (funcionario is null)
            {
                return NotFound();
            }

            await this.funcionariosService.RemoverAsync(id);

            return NoContent();
        }

        /// <summary>
        /// Configurar parametros para acesso do funcionario
        /// </summary>
        [HttpPost("{id}/acesso")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AdicionarAcesso([FromRoute] Guid id, [FromBody] Login acesso)
        {
            FuncionarioTO funcionario = await this.funcionariosService.ObterPorIdAsync(id);

            if (funcionario is null)
            {
                return NotFound();
            }

            await this.acessosService.IncluirAcessoAsync(funcionario, acesso);

            return NoContent();
        }

        /// <summary>
        /// Configurar parametros para alteracao do acesso do funcionario
        /// </summary>
        [HttpPut("{id}/acesso")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AlterarAcesso([FromRoute] Guid id, [FromBody] LoginAlteracao acesso)
        {
            FuncionarioTO funcionario = await this.funcionariosService.ObterPorIdAsync(id);
            
            if (funcionario is null)
            {
                return NotFound();
            }

            await this.acessosService.AlterarAcessoAsync(funcionario, acesso);

            return NoContent();
        }
    }
}
