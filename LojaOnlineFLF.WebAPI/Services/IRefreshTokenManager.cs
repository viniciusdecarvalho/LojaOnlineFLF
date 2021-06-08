using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LojaOnlineFLF.WebAPI.Services.Models;

namespace LojaOnlineFLF.WebAPI.Services
{
    public interface IRefreshTokenManager
    {
        Task Save(RefreshToken refreshToken);

        Task<string> GetUserNameAsync(string value);

        Task<IEnumerable<Cache>> GetAll();
    }
}
