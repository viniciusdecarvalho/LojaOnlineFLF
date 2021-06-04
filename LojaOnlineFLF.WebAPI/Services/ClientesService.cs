using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.DataModel.Models;
using LojaOnlineFLF.WebAPI.Services.Models;

namespace LojaOnlineFLF.WebAPI.Services
{
    ///<summary>
    /// servicos de produtos padrao
    ///</summary>
    public class ClientesService : IClientesService
    {
        private readonly IClientesRepository clientesProvider;
        private readonly IMapper mapper;

        ///<summary>
        /// Construtor
        ///</summary>
        public ClientesService(
            IClientesRepository clientesRepository,
            IMapper mapper)
        {
            this.clientesProvider = clientesRepository;
            this.mapper = mapper;
        }

        ///<summary>
        /// Adicionar novo cliente
        ///</summary>
        public async Task<ClienteTO> AdicionarAsync(ClienteTO produto)
        {
            var entity = this.mapper.Map<Cliente>(produto);

            await this.clientesProvider.IncluirAsync(entity);

            return this.mapper.Map<ClienteTO>(entity);
        }
      
        ///<summary>
        /// Atualizar novo cliente
        ///</summary>
        public async Task AtualizarAsync(ClienteTO cliente) 
        {
            var entity = this.mapper.Map<Cliente>(cliente);

            await this.clientesProvider.AtualizarAsync(entity);
        }

        ///<summary>
        /// Remover cliente
        ///</summary>
        public async Task RemoverAsync(ClienteTO cliente)
        {
            await this.clientesProvider.RemoverAsync(cliente.Id ?? Guid.Empty);
        }

        ///<summary>
        /// Buscar cliente por id
        ///</summary>
        public async Task<ClienteTO> ObterPorIdAsync(Guid id) 
        {            
            var cliente = await this.clientesProvider.ObterAsync(id);

            return this.mapper.Map<ClienteTO>(cliente);
        }

        public async Task<IEnumerable<ClienteTO>> ObterPorCpfAsync(string cpf)
        {
            var clientes = await this.clientesProvider.ObterPorCpfAsync(cpf);

            return this.mapper.Map<IEnumerable<ClienteTO>>(clientes);
        }

        public async Task<bool> ContemAsync(Guid id)
        {
            return await this.clientesProvider.ContemAsync(id);
        }
    }
}