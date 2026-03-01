using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SastoTech.Migrations
{
    /// <inheritdoc />
    public partial class AddLowestPriceEver : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "LowestPriceEver",
                table: "Mobiles",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "LowestPriceEver",
                table: "Laptops",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LowestPriceEver",
                table: "Mobiles");

            migrationBuilder.DropColumn(
                name: "LowestPriceEver",
                table: "Laptops");
        }
    }
}
