using System;
using LojaOnlineFLF.DataModel;
using Newtonsoft.Json;

namespace LojaOnlineFLF.WebAPI.Services
{
    /// <summary>
    /// Permitir parametros para paginacao
    /// </summary>
    public class Paginacao
    {
        /// <summary>
        /// Numero da pagina a ser exibida
        /// </summary>
        public int? NumeroPagina { get; set; }

        /// <summary>
        /// Quantidade de registros por pagina
        /// </summary>
        public int? TamanhoPagina { get; set; }

        public IPageSet ToPageSet()
        {
            return PageSet.Create(
                this.Current(),
                this.PageSize());
        }

        public int Current() => this.NumeroPagina.GetValueOrDefault(1);

        public int PageSize() => this.TamanhoPagina.GetValueOrDefault(25);

        public string NextPage(string resource)
        {
            return $"{resource}?{nameof(TamanhoPagina)}={this.TamanhoPagina}&{nameof(NumeroPagina)}={this.Current() + 1}";
        }

        public string BeforePage(string resource)
        {
            return $"{resource}?{nameof(TamanhoPagina)}={this.TamanhoPagina}&{nameof(NumeroPagina)}={this.Current() - 1}";
        }
    }
}
