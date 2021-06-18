using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaOnlineFLF.DataModel.Migrations
{
    public partial class AcessoEntityIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Acessos");

            migrationBuilder.RenameColumn(
                name: "Usuario",
                table: "Acessos",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Chave",
                table: "Acessos",
                newName: "SecurityStamp");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Acessos",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Acessos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Acessos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Acessos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Acessos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Acessos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Acessos",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Acessos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Acessos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Acessos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Acessos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Acessos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Acessos",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Acessos");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Acessos");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Acessos");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Acessos");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Acessos");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Acessos");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Acessos");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Acessos");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Acessos");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Acessos");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Acessos");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Acessos");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Acessos",
                newName: "Usuario");

            migrationBuilder.RenameColumn(
                name: "SecurityStamp",
                table: "Acessos",
                newName: "Chave");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Acessos",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Acessos",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
