using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaOnlineFLF.DataModel.Models.Configuration
{
    public class VendaEntityTypeConfiguration : IEntityTypeConfiguration<Venda>
    {        
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder
                .Property(x => x.Situacao)
                .HasConversion(
                    c => c.Codigo,
                    c => VendaSituacao.From(c));
        }
    }
}
