using LojaOnlineFLF.Services;
using LojaOnlineFLF.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaOnlineFLF.WebAPI.Controllers
{
    /// <summary>
    /// Recursos de vendas
    /// </summary>
    [Authorize]
    [ApiController]
    [Consumes(K.MediaTypes.AplicationJson)]
    [Produces(K.MediaTypes.AplicationJson)]
    [Route("api/vendas")]
    public class VendasController : ControllerBase
    {
        private readonly IProdutosService produtosService;
        private readonly IVendasService vendasService;

        ///<summary>
        /// Construtor padrao
        ///</summary>
        public VendasController(
            IProdutosService produtosService,
            IVendasService vendasService)
        {
            this.produtosService = produtosService;
            this.vendasService = vendasService;
        }

        /// <summary>
        /// Recuperar venda por {id}
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Venda), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterVendaPorId([FromRoute] Guid id)
        {
            Venda venda = await this.vendasService.ObterPorIdAsync(id);

            if (venda is null)
            {
                return NotFound();
            }

            return Ok(venda);
        }

        /// <summary>
        /// Recuperar vendas por {cpf} de um cliente
        /// </summary>
        [HttpGet("cpf/{cpf}")]
        [ProducesResponseType(typeof(Venda), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterVendaPorCpf([FromRoute] string cpf)
        {
            IEnumerable<Venda> vendas = await this.vendasService.ObterPorCpfClienteAsync(cpf);

            return Ok(vendas);
        }

        /// <summary>
        /// Criar nova venda
        /// </summary>
        /// <remarks>
        /// Quando cliente informado, possuir CPF, e ou Fone, e não seja encontrado,
        /// um novo cliente sera cadastrado para o CPF informado,
        /// caso contrário ou em caso de o cliente nao ser informado, a venda nao possuirá um cliente
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(typeof(VendaCadastro), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AdicionarVenda([FromBody] VendaCadastro venda)
        {
            Venda novaVenda = await this.vendasService.AdicionarAsync(venda);

            return Created($"api/vendas/{novaVenda.Id}", novaVenda);
        }

        /// <summary>
        /// Alterar informacoes de cadastro da venda
        /// </summary>
        //[HttpPut("{id}")]
        [ProducesResponseType(typeof(VendaCadastro), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AlterarVenda([FromRoute]Guid id, [FromBody] VendaCadastrada venda)
        {
            bool existe = await this.vendasService.ContemAsync(id);

            if (!existe)
            {
                return NotFound();
            }

            Venda novaVenda = await this.vendasService.AlterarVendaAsync(venda);

            return Ok(novaVenda);
        }

        /// <summary>
        /// Definir quantidade do produto na venda por um codigo de barras
        /// </summary>
        [HttpPatch("{id}/produto/{codigoBarras}/quantidade/{quantidade}")]
        [ProducesResponseType(typeof(Venda), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AtualizarProduto([FromRoute] IdentificadorProdutoTO identificador)
        {
            Produto produto = await this.produtosService.ObterPorCodigoBarrasAsync(identificador.CodigoBarras);

            Venda venda = await this.vendasService.ObterPorIdAsync(identificador.Id);

            var item = new VendaItem {
                ProdutoId = produto.Id,
                Quantidade = identificador.Quantidade
            };

            Venda vendaAlterada = await this.vendasService.AlterarItensAsync(venda.Id, item);

            return Ok(vendaAlterada);
        }

        /// <summary>
        /// Definir produtos da venda
        /// </summary>
        [HttpPatch("{id}/produtos")]
        [ProducesResponseType(typeof(Venda), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AtualizarProdutos([FromRoute] Guid id, [FromBody] IEnumerable<VendaItem> itens)
        {
            Venda venda = await this.vendasService.ObterPorIdAsync(id);

            if (venda is null)
            {
                return NotFound();
            }

            if (!itens.Any())
            {
                return BadRequest("itens da venda nao informados");
            }

            Venda vendaAlterada = await this.vendasService.AlterarItensAsync(id, itens.ToArray());
            
            return Ok(vendaAlterada);
        }

        /// <summary>
        /// Cancelar venda por {id}
        /// </summary>
        [HttpPatch("{id}/cancelar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CancelarVenda([FromRoute] Guid id)
        {
            Venda venda = await this.vendasService.ObterPorIdAsync(id);

            if (venda is null)
            {
                return NotFound();
            }

            await this.vendasService.CancelarVendaAsync(venda);

            return NoContent();
        }

        /// <summary>
        /// Concluir venda por {id}
        /// </summary>
        [HttpPatch("{id}/concluir")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ConcluirVenda([FromRoute] Guid id)
        {
            Venda venda = await this.vendasService.ObterPorIdAsync(id);

            if (venda is null)
            {
                return NotFound();
            }

            await this.vendasService.ConcluirVendaAsync(venda);

            return NoContent();
        }

        /// <summary>
        /// Reabrir venda por {id}. Volta a situacao da venda para aberta, possivel alterar produtos da venda
        /// </summary>
        [HttpPatch("{id}/reabrir")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ReabrirVenda([FromRoute] Guid id)
        {
            Venda venda = await this.vendasService.ObterPorIdAsync(id);

            if (venda is null)
            {
                return NotFound();
            }

            Venda vendaReaberta = await this.vendasService.ReabrirVendaAsync(venda);

            return Ok(vendaReaberta);
        }

        /// <summary>
        /// Remover venda por {id}
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoverVenda([FromRoute] Guid id)
        {
            bool existe = await this.vendasService.ContemAsync(id);

            if (!existe)
            {
                return NotFound();
            }

            await this.vendasService.RemoverVendaAsync(id);

            return NoContent();
        }

        /// <summary>
        /// Recuperar venda pora a {data}
        /// </summary>
        [HttpGet("abertas/data/{data}")]
        [ProducesResponseType(typeof(IEnumerable<Venda>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterVendasPorData([FromRoute] DateTime data)
        {
            IEnumerable<Venda> vendas = await this.vendasService.ObterVendasPorData(data);

            return Ok(vendas);
        }
    }
}