using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaOnlineFLF.DataModel.Migrations
{
    public partial class NavegacaoFuncionarioAcesso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acessos_Funcionarios_FuncionarioId",
                table: "Acessos");

            migrationBuilder.DropIndex(
                name: "IX_Acessos_FuncionarioId",
                table: "Acessos");

            migrationBuilder.DropColumn(
                name: "AcessoId",
                table: "Funcionarios");

            migrationBuilder.AlterColumn<Guid>(
                name: "FuncionarioId",
                table: "Acessos",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_Acessos_FuncionarioId",
                table: "Acessos",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acessos_Funcionarios_FuncionarioId",
                table: "Acessos",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acessos_Funcionarios_FuncionarioId",
                table: "Acessos");

            migrationBuilder.DropIndex(
                name: "IX_Acessos_FuncionarioId",
                table: "Acessos");

            migrationBuilder.AddColumn<Guid>(
                name: "AcessoId",
                table: "Funcionarios",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FuncionarioId",
                table: "Acessos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Acessos_FuncionarioId",
                table: "Acessos",
                column: "FuncionarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Acessos_Funcionarios_FuncionarioId",
                table: "Acessos",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
