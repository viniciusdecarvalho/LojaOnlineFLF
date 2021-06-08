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
    [Authorize]
    [ApiController]
    [Consumes(K.MediaTypes.AplicationJson)]
    [Produces(K.MediaTypes.AplicationJson)]
    [Route(Rota)]
    public class ProdutosController : ControllerBase
    {
        public const string Rota = "api/produtos";

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
        [ProducesResponseType(typeof(PagedResource<ProdutoTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ObterProdutos([FromQuery]Paginacao paginacao)
        {
            IPagedList<ProdutoTO> produtos = await this.produtosService.ObterTodosAsync(paginacao);

            var page = new PagedResource<ProdutoTO>(produtos, paginacao, Rota);

            return Ok(page);
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
        public async Task<IActionResult> AdicionarProduto([FromBody] ProdutoCadastroTO produto)
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
            bool existe = await this.produtosService.ContemAsync(id);

            if(!existe)
            {
                return NotFound();
            }

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

            await this.produtosService.RemoverAsync(id);

            return NoContent();
        }
    }
}