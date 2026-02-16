using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cliente.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixMigrationVendedor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Vendedores");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "Vendedores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
