using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaOnlineFLF.DataModel.Models.Configuration
{
    public class CargoEntityTypeConfiguration : IEntityTypeConfiguration<Cargo>
    {        
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            /*
            builder
                .HasMany(x => x.Funcionarios)
                .WithOne(x => x.Cargo)
                .HasForeignKey(x => x.AcessoId);
            */
        }
    }
}
