using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaOnlineFLF.DataModel.Migrations
{
    public partial class AlteracoesPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VendaItem_Produtos_ProdutoId",
                table: "VendaItem");

            migrationBuilder.DropForeignKey(
                name: "FK_VendaItem_Vendas_VendaId",
                table: "VendaItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Funcionarios_FuncionarioId",
                table: "Vendas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VendaItem",
                table: "VendaItem");

            migrationBuilder.RenameTable(
                name: "VendaItem",
                newName: "VendasItens");

            migrationBuilder.RenameIndex(
                name: "IX_VendaItem_VendaId",
                table: "VendasItens",
                newName: "IX_VendasItens_VendaId");

            migrationBuilder.RenameIndex(
                name: "IX_VendaItem_ProdutoId",
                table: "VendasItens",
                newName: "IX_VendasItens_ProdutoId");

            migrationBuilder.AlterColumn<Guid>(
                name: "FuncionarioId",
                table: "Vendas",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VendasItens",
                table: "VendasItens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Funcionarios_FuncionarioId",
                table: "Vendas",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VendasItens_Produtos_ProdutoId",
                table: "VendasItens",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VendasItens_Vendas_VendaId",
                table: "VendasItens",
                column: "VendaId",
                principalTable: "Vendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Funcionarios_FuncionarioId",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_VendasItens_Produtos_ProdutoId",
                table: "VendasItens");

            migrationBuilder.DropForeignKey(
                name: "FK_VendasItens_Vendas_VendaId",
                table: "VendasItens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VendasItens",
                table: "VendasItens");

            migrationBuilder.RenameTable(
                name: "VendasItens",
                newName: "VendaItem");

            migrationBuilder.RenameIndex(
                name: "IX_VendasItens_VendaId",
                table: "VendaItem",
                newName: "IX_VendaItem_VendaId");

            migrationBuilder.RenameIndex(
                name: "IX_VendasItens_ProdutoId",
                table: "VendaItem",
                newName: "IX_VendaItem_ProdutoId");

            migrationBuilder.AlterColumn<Guid>(
                name: "FuncionarioId",
                table: "Vendas",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VendaItem",
                table: "VendaItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VendaItem_Produtos_ProdutoId",
                table: "VendaItem",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VendaItem_Vendas_VendaId",
                table: "VendaItem",
                column: "VendaId",
                principalTable: "Vendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Funcionarios_FuncionarioId",
                table: "Vendas",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
