using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cliente.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPedidoIdToProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MarcaProduto",
                table: "Produtos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarcaProduto",
                table: "Produtos");
        }
    }
}
