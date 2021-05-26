using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace LojaOnlineFLF.WebAPI.Services.Models
{
    ///<summary>
    /// Cargos dos funcionarios
    ///</summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    [ResultName("Cargo")]
    public enum CargoTO
    {
        ///<summary>
        /// Indica funcionarios operacionais
        ///</summary>
        Operacional,

        ///<summary>
        /// Indica gerentes
        ///</summary>
        Gerente
    }
}