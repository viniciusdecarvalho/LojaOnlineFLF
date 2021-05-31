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
    [Route("api/produtos")]
    public class ProdutosController : ControllerBase
    {
        private readonly ILogger<FuncionariosController> logger;
        private readonly IProdutosService produtosService;

        ///<summary>
        /// Construtor padrao
        ///</summary>
        public ProdutosController(
            ILogger<FuncionariosController> logger,
            IProdutosService produtosService)
        {
            this.logger = logger;
            this.produtosService = produtosService;
        }

        /// <summary>
        /// Recuperar todos os produtos
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProdutoTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ObterProdutos()
        {
            IEnumerable<ProdutoTO> produtos = await this.produtosService.ObterTodosAsync();

            return Ok(produtos);
        }

        /// <summary>
        /// Recuperar produto por {id}
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProdutoTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterProdutoPorId([FromRoute] Guid id)
        {
            ProdutoTO produto = await this.produtosService.ObterPorIdAsync(id);

            if (produto is null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        /// <summary>
        /// Adicionar produto
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ProdutoTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AdicionarProduto([FromBody] ProdutoTO produto)
        {
            ProdutoTO novoProduto = await this.produtosService.AdicionarAsync(produto);

            return Created($"api/produtos/{novoProduto.Id}", novoProduto);
        }

        /// <summary>
        /// Atualizar produto por {id}
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProdutoTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AtualizarProduto([FromRoute] Guid id, [FromBody] ProdutoTO produto)
        {
            await this.produtosService.AtualizarAsync(produto);

            return Ok(produto);
        }

        /// <summary>
        /// Remover produto por {id}
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoverProduto([FromRoute] Guid id)
        {
            ProdutoTO produto = await this.produtosService.ObterPorIdAsync(id);

            if (produto is null)
            {
                return NotFound();
            }

            await this.produtosService.RemoverAsync(produto);

            return NoContent();
        }
    }
}