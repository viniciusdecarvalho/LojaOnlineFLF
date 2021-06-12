using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.DataModel.Models;
using LojaOnlineFLF.Utils;
using LojaOnlineFLF.WebAPI.Services.Models;

namespace LojaOnlineFLF.WebAPI.Services
{
    internal class VendasService : IVendasService
    {
        private readonly IClientesRepository clientesRepository;
        private readonly IVendasRepository vendasRepository;
        private readonly IMapperService mapper;

        public VendasService(
            IClientesRepository clientesRepository,
            IVendasRepository vendasRepository,
            IMapperService mapper)
        {
            this.clientesRepository = clientesRepository;
            this.vendasRepository = vendasRepository;
            this.mapper = mapper;
        }

        public async Task<VendaTO> AdicionarAsync(VendaCadastroTO venda)
        {
            var entity = this.mapper.Map<Venda>(venda);

            var cliente = await ObterOuCadastrarClienteParaNovaVenda(venda);

            entity.Cliente = cliente;
            entity.ClienteId = cliente?.Id;

            await this.vendasRepository.IncluirAsync(entity);

            return this.mapper.Map<VendaTO>(entity);
        }

        private async Task<Cliente> ObterOuCadastrarClienteParaNovaVenda(VendaCadastroTO venda)
        {
            const string NomeClienteCadastradoAtravesDeVendas = "Cadastrado por venda";

            Cliente cliente = null;

            string cpf = venda.Cliente?.Cpf;
            string fone = venda.Cliente?.Fone;

            bool cpfInformado = !string.IsNullOrWhiteSpace(cpf);
            bool foneInformado = !string.IsNullOrWhiteSpace(fone);

            if (cpfInformado)
            {
                cliente = await this.clientesRepository.ObterPorCpfAsync(cpf);
            }
            else if (foneInformado)
            {
                cliente = await this.clientesRepository.ObterPorFoneAsync(fone);
            }

            if (cpfInformado && cliente is null)
            {
                cliente = new Cliente { Nome = NomeClienteCadastradoAtravesDeVendas, Cpf = cpf, Fone = fone };

                await this.clientesRepository.IncluirAsync(cliente);
            }

            return cliente;
        }

        public async Task<VendaTO> AlterarItensAsync(Guid id, params VendaItemTO[] itens)
        {
            var venda = await this.vendasRepository.ObterAsync(id);

            var itensVenda =
                itens.Select(i => this.vendasRepository.CriarVendaItemAsync(i.ProdutoId, i.Quantidade)).ToList();

            foreach (var item in itensVenda)
            {
                venda = await this.vendasRepository.AlterarItemAsync(id, await item);
            }

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

        public async Task<IEnumerable<VendaTO>> ObterVendasPorData(DateTime data)
        {
            var vendas = await this.vendasRepository.ObterTodasPorDataAsync(data);

            return this.mapper.Map<IEnumerable<VendaTO>>(vendas);
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