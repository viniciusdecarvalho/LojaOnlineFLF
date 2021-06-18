using System;
using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.Services;
using Newtonsoft.Json;

namespace LojaOnlineFLF.WebAPI.Models
{
    /// <summary>
    /// Permitir parametros para paginacao
    /// </summary>
    public class Paginacao: IPageParameters
    {
        /// <summary>
        /// Numero da pagina a ser exibida
        /// </summary>
        public int? NumeroPagina { get; set; }

        /// <summary>
        /// Quantidade de registros por pagina
        /// </summary>
        public int? TamanhoPagina { get; set; }

        internal int Current() => this.NumeroPagina.GetValueOrDefault(1);

        internal int PageSize() => this.TamanhoPagina.GetValueOrDefault(25);

        internal string NextPage(string resource)
        {
            return $"{resource}?{nameof(TamanhoPagina)}={this.TamanhoPagina}&{nameof(NumeroPagina)}={this.Current() + 1}";
        }

        internal string BeforePage(string resource)
        {
            return $"{resource}?{nameof(TamanhoPagina)}={this.TamanhoPagina}&{nameof(NumeroPagina)}={this.Current() - 1}";
        }
    }
}
