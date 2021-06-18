using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaOnlineFLF.DataModel.Migrations
{
    public partial class UniqueConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CodigoBarras",
                table: "Produtos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Funcionarios",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Clientes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Cargos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Produtos_CodigoBarras",
                table: "Produtos",
                column: "CodigoBarras");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Funcionarios_Cpf",
                table: "Funcionarios",
                column: "Cpf");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Clientes_Cpf",
                table: "Clientes",
                column: "Cpf");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Cargos_Nome",
                table: "Cargos",
                column: "Nome");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Produtos_CodigoBarras",
                table: "Produtos");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Funcionarios_Cpf",
                table: "Funcionarios");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Clientes_Cpf",
                table: "Clientes");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Cargos_Nome",
                table: "Cargos");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoBarras",
                table: "Produtos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Funcionarios",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Clientes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Cargos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
