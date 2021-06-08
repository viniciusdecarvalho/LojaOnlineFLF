using System;
using Microsoft.EntityFrameworkCore;

namespace LojaOnlineFLF.WebAPI.Services
{
    internal class CacheContext: DbContext
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

    public class Cache
    {
        public string Chave { get; set; }

        public string Valor { get; set; }

        public string Tipo { get; set; }
    }
}

