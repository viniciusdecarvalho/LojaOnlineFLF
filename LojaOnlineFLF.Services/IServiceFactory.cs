using System;
using System.Collections.Generic;
using System.Text;

namespace LojaOnlineFLF.Services
{
    public interface IServiceFactory
    {
        IServiceFactory AplicarFabricas(Action<Type, Func<IServiceProvider, object>> acao);

        IServiceFactory AplicarTipos(Action<Type, Type> acao);
    }
}
