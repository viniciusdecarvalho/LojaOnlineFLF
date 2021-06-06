using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LojaOnlineFLF.WebAPI.Services.Models;

namespace LojaOnlineFLF.WebAPI.Services
{
    public interface IClientesService
    {
        Task<ClienteTO> ObterPorIdAsync(Guid id);

        Task<ClienteTO> AdicionarAsync(ClienteTO cliente);

        Task AtualizarAsync(ClienteTO cliente);

        Task RemoverAsync(Guid id);

        Task<ClienteTO> ObterPorCpfAsync(string cpf);

        Task<bool> ContemAsync(Guid id);
    }
}