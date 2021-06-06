using System;
using System.Collections.Generic;
using System.Linq;
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
    [Route("api/vendas")]
    public class VendasController : ControllerBase
    {
        private readonly ILogger<VendasController> logger;
        private readonly IProdutosService produtosService;
        private readonly IVendasService vendasService;

        ///<summary>
        /// Construtor padrao
        ///</summary>
        public VendasController(
            ILogger<VendasController> logger,
            IProdutosService produtosService,
            IVendasService vendasService)
        {
            this.logger = logger;
            this.produtosService = produtosService;
            this.vendasService = vendasService;
        }

        /// <summary>
        /// Recuperar venda por {id}
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(VendaTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterVendaPorId([FromRoute] Guid id)
        {
            VendaTO venda = await this.vendasService.ObterPorIdAsync(id);

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
        [ProducesResponseType(typeof(VendaTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterVendaPorCpf([FromRoute] string cpf)
        {
            IEnumerable<VendaTO> vendas = await this.vendasService.ObterPorCpfClienteAsync(cpf);

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
        [ProducesResponseType(typeof(VendaCadastroTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AdicionarVenda([FromBody] VendaCadastroTO venda)
        {
            VendaTO novaVenda = await this.vendasService.AdicionarAsync(venda);

            return Created($"api/vendas/{novaVenda.Id}", novaVenda);
        }

        /// <summary>
        /// Alterar informacoes de cadastro da venda
        /// </summary>
        //[HttpPut("{id}")]
        [ProducesResponseType(typeof(VendaCadastroTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AlterarVenda([FromRoute]Guid id, [FromBody] VendaCadastradaTO venda)
        {
            bool existe = await this.vendasService.ContemAsync(id);

            if (!existe)
            {
                return NotFound();
            }

            VendaTO novaVenda = await this.vendasService.AlterarVendaAsync(venda);

            return Ok(novaVenda);
        }

        /// <summary>
        /// Definir quantidade do produto na venda por um codigo de barras
        /// </summary>
        [HttpPatch("{id}/produto/{codigoBarras}/quantidade/{quantidade}")]
        [ProducesResponseType(typeof(VendaTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AtualizarProduto([FromRoute] IdentificadorProdutoTO identificador)
        {
            ProdutoTO produto = await this.produtosService.ObterPorCodigoBarrasAsync(identificador.CodigoBarras);

            VendaTO venda = await this.vendasService.ObterPorIdAsync(identificador.Id);

            var item = new VendaItemTO {
                VendaId = identificador.Id,
                ProdutoId = produto.Id,
                Quantidade = identificador.Quantidade
            };

            VendaTO vendaAlterada = await this.vendasService.AlterarItensAsync(venda.Id, item);

            return Ok(vendaAlterada);
        }

        /// <summary>
        /// Definir produtos da venda
        /// </summary>
        [HttpPatch("{id}/produtos")]
        [ProducesResponseType(typeof(VendaTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AtualizarProdutos([FromRoute] Guid id, [FromBody] IEnumerable<VendaItemTO> itens)
        {
            VendaTO venda = await this.vendasService.ObterPorIdAsync(id);

            if (venda is null)
            {
                return NotFound();
            }

            if (!itens.Any())
            {
                return BadRequest("itens da venda nao informados");
            }

            VendaTO vendaAlterada = await this.vendasService.AlterarItensAsync(id, itens.ToArray());
            
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
            VendaTO venda = await this.vendasService.ObterPorIdAsync(id);

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
            VendaTO venda = await this.vendasService.ObterPorIdAsync(id);

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
            VendaTO venda = await this.vendasService.ObterPorIdAsync(id);

            if (venda is null)
            {
                return NotFound();
            }

            VendaTO vendaReaberta = await this.vendasService.ReabrirVendaAsync(venda);

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
        [ProducesResponseType(typeof(IEnumerable<VendaTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterVendasPorData([FromRoute] DateTime data)
        {
            IEnumerable<VendaTO> vendas = await this.vendasService.ObterVendasPorData(data);

            return Ok(vendas);
        }
    }
}