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

        Task RemoverAsync(ClienteTO cliente);

        Task<IEnumerable<ClienteTO>> ObterPorCpfAsync(string cpf);

        Task<bool> ContemAsync(Guid id);
    }
}