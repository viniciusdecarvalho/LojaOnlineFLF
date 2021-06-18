using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.Repositories;
using LojaOnlineFLF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaOnlineFLF.WebAPI.Models
{
    /// <summary>
    /// Paginacao de funcionarios
    /// </summary>
    public class Produtos : PagedResource<Produto>
    {
        /// <summary>
        /// Construtor padrao
        /// </summary>
        /// <param name="produtos">Lista de produtos paginado</param>
        /// <param name="paginacao">Detalhes da paginacao</param>
        /// <param name="recurso">recuros REST</param>
        public Produtos(IPagedList<Produto> produtos, Paginacao paginacao, string recurso) : base(produtos, paginacao, recurso)
        {
        }
    }
}
