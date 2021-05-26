using System;
using LojaOnlineFLF.DataModel.Models;
using LojaOnlineFLF.DataModel.Models.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LojaOnlineFLF.DataModel.Providers
{
    public class LojaEFAuthContext : IdentityDbContext<Acesso>
    {    
        public LojaEFAuthContext(DbContextOptions<LojaEFAuthContext> options)
            : base(options)
        {
            //irá criar o banco e a estrutura de tabelas necessárias
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration<Acesso>(new AcessoEntityTypeConfiguration());
        }
    }
}
