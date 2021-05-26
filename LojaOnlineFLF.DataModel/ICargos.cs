using System;
using LojaOnlineFLF.DataModel.Models;

namespace LojaOnlineFLF.DataModel
{
    public interface ICargos
    {
        Cargo Operacional { get; }

        Cargo Gerente { get; }

        Cargo Of(string nome);
    }
}
