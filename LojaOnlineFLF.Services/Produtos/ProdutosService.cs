using System;
using System.Threading.Tasks;
using LojaOnlineFLF.Repositories;

namespace LojaOnlineFLF.Services
{
    ///<summary>
    /// servicos de produtos padrao
    ///</summary>
    internal class ProdutosService : IProdutosService
    {
        private readonly IProdutosRepository produtosProvider;
        private readonly IProdutoValidators produtosValidators;
        private readonly IMapperService mapper;

        ///<summary>
        /// Construtor
        ///</summary>
        public ProdutosService(
            IProdutosRepository produtosRepository,
            IProdutoValidators produtosValidators,
            IMapperService mapper)
        {
            this.produtosProvider = produtosRepository;
            this.produtosValidators = produtosValidators;
            this.mapper = mapper;
        }

        ///<summary>
        /// Adicionar novo funcionario
        ///</summary>
        public async Task<Produto> AdicionarAsync(ProdutoCadastro produto)
        {
            try
            {
                await this.produtosValidators.ValidateAndThrowAsync(produto);

                var entity = this.mapper.Convert<DataModel.Models.Produto>(produto);

                await this.produtosProvider.IncluirAsync(entity);

                return this.mapper.Convert<Produto>(entity);
            }
            catch(Exception e)
            {
                throw new ServiceException("falha ao tentar adicionar produto", e);
            }
        }
      
        ///<summary>
        /// Adicionar novo funcionario
        ///</summary>
        public async Task AtualizarAsync(Produto produto) 
        {
            try
            {
                await this.produtosValidators.ValidateAndThrowAsync(produto);

                var entity = this.mapper.Convert<DataModel.Models.Produto>(produto);

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
        public async Task<Produto> ObterPorIdAsync(Guid id) 
        {            
            var produto = await this.produtosProvider.ObterAsync(id);

            return this.mapper.Convert<Produto>(produto);
        }

        ///<summary>
        /// Buscar todos os produtos
        ///</summary>
        public async Task<IPagedList<Produto>> ObterTodosAsync(IPageParameters paginacao)
        {
            try
            {
                var produtos = await this.produtosProvider.ListarTodosAsync(paginacao.ToPageSet());

                return produtos.Transform(p => this.mapper.Convert<Produto>(p));
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

        public async Task<Produto> ObterPorCodigoBarrasAsync(string codigoBarras)
        {
            try
            { 
                var produto = await this.produtosProvider.ObterPorCodigoDeBarrasAsync(codigoBarras);

                return this.mapper.Convert<Produto>(produto);
            }
            catch (Exception e)
            {
                throw new ServiceException("falha ao tentar obter produto", e);
            }
        }
    }
}