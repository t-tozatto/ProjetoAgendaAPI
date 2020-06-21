using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoAgendaAPI.Migrations
{
    public partial class RemovendoCampoFotoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "foto",
                table: "usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "foto",
                table: "usuario",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
