using System;
using Microsoft.EntityFrameworkCore;

namespace LojaOnlineFLF.Services
{
    public class CacheContext: DbContext
    {
        public CacheContext(DbContextOptions<CacheContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Cache>()
                .HasKey(x => x.Chave);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cache> Cache { get; set; }
    }

    /// <summary>
    /// Cache de informacoes de chave/valor
    /// </summary>
    public class Cache
    {
        /// <summary>
        /// Chave para identificar valor
        /// </summary>
        public string Chave { get; set; }

        /// <summary>
        /// Valor guardado
        /// </summary>
        public string Valor { get; set; }

        /// <summary>
        /// Tipo para separacao de contextos
        /// </summary>
        public string Tipo { get; set; }
    }
}

