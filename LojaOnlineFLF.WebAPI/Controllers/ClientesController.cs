using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LojaOnlineFLF.WebAPI.Services;
using LojaOnlineFLF.WebAPI.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LojaOnlineFLF.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Consumes(K.MediaTypes.AplicationJson)]
    [Produces(K.MediaTypes.AplicationJson)]
    [Route("api/clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> logger;
        private readonly IClientesService clientesService;

        ///<summary>
        /// Construtor padrao
        ///</summary>
        public ClientesController(
            ILogger<ClientesController> logger,
            IClientesService clientesService)
        {
            this.logger = logger;
            this.clientesService = clientesService;
        }

        /// <summary>
        /// Recuperar cliente por {id}
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClienteTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterClientesPorId([FromRoute] Guid id)
        {
            ClienteTO cliente = await this.clientesService.ObterPorIdAsync(id);

            if (cliente is null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        /// <summary>
        /// Recuperar cliente por {cpf}
        /// </summary>
        [HttpGet("cpf/{cpf}")]
        [ProducesResponseType(typeof(ClienteTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterClientesPorCpf([FromRoute] string cpf)
        {
            ClienteTO cliente = await this.clientesService.ObterPorCpfAsync(cpf);

            if (cliente is null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        /// <summary>
        /// Adicionar cliente
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ClienteTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AdicionarProduto([FromBody] ClienteTO cliente)
        {
            ClienteTO novoCliente = await this.clientesService.AdicionarAsync(cliente);

            return Created($"api/clientes/{novoCliente.Id}", novoCliente);
        }

        /// <summary>
        /// Atualizar cliente por {id}
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ClienteTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AtualizarCliente([FromRoute] Guid id, [FromBody] ClienteTO cliente)
        {
            await this.clientesService.AtualizarAsync(cliente);

            return Ok(cliente);
        }

        /// <summary>
        /// Remover cliente por {id}
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoverCliente([FromRoute] Guid id)
        {
            ClienteTO cliente = await this.clientesService.ObterPorIdAsync(id);

            if (cliente is null)
            {
                return NotFound();
            }

            await this.clientesService.RemoverAsync(cliente);

            return NoContent();
        }
    }
}