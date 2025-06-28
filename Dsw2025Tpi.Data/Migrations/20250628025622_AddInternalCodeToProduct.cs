using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dsw2025Tpi.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddInternalCodeToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "Products",
                newName: "stockQuantity");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "currentUnitPrice");

            migrationBuilder.AddColumn<string>(
                name: "InternalCode",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InternalCode",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "stockQuantity",
                table: "Products",
                newName: "Stock");

            migrationBuilder.RenameColumn(
                name: "currentUnitPrice",
                table: "Products",
                newName: "Price");
        }
    }
}
