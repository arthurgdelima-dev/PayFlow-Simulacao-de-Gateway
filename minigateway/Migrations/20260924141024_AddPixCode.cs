using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minigateway.Migrations
{
    /// <inheritdoc />
    public partial class AddPixCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PixCode",
                table: "Payments",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PixCode",
                table: "Payments");
        }
    }
}
