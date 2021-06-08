using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LojaOnlineFLF.WebAPI.Services.Models;

namespace LojaOnlineFLF.WebAPI.Services
{    
    public interface IAcessosService
    {
        Task<FuncionarioTO> ValidarAcessoAsync(Login login);

        Task<FuncionarioTO> ValidarTokenAsync(RefreshToken refreshToken);

        Task IncluirAcessoAsync(FuncionarioTO funcionario, Login login);

        Task AlterarAcessoAsync(FuncionarioTO funcionario, LoginAlteracao login);
    }
}