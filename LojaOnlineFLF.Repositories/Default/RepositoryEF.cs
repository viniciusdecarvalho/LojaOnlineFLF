using System.Collections.Generic;
using System.Threading.Tasks;
using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.DataModel.Providers;
using Microsoft.EntityFrameworkCore;

namespace LojaOnlineFLF.Repositories
{
    internal class RepositoryEF<T, U> where T: EntityKey<U>
    {
        private readonly LojaEFContext context;

        public RepositoryEF(LojaEFContext context)
        {
            this.context = context;
        }

        private DbSet<T> Set => this.context.Set<T>();

        public DbContext Context => this.context;

        public DbSet<T> Query => this.Set;

        public async Task AtualizarAsync(T entity)
        {
            await Task.Run(() => {
                this.Set.Update(entity);
            });

            await this.context.SaveChangesAsync();
        }        

        public async Task IncluirAsync(T entity)
        {
            await this.Set.AddAsync(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> ListarAsync()
        {
            return await this.Set.ToListAsync();
        }

        public async Task<T> ObterAsync(U id)
        {
            return await this.Set.FindAsync(id);
        }

        public Task<bool> ContemAsync(U id)
        {
            return this.Set.AnyAsync(e => e.Id.Equals(id));
        }

        public async Task RemoverAsync(U id)
        {
            await Task.Run(() => {

                var entity = this.Set.Find(id);
                this.Set.Remove(entity);

            });

            await this.context.SaveChangesAsync();
        }
    }
}
