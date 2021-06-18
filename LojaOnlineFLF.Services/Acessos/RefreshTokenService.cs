using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LojaOnlineFLF.Services
{
    internal class RefreshTokenService: IRefreshTokenService
    {
        const string CacheTipo = "RefreshToken";

        private readonly CacheContext context;

        public RefreshTokenService(CacheContext context)
        {
            this.context = context;
        }

        public RefreshToken Create(string userName)
        {
            return new RefreshToken {
                Usuario = userName,
                Token = Guid.NewGuid().ToString().Replace("-", String.Empty)
            };
        }

        public async Task<string> GetUserNameAsync(string value)
        {
            var cache = await this.GetCacheByValue(value);
                
            return cache?.Chave;
        }

        public async Task<Cache> GetCacheByValue(string value)
        {
            var cache =
                await this.context.Cache
                                  .Where(c => c.Tipo == CacheTipo)
                                  .Where(c => c.Valor == value)
                                  .AsNoTracking()
                                  .LastOrDefaultAsync();

            return cache;
        }

        public async Task<Cache> GetCacheByKey(string key)
        {
            var cache =
                await this.context.Cache
                                  .Where(c => c.Tipo == CacheTipo)
                                  .Where(c => c.Chave == key)
                                  .AsNoTracking()
                                  .FirstOrDefaultAsync();

            return cache;
        }

        public async Task Save(RefreshToken refreshToken)
        {
            var cache = await this.GetCacheByKey(refreshToken.Usuario);

            if (cache != null)
            {
                this.context.Cache.Remove(cache);

                await this.context.SaveChangesAsync();
            }

            var newCache = new Cache
            {
                Tipo = CacheTipo,
                Chave = refreshToken.Usuario,
                Valor = refreshToken.Token
            };

            await this.context.Cache.AddAsync(newCache);

            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cache>> GetAll()
        {
            return await this.context.Cache.AsNoTracking().ToListAsync();
        }
    }
}
