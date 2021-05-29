using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaOnlineFLF.DataModel.Models.Configuration
{
    public class FuncionarioEntityTypeConfiguration : IEntityTypeConfiguration<Funcionario>
    {        
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
