using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cliente.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovePedidoIdFromProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                 name: "FK_Produtos_Pedidos_PedidoId",
                 table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_PedidoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Produtos");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
