using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoAgendaAPI.Migrations
{
    public partial class AtualizandoCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Contato",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Contato");
        }
    }
}
