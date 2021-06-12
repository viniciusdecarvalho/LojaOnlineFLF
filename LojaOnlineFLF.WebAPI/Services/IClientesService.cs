using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LojaOnlineFLF.WebAPI.Services.Models;

namespace LojaOnlineFLF.WebAPI.Services
{
    /// <summary>
    /// Operações de clientes
    /// </summary>
    public interface IClientesService
    {
        /// <summary>
        /// Recuperar cliente por {id}
        /// </summary>
        /// <param name="id">Identificador do cliente</param>
        /// <returns>Cliente</returns>
        Task<ClienteTO> ObterPorIdAsync(Guid id);

        /// <summary>
        /// Adicionar novo cliente
        /// </summary>
        /// <param name="cliente">Informacoes do cliente</param>
        /// <returns>Cliente saldo</returns>
        Task<ClienteTO> AdicionarAsync(ClienteTO cliente);

        /// <summary>
        /// Atualizar informacoes de um cliente
        /// </summary>
        /// <param name="cliente">Dados do cliente</param>        
        Task AtualizarAsync(ClienteTO cliente);

        /// <summary>
        /// Remover cliente por id
        /// </summary>
        /// <param name="id">Identificador do cliente</param>
        Task RemoverAsync(Guid id);

        /// <summary>
        /// Recuperar cliente por CPF
        /// </summary>
        /// <param name="cpf">Numero de cpf</param>
        /// <returns>Cliente</returns>
        Task<ClienteTO> ObterPorCpfAsync(string cpf);

        /// <summary>
        /// Verificar se identificar existe 
        /// </summary>
        /// <param name="id">Identificador de um cliente</param>
        /// <returns>true caso algum registro encontrado, false caso contrario</returns>
        Task<bool> ContemAsync(Guid id);
    }
}