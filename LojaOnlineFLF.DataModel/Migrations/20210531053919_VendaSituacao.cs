using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaOnlineFLF.DataModel.Migrations
{
    public partial class VendaSituacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Situacao",
                table: "Vendas",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Situacao",
                table: "Vendas");
        }
    }
}
