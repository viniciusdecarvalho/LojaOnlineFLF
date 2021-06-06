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
    ///<summary>
    /// servicos de produtos padrao
    ///</summary>
    public class ProdutosService : IProdutosService
    {
        private readonly IProdutosRepository produtosProvider;
        private readonly IMapperService mapper;

        ///<summary>
        /// Construtor
        ///</summary>
        public ProdutosService(
            IProdutosRepository produtosRepository,
            IMapperService mapper)
        {
            this.produtosProvider = produtosRepository;
            this.mapper = mapper;
        }

        ///<summary>
        /// Adicionar novo funcionario
        ///</summary>
        public async Task<ProdutoTO> AdicionarAsync(ProdutoCadastroTO produto)
        {
            try
            {
                var entity = this.mapper.Map<Produto>(produto);

                await this.produtosProvider.IncluirAsync(entity);

                return this.mapper.Map<ProdutoTO>(entity);
            }
            catch(Exception e)
            {
                throw new ServiceException("falha ao tentar adicionar produto", e);
            }
        }
      
        ///<summary>
        /// Adicionar novo funcionario
        ///</summary>
        public async Task AtualizarAsync(ProdutoTO produto) 
        {
            try
            {
                var entity = this.mapper.Map<Produto>(produto);

                await this.produtosProvider.AtualizarAsync(entity);
            }
            catch(Exception e)
            {
                throw new ServiceException("falha ao tentar atualizar produto", e);
            }
        }

        ///<summary>
        /// Adicionar novo funcionario
        ///</summary>
        public async Task RemoverAsync(Guid id)
        {
            await this.produtosProvider.RemoverAsync(id);
        }

        ///<summary>
        /// Buscar funcionario por id
        ///</summary>
        public async Task<ProdutoTO> ObterPorIdAsync(Guid id) 
        {            
            var produto = await this.produtosProvider.ObterAsync(id);

            return this.mapper.Map<ProdutoTO>(produto);
        }

        ///<summary>
        /// Buscar todos os produtos
        ///</summary>
        public async Task<IEnumerable<ProdutoTO>> ObterTodosAsync()
        {
            try
            {
                var produtos = await this.produtosProvider.ListarTodosAsync();

                return produtos.Select(this.mapper.Map<ProdutoTO>).ToList();
            }
            catch(Exception e)
            {
                throw new ServiceException("falha ao tentar obter produtos", e);
            }
        }

        public Task<bool> ContemAsync(Guid id)
        {
            try
            { 
            return this.produtosProvider.ContemAsync(id);
            }
            catch (Exception e)
            {
                throw new ServiceException("falha ao tentar obter produto", e);
            }
        }

        public Task<bool> ContemCodigoBarrasAsync(string codigoBarras)
        {
            try
            { 
                return this.produtosProvider.ContemCodigoBarrasAsync(codigoBarras);
            }
            catch (Exception e)
            {
                throw new ServiceException("falha ao tentar obter produto", e);
            }
        }

        public async Task<ProdutoTO> ObterPorCodigoBarrasAsync(string codigoBarras)
        {
            try
            { 
                var produto = await this.produtosProvider.ObterPorCodigoDeBarrasAsync(codigoBarras);

                return this.mapper.Map<ProdutoTO>(produto);
            }
            catch (Exception e)
            {
                throw new ServiceException("falha ao tentar obter produto", e);
            }
        }
    }
}