using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.DataModel.Models;
using LojaOnlineFLF.Repositories;
using LojaOnlineFLF.Utils;
using System;
using System.Threading.Tasks;

namespace LojaOnlineFLF.Services
{
    ///<summary>
    /// servicos de produtos padrao
    ///</summary>
    internal class ClientesService : IClientesService
    {
        private readonly IClientesRepository clientesProvider;
        private readonly IClienteValidators clienteValidatos;
        private readonly IMapperService mapper;

        ///<summary>
        /// Construtor
        ///</summary>
        public ClientesService(
            IClientesRepository clientesRepository,
            IClienteValidators clienteValidatos,
            IMapperService mapper)
        {
            this.clientesProvider = clientesRepository;
            this.clienteValidatos = clienteValidatos;
            this.mapper = mapper;
        }

        ///<summary>
        /// Adicionar novo cliente
        ///</summary>
        public async Task<Cliente> AdicionarAsync(ClienteCadastro cliente)
        {
            try
            {
                Objects.CheckArgumentNonNull(cliente, nameof(cliente), "cliente invalido");

                await this.clienteValidatos.ValidateAndThrowAsync(cliente);

                var entity = this.mapper.Convert<DataModel.Models.Cliente>(cliente);

                await this.clientesProvider.IncluirAsync(entity);

                return this.mapper.Convert<Cliente>(entity);
            }
            catch(Exception e)
            {
                throw new ServiceException("falha ao tentar adicionar novo cliente", e);
            }
        }
      
        ///<summary>
        /// Atualizar novo cliente
        ///</summary>
        public async Task AtualizarAsync(Cliente cliente) 
        {
            try
            {
                Objects.CheckArgumentNonNull(cliente, nameof(cliente), "cliente invalido");

                await this.clienteValidatos.ValidateAndThrowAsync(cliente);

                var entity = this.mapper.Convert<DataModel.Models.Cliente>(cliente);

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
        public async Task<Cliente> ObterPorIdAsync(Guid id) 
        {
            try
            {
                var cliente = await this.clientesProvider.ObterAsync(id);

                return this.mapper.Convert<Cliente>(cliente);
            }
            catch(Exception e)
            {
                throw new ServiceException("falha ao tentar obter cliente por id", e);
            }
        }

        public async Task<Cliente> ObterPorCpfAsync(string cpf)
        {
            try
            {
                var cliente = await this.clientesProvider.ObterPorCpfAsync(cpf);
                return this.mapper.Convert<Cliente>(cliente);
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