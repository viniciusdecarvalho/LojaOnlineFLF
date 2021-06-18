using System;
using System.Collections.Generic;
using LojaOnlineFLF.DataModel.Models;

namespace LojaOnlineFLF.Repositories
{
    public interface ICargos: IEnumerable<Cargo>
    {
        Cargo Operacional { get; }

        Cargo Gerente { get; }

        Cargo Of(string nome);

        bool IsValid(string nome);
    }
}
