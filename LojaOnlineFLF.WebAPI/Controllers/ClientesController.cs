using LojaOnlineFLF.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LojaOnlineFLF.WebAPI.Controllers
{
    /// <summary>
    /// Recuros de clientes
    /// </summary>
    [Authorize]
    [ApiController]
    [Consumes(K.MediaTypes.AplicationJson)]
    [Produces(K.MediaTypes.AplicationJson)]
    [Route("api/clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesService clientesService;

        ///<summary>
        /// Construtor padrao
        ///</summary>
        public ClientesController(
            IClientesService clientesService)
        {
            this.clientesService = clientesService;
        }

        /// <summary>
        /// Recuperar cliente por {id}
        /// </summary>
        /// <response code="200">Cliente</response>
        /// <response code="400">Falha na busca</response>
        /// <response code="404">Cliente nao encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Cliente>> ObterClientesPorId([FromRoute] Guid id)
        {
            Cliente cliente = await this.clientesService.ObterPorIdAsync(id);

            if (cliente is null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        /// <summary>
        /// Recuperar cliente por {cpf}
        /// </summary>
        /// <response code="200">Cliente</response>
        /// <response code="400">Falha na busca</response>
        /// <response code="404">Cliente nao encontrado</response>
        [HttpGet("cpf/{cpf}")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Cliente>> ObterClientesPorCpf([FromRoute] string cpf)
        {
            Cliente cliente = await this.clientesService.ObterPorCpfAsync(cpf);

            if (cliente is null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        /// <summary>
        /// Adicionar cliente
        /// </summary>
        /// <response code="201">Cliente adicionado</response>
        /// <response code="400">Falha na busca</response>        
        [HttpPost]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Cliente>> AdicionarCliente([FromBody] ClienteCadastro cliente)
        {
            Cliente novoCliente = await this.clientesService.AdicionarAsync(cliente);

            return Created($"api/clientes/{novoCliente.Id}", novoCliente);
        }

        /// <summary>
        /// Atualizar cliente por {id}
        /// </summary>
        /// <response code="200">Cliente com alteracoes</response>
        /// <response code="400">Falha no processo de atualizacao</response> 
        /// <response code="404">Cliente nao encontrado</response> 
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Cliente>> AtualizarCliente([FromRoute] Guid id, [FromBody] Cliente cliente)
        {
            if (!id.Equals(cliente?.Id))
            {
                return BadRequest("identificador da rota diverge do cliente informado no corpo");
            }

            await this.clientesService.AtualizarAsync(cliente);

            return Ok(cliente);
        }

        /// <summary>
        /// Remover cliente por {id}
        /// </summary>
        /// <response code="204">Confirmacao</response>
        /// <response code="400">Falha no processo de exclucao</response> 
        /// <response code="404">Cliente nao encontrado</response> 
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoverCliente([FromRoute] Guid id)
        {
            Cliente cliente = await this.clientesService.ObterPorIdAsync(id);

            if (cliente is null)
            {
                return NotFound();
            }

            await this.clientesService.RemoverAsync(id);

            return NoContent();
        }
    }
}