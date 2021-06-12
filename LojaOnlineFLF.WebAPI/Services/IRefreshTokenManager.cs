﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LojaOnlineFLF.WebAPI.Services.Models;

namespace LojaOnlineFLF.WebAPI.Services
{
    /// <summary>
    /// Manter informacoes de tokens de atualizacao de autenticacao
    /// </summary>
    public interface IRefreshTokenManager
    {
        /// <summary>
        /// Criar novo token para o usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        RefreshToken Create(string usuario);

        /// <summary>
        /// Salvar token informado
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        Task Save(RefreshToken refreshToken);

        /// <summary>
        /// Recuperar usuario para valor informado
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<string> GetUserNameAsync(string value);

        /// <summary>
        /// Recuperar tokens em cache
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Cache>> GetAll();
    }
}
