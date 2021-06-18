using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaOnlineFLF.DataModel.Migrations
{
    public partial class VendasRelacionamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Situacao",
                table: "Vendas",
                type: "integer",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "smallint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Situacao",
                table: "Vendas",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
