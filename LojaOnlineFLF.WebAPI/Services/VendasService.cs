using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.DataModel.Models;
using LojaOnlineFLF.Utils;
using LojaOnlineFLF.WebAPI.Services.Models;

namespace LojaOnlineFLF.WebAPI.Services
{
    public class VendasService : IVendasService
    {
        private readonly IVendasRepository vendasRepository;
        private readonly IMapper mapper;

        public VendasService(
            IVendasRepository vendasRepository,
            IMapper mapper)
        {
            this.vendasRepository = vendasRepository;
            this.mapper = mapper;
        }

        public async Task<VendaTO> AdicionarAsync(VendaCadastroTO venda)
        {
            var entity = this.mapper.Map<Venda>(venda);

            await this.vendasRepository.IncluirAsync(entity);

            return this.mapper.Map<VendaTO>(entity);
        }

        public async Task<VendaTO> AlterarItemAsync(VendaTO vendaTO, ProdutoTO produtoTO, int? quantidade)
        {
            Objects.CheckArgumentNonNull(vendaTO, "venda", "registro de venda invalido");
            Objects.CheckArgumentNonNull(produtoTO, "produto", "registro de produto invalido");

            VendaItem vendaItem = await this.vendasRepository.CriarVendaItemAsync(produtoTO.Id.GetValueOrDefault(Guid.Empty), quantidade);

            var venda = await this.vendasRepository.AlterarItemAsync(vendaTO.Id, vendaItem);

            return this.mapper.Map<VendaTO>(venda);
        }

        public async Task<VendaTO> AlterarVendaAsync(VendaCadastradaTO vendaTO)
        {
            Venda venda = await this.vendasRepository.ObterAsync(vendaTO.Id);

            this.mapper.Map(vendaTO, venda);

            await this.vendasRepository.AtualizarAsync(venda);

            return this.mapper.Map<VendaTO>(venda);
        }

        public async Task CancelarVendaAsync(VendaTO venda)
        {
            Objects.CheckArgumentNonNull(venda, "venda", "registro de venda invalido");

            await this.vendasRepository.CancelarAsync(venda.Id);
        }

        public async Task ConcluirVendaAsync(VendaTO venda)
        {
            Objects.CheckArgumentNonNull(venda, "venda", "registro de venda invalido");

            await this.vendasRepository.ConcluirAsync(venda.Id);
        }

        public async Task<bool> ContemAsync(Guid id)
        {
            return await this.vendasRepository.ContemAsync(id);
        }

        public async Task<IEnumerable<VendaTO>> ObterPorCpfClienteAsync(string cpf)
        {
            var vendas = await this.vendasRepository.ObterPorCpfClienteAsync(cpf);

            return this.mapper.Map<IEnumerable<VendaTO>>(vendas);
        }

        public async Task<VendaTO> ObterPorIdAsync(Guid id)
        {
            Venda venda = await this.vendasRepository.ObterAsync(id);

            return this.mapper.Map<VendaTO>(venda);
        }

        public async Task<VendaTO> ReabrirVendaAsync(VendaTO venda)
        {
            Objects.CheckArgumentNonNull(venda, "venda", "registro de venda invalido");

            var vendaAlterada = await this.vendasRepository.ReabrirAsync(venda.Id);

            return this.mapper.Map<VendaTO>(vendaAlterada);
        }

        public async Task RemoverVendaAsync(VendaTO venda)
        {
            Objects.CheckArgumentNonNull(venda, "venda", "registro de venda invalido");

            await this.vendasRepository.RemoverAsync(venda.Id);
        }

        public async Task RemoverVendaAsync(Guid id)
        {
            await this.vendasRepository.RemoverAsync(id);
        }
    }
}