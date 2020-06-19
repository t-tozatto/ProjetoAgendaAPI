using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoAgendaAPI.Migrations
{
    public partial class AtualizandoNomeCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contato",
                table: "Contato");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "usuario");

            migrationBuilder.RenameTable(
                name: "Contato",
                newName: "contato");

            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "usuario",
                newName: "senha");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "usuario",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Foto",
                table: "usuario",
                newName: "foto");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "usuario",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "usuario",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "contato",
                newName: "telefone");

            migrationBuilder.RenameColumn(
                name: "Sobrenome",
                table: "contato",
                newName: "sobrenome");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "contato",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "contato",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "contato",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "contato",
                newName: "id_usuario");

            migrationBuilder.AlterColumn<string>(
                name: "senha",
                table: "usuario",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "usuario",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "usuario",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "telefone",
                table: "contato",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "sobrenome",
                table: "contato",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "contato",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuario",
                table: "usuario",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contato",
                table: "contato",
                column: "id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contato_usuario_id_usuario",
                table: "contato");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuario",
                table: "usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_contato",
                table: "contato");

            migrationBuilder.DropIndex(
                name: "IX_contato_id_usuario",
                table: "contato");

            migrationBuilder.RenameTable(
                name: "usuario",
                newName: "Usuario");

            migrationBuilder.RenameTable(
                name: "contato",
                newName: "Contato");

            migrationBuilder.RenameColumn(
                name: "senha",
                table: "Usuario",
                newName: "Senha");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Usuario",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "foto",
                table: "Usuario",
                newName: "Foto");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Usuario",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Usuario",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "telefone",
                table: "Contato",
                newName: "Telefone");

            migrationBuilder.RenameColumn(
                name: "sobrenome",
                table: "Contato",
                newName: "Sobrenome");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Contato",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Contato",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Contato",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id_usuario",
                table: "Contato",
                newName: "IdUsuario");

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Contato",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sobrenome",
                table: "Contato",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Contato",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contato",
                table: "Contato",
                column: "Id");
        }
    }
}
