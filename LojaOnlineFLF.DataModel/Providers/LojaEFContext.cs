using LojaOnlineFLF.DataModel.Models;
using LojaOnlineFLF.DataModel.Models.Configuration;
using Microsoft.EntityFrameworkCore;

namespace LojaOnlineFLF.DataModel.Providers
{
    ///<summary>
    /// EntityFramework contexto
    ///</summary>
    public class LojaEFContext : DbContext
    {
        ///<summary>
        /// Construtor padrao
        ///</summary>
        public LojaEFContext(DbContextOptions<LojaEFContext> options)
          : base(options)
        {}

        ///<summary>
        /// Manter dados de vendas
        ///</summary>Í
        public DbSet<Venda> Vendas { get; set; }

        ///<summary>
        /// Manter dados de clientes
        ///</summary>Í
        public DbSet<Cliente> Clientes { get; set; }

        ///<summary>
        /// Manter dados de produtos
        ///</summary>Í
        public DbSet<Produto> Produtos { get; set; }

        ///<summary>
        /// Manter dados de funcionarios
        ///</summary>Í
        public DbSet<Funcionario> Funcionarios { get; set; }

        ///<summary>
        /// Manter dados de cargos
        ///</summary>
        public DbSet<Cargo> Cargos { get; set; }

        ///<summary>
        /// Manter dados de acesso
        ///</summary>
        public DbSet<Acesso> Acessos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FuncionarioEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AcessoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CargoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VendaEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}