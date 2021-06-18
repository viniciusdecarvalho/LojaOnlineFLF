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
    public class Funcionarios: PagedResource<Funcionario>
    {
        /// <summary>
        /// Construtor padrao
        /// </summary>
        /// <param name="funcionarios">Lista de funcionarios paginado</param>
        /// <param name="paginacao">Detalhes da paginacao</param>
        /// <param name="recurso">recuros REST</param>
        public Funcionarios(IPagedList<Funcionario> funcionarios, Paginacao paginacao, string recurso) : base(funcionarios, paginacao, recurso)
        {
        }
    }
}
