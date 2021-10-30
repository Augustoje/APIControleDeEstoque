using Microsoft.EntityFrameworkCore.Migrations;

namespace EstoqueApi.Migrations
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nomeCategoria",
                table: "Produto",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Categoria",
                newName: "nomeCategoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Produto",
                newName: "nomeCategoria");

            migrationBuilder.RenameColumn(
                name: "nomeCategoria",
                table: "Categoria",
                newName: "nome");
        }
    }
}
