using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoAgendaAPI.Migrations
{
    public partial class RetirandoObrigatoriedadeCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contato_usuario_id_usuario",
                table: "contato");

            migrationBuilder.DropIndex(
                name: "IX_contato_id_usuario",
                table: "contato");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_contato_id_usuario",
                table: "contato",
                column: "id_usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_contato_usuario_id_usuario",
                table: "contato",
                column: "id_usuario",
                principalTable: "usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
