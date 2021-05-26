using System;
using System.Threading.Tasks;
using LojaOnlineFLF.DataModel.Providers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Storage;

namespace LojaOnlineFLF.WebAPI.Filters
{
    ///<summary>
    /// Controle de transacoes
    ///</summary>
    public class TransactionFilter : IAlwaysRunResultFilter
    {
        private readonly LojaEFContext db;        

        ///<summary>
        /// Construtor padrao
        ///</summary>
        public TransactionFilter(LojaEFContext db)
        {
            this.db = db;
        }
        
        ///<summary>
        /// Chamado quando execucao da acao e concluida
        ///</summary>
        public void OnResultExecuted(ResultExecutedContext context)
        {
            this.db.SaveChanges();
        }

        ///<summary>
        /// Chamado quando execucao da acao inicia
        ///</summary>
        public void OnResultExecuting(ResultExecutingContext context)
        {
        }
    }
}