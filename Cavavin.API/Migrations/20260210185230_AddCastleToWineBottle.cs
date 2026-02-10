using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cavavin.API.Migrations
{
    /// <inheritdoc />
    public partial class AddCastleToWineBottle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Castle",
                table: "WineBottles",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Castle",
                table: "WineBottles");
        }
    }
}
