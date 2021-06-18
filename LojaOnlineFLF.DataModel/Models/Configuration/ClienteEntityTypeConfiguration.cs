using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaOnlineFLF.DataModel.Models.Configuration
{
    public class ClienteEntityTypeConfiguration : IEntityTypeConfiguration<Cliente>
    {        
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder
                .HasAlternateKey(a => a.Cpf);
        }
    }
}
