using LojaOnlineFLF.DataModel.Models;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaOnlineFLF.DataModel.Migrations
{
    public partial class CargaCargos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string[] columns = new string[] { "Id", "Nome" };
            object[,] values = new object[,] { { Cargo.Gerente, "Gerente" }, { Cargo.Operacional, "Operacional" } };
            migrationBuilder.InsertData("Cargos", columns, values);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
