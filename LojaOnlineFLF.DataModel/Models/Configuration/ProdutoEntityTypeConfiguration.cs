using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaOnlineFLF.DataModel.Models.Configuration
{
    public class ProdutoEntityTypeConfiguration : IEntityTypeConfiguration<Produto>
    {        
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder
                .HasAlternateKey(a => a.CodigoBarras);
        }
    }
}
