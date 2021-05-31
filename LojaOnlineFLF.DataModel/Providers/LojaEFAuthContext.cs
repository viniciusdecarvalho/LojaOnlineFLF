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
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new FuncionarioEntityTypeConfiguration());
            builder.ApplyConfiguration(new AcessoEntityTypeConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
