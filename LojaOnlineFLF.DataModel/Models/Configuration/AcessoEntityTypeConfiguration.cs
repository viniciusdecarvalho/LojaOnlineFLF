using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaOnlineFLF.DataModel.Models.Configuration
{
    public class AcessoEntityTypeConfiguration: IEntityTypeConfiguration<Acesso>
    {        
        public void Configure(EntityTypeBuilder<Acesso> builder)
        {
            /*
            builder
                .HasOne(x => x.Funcionario)
                .WithOne(x => x.Acesso)
                .HasForeignKey<Acesso>(x => x.FuncionarioId);
            */
        }
    }
}
