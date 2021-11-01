using Microsoft.EntityFrameworkCore.Migrations;

namespace EstoqueApi.Migrations
{
    public partial class AtualiaçãoVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "valorUnitario",
                table: "Venda",
                newName: "total");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Venda",
                newName: "precoUnitario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "total",
                table: "Venda",
                newName: "valorUnitario");

            migrationBuilder.RenameColumn(
                name: "precoUnitario",
                table: "Venda",
                newName: "Valor");
        }
    }
}
