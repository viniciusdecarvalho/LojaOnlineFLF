﻿// <auto-generated />
using System;
using LojaOnlineFLF.DataModel.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LojaOnlineFLF.DataModel.Migrations
{
    [DbContext(typeof(LojaEFContext))]
    [Migration("20210523203729_FuncionarioAcesso")]
    partial class FuncionarioAcesso
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("LojaOnlineFLF.DataModel.Models.Acesso", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Chave")
                        .HasColumnType("text");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("FuncionarioId")
                        .HasColumnType("uuid");

                    b.Property<string>("Usuario")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId")
                        .IsUnique();

                    b.ToTable("Acessos");
                });

            modelBuilder.Entity("LojaOnlineFLF.DataModel.Models.Cargo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("LojaOnlineFLF.DataModel.Models.Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("CargoId")
                        .HasColumnType("uuid");

                    b.Property<string>("Cpf")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataInicio")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("LojaOnlineFLF.DataModel.Models.Acesso", b =>
                {
                    b.HasOne("LojaOnlineFLF.DataModel.Models.Funcionario", "Funcionario")
                        .WithOne("Acesso")
                        .HasForeignKey("LojaOnlineFLF.DataModel.Models.Acesso", "FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("LojaOnlineFLF.DataModel.Models.Funcionario", b =>
                {
                    b.HasOne("LojaOnlineFLF.DataModel.Models.Cargo", "Cargo")
                        .WithMany()
                        .HasForeignKey("CargoId");

                    b.Navigation("Cargo");
                });

            modelBuilder.Entity("LojaOnlineFLF.DataModel.Models.Funcionario", b =>
                {
                    b.Navigation("Acesso");
                });
#pragma warning restore 612, 618
        }
    }
}
