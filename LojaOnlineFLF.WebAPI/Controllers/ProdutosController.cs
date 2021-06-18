using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.Repositories;
using LojaOnlineFLF.Services;
using LojaOnlineFLF.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LojaOnlineFLF.WebAPI.Controllers
{
    /// <summary>
    /// Recursos de produtos
    /// </summary>
    [Authorize]
    [ApiController]
    [Consumes(K.MediaTypes.AplicationJson)]
    [Produces(K.MediaTypes.AplicationJson)]
    [Route(Rota)]
    public class ProdutosController : ControllerBase
    {
        /// <summary>
        /// Rota base
        /// </summary>
        public const string Rota = "api/produtos";

        private readonly IProdutosService produtosService;

        ///<summary>
        /// Construtor padrao
        ///</summary>
        public ProdutosController(
            IProdutosService produtosService)
        {
            this.produtosService = produtosService;
        }

        /// <summary>
        /// Recuperar  produtos utilizando paginacao
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(Produtos), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ObterProdutos([FromQuery]Paginacao paginacao)
        {
            IPagedList<Produto> produtos = await this.produtosService.ObterTodosAsync(paginacao);

            var page = new Produtos(produtos, paginacao, Rota);

            return Ok(page);
        }

        /// <summary>
        /// Recuperar produto por {id}
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterProdutoPorId([FromRoute] Guid id)
        {
            Produto produto = await this.produtosService.ObterPorIdAsync(id);

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
        [ProducesResponseType(typeof(Produto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AdicionarProduto([FromBody] ProdutoCadastro produto)
        {
            Produto novoProduto = await this.produtosService.AdicionarAsync(produto);

            return Created($"api/produtos/{novoProduto.Id}", novoProduto);
        }

        /// <summary>
        /// Atualizar produto por {id}
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AtualizarProduto([FromRoute] Guid id, [FromBody] Produto produto)
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
            Produto produto = await this.produtosService.ObterPorIdAsync(id);

            if (produto is null)
            {
                return NotFound();
            }

            await this.produtosService.RemoverAsync(id);

            return NoContent();
        }
    }
}