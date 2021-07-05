using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaOnlineFLF.Services;
using Microsoft.Extensions.Caching.Distributed;

namespace LojaOnlineFLF.WebAPI.Models
{
    internal class RefreshTokenManagerWithCacheRedis: IRefreshTokenService
    {
        private readonly IDistributedCache cache;

        public RefreshTokenManagerWithCacheRedis(IDistributedCache cache)
        {
            this.cache = cache;
        }

        public RefreshToken Create(string usuario)
        {
            return new RefreshToken
            {
                Usuario = usuario,
                Token = Guid.NewGuid().ToString().Replace("-", String.Empty)
            };
        }

        public Task<IEnumerable<Cache>> GetAll()
        {
            return Task.FromResult(Enumerable.Empty<Cache>());
        }

        public Task<string> GetUserNameAsync(string value)
        {
            return this.cache.GetStringAsync(value);
        }

        public async Task Save(RefreshToken refreshToken)
        {
            var opcoesCache = new DistributedCacheEntryOptions();

            opcoesCache.SetAbsoluteExpiration(TimeSpan.FromHours(2));

            await this.cache.SetStringAsync(refreshToken.Token, refreshToken.Usuario, opcoesCache);
        }
    }
}
