using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.DataModel.Models;
using LojaOnlineFLF.WebAPI.Services.Models;

namespace LojaOnlineFLF.WebAPI.Services
{
    ///<summary>
    /// servicos de produtos padrao
    ///</summary>
    internal class ClientesService : IClientesService
    {
        private readonly IClientesRepository clientesProvider;
        private readonly IMapperService mapper;

        ///<summary>
        /// Construtor
        ///</summary>
        public ClientesService(
            IClientesRepository clientesRepository,
            IMapperService mapper)
        {
            this.clientesProvider = clientesRepository;
            this.mapper = mapper;
        }

        ///<summary>
        /// Adicionar novo cliente
        ///</summary>
        public async Task<ClienteTO> AdicionarAsync(ClienteTO produto)
        {
            try
            {
                var entity = this.mapper.Map<Cliente>(produto);

                await this.clientesProvider.IncluirAsync(entity);

                return this.mapper.Map<ClienteTO>(entity);
            }
            catch(Exception e)
            {
                throw new ServiceException("falha ao tentar adicionar novo cliente", e);
            }
        }
      
        ///<summary>
        /// Atualizar novo cliente
        ///</summary>
        public async Task AtualizarAsync(ClienteTO cliente) 
        {
            try
            {
                var entity = this.mapper.Map<Cliente>(cliente);

                await this.clientesProvider.AtualizarAsync(entity);
            }
            catch(Exception e)
            {
                throw new ServiceException("falha ao tentar atualizar cliente", e);
            }
        }

        ///<summary>
        /// Remover cliente
        ///</summary>
        public async Task RemoverAsync(Guid id)
        {
            try
            {
                await this.clientesProvider.RemoverAsync(id);
            }
            catch(Exception e)
            {
                throw new ServiceException("falha ao tentar remover cliente", e);
            }
        }

        ///<summary>
        /// Buscar cliente por id
        ///</summary>
        public async Task<ClienteTO> ObterPorIdAsync(Guid id) 
        {
            try
            {
                var cliente = await this.clientesProvider.ObterAsync(id);

                return this.mapper.Map<ClienteTO>(cliente);
            }
            catch(Exception e)
            {
                throw new ServiceException("falha ao tentar obter cliente por id", e);
            }
        }

        public async Task<ClienteTO> ObterPorCpfAsync(string cpf)
        {
            try
            {
                var cliente = await this.clientesProvider.ObterPorCpfAsync(cpf);
                return this.mapper.Map<ClienteTO>(cliente);
            }
            catch(Exception e)
            {
                throw new ServiceException("falha ao tentar obter cliente por cpf", e);
            }
        }
        
        public async Task<bool> ContemAsync(Guid id)
        {
            try
            {
                return await this.clientesProvider.ContemAsync(id);
            }
            catch(Exception e)
            {
                throw new ServiceException("falha ao tentar buscar cliente", e);
            }
        }
    }
}