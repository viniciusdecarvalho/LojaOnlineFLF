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
    public class ProdutosService : IProdutosService
    {
        private readonly IProdutosRepository produtosProvider;
        private readonly IMapper mapper;

        ///<summary>
        /// Construtor
        ///</summary>
        public ProdutosService(
            IProdutosRepository produtosRepository,
            IMapper mapper)
        {
            this.produtosProvider = produtosRepository;
            this.mapper = mapper;
        }

        ///<summary>
        /// Adicionar novo funcionario
        ///</summary>
        public async Task<ProdutoTO> AdicionarAsync(ProdutoTO produto)
        {
            var entity = this.mapper.Map<Produto>(produto);

            await this.produtosProvider.IncluirAsync(entity);

            return this.mapper.Map<ProdutoTO>(entity);
        }
      
        ///<summary>
        /// Adicionar novo funcionario
        ///</summary>
        public async Task AtualizarAsync(ProdutoTO produto) 
        {
            var entity = this.mapper.Map<Produto>(produto);

            await this.produtosProvider.AtualizarAsync(entity);
        }

        ///<summary>
        /// Adicionar novo funcionario
        ///</summary>
        public async Task RemoverAsync(ProdutoTO produto)
        {
            await this.produtosProvider.RemoverAsync(produto.Id ?? Guid.Empty);
        }

        ///<summary>
        /// Buscar funcionario por id
        ///</summary>
        public async Task<ProdutoTO> ObterPorIdAsync(Guid id) 
        {            
            var funcionario = await this.produtosProvider.ObterAsync(id);

            return this.mapper.Map<ProdutoTO>(funcionario);
        }

        ///<summary>
        /// Buscar todos os produtos
        ///</summary>
        public async Task<IEnumerable<ProdutoTO>> ObterTodosAsync() 
        {            
            var produtos = await this.produtosProvider.ListarTodosAsync();

            return produtos.Select(this.mapper.Map<ProdutoTO>).ToList();
        }

        public Task<bool> ContemAsync(Guid id)
        {
            return this.produtosProvider.ContemAsync(id);
        }
    }
}