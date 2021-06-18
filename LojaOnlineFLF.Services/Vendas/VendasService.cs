using FluentValidation;
using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.DataModel.Models;
using LojaOnlineFLF.Repositories;
using LojaOnlineFLF.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaOnlineFLF.Services
{
    internal class VendasService : IVendasService
    {
        private readonly IClientesRepository clientesRepository;
        private readonly IVendasRepository vendasRepository;
        private readonly IVendaValidators vendasValidator;
        private readonly IMapperService mapper;

        public VendasService(
            IClientesRepository clientesRepository,
            IVendasRepository vendasRepository,
            IVendaValidators vendasValidator,
            IMapperService mapper)
        {
            this.clientesRepository = clientesRepository;
            this.vendasRepository = vendasRepository;
            this.vendasValidator = vendasValidator;
            this.mapper = mapper;
        }

        public async Task<Venda> AdicionarAsync(VendaCadastro venda)
        {
            Objects.CheckArgumentNonNull(venda, "itens", "registro de venda invalido");

            await this.vendasValidator.ValidateAndThrowAsync(venda);

            var entity = this.mapper.Convert<DataModel.Models.Venda>(venda);

            var cliente = await ObterOuCadastrarClienteParaNovaVenda(venda);

            entity.Cliente = cliente;
            entity.ClienteId = cliente?.Id;

            await this.vendasRepository.IncluirAsync(entity);

            return this.mapper.Convert<Venda>(entity);
        }

        private async Task<DataModel.Models.Cliente> ObterOuCadastrarClienteParaNovaVenda(VendaCadastro venda)
        {
            const string NomeClienteCadastradoAtravesDeVendas = "Cadastrado por venda";

            DataModel.Models.Cliente cliente = null;

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
                cliente = new DataModel.Models.Cliente { Nome = NomeClienteCadastradoAtravesDeVendas, Cpf = cpf, Fone = fone };

                await this.clientesRepository.IncluirAsync(cliente);
            }

            return cliente;
        }

        public async Task<Venda> AlterarItensAsync(Guid id, params VendaItem[] itens)
        {
            Objects.CheckArgumentNonNull(itens, "itens", "itens da venda nao informados");

            await this.vendasValidator.ValidateAndThrowAsync(itens);

            var venda = await this.vendasRepository.ObterAsync(id);

            var itensVenda =
                itens.Select(i => this.vendasRepository.CriarVendaItemAsync(i.ProdutoId, i.Quantidade)).ToList();

            foreach (var item in itensVenda)
            {
                venda = await this.vendasRepository.AlterarItemAsync(id, await item);
            }

            return this.mapper.Convert<Venda>(venda);
        }

        public async Task<Venda> AlterarVendaAsync(VendaCadastrada vendaTO)
        {
            Objects.CheckArgumentNonNull(vendaTO, "venda", "registro de venda invalido");

            await this.vendasValidator.ValidateAndThrowAsync(vendaTO);

            DataModel.Models.Venda venda = await this.vendasRepository.ObterAsync(vendaTO.Id);

            this.mapper.Merge(vendaTO, venda);

            await this.vendasRepository.AtualizarAsync(venda);

            return this.mapper.Convert<Venda>(venda);
        }

        public async Task CancelarVendaAsync(Venda venda)
        {
            Objects.CheckArgumentNonNull(venda, "venda", "registro de venda invalido");

            await this.vendasRepository.CancelarAsync(venda.Id);
        }

        public async Task ConcluirVendaAsync(Venda venda)
        {
            Objects.CheckArgumentNonNull(venda, "venda", "registro de venda invalido");

            await this.vendasRepository.ConcluirAsync(venda.Id);
        }

        public async Task<bool> ContemAsync(Guid id)
        {
            return await this.vendasRepository.ContemAsync(id);
        }

        public async Task<IEnumerable<Venda>> ObterPorCpfClienteAsync(string cpf)
        {
            var vendas = await this.vendasRepository.ObterPorCpfClienteAsync(cpf);

            return this.mapper.Convert<IEnumerable<Venda>>(vendas);
        }

        public async Task<Venda> ObterPorIdAsync(Guid id)
        {
            DataModel.Models.Venda venda = await this.vendasRepository.ObterAsync(id);

            return this.mapper.Convert<Venda>(venda);
        }

        public async Task<IEnumerable<Venda>> ObterVendasPorData(DateTime data)
        {
            var vendas = await this.vendasRepository.ObterTodasPorDataAsync(data);

            return this.mapper.Convert<IEnumerable<Venda>>(vendas);
        }

        public async Task<Venda> ReabrirVendaAsync(Venda venda)
        {
            Objects.CheckArgumentNonNull(venda, "venda", "registro de venda invalido");

            var vendaAlterada = await this.vendasRepository.ReabrirAsync(venda.Id);

            return this.mapper.Convert<Venda>(vendaAlterada);
        }

        public async Task RemoverVendaAsync(Venda venda)
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