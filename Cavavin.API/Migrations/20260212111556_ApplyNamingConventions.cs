using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cavavin.API.Migrations
{
    /// <inheritdoc />
    public partial class ApplyNamingConventions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WineBottles",
                table: "WineBottles");

            migrationBuilder.DropColumn(
                name: "Castle",
                table: "WineBottles");

            migrationBuilder.RenameTable(
                name: "WineBottles",
                newName: "wine_bottles");

            migrationBuilder.RenameColumn(
                name: "Region",
                table: "wine_bottles",
                newName: "region");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "wine_bottles",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "wine_bottles",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "wine_bottles",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "wine_bottles",
                newName: "vintage");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "wine_bottles",
                newName: "type");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "wine_bottles",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "domain",
                table: "wine_bottles",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "end_maturity",
                table: "wine_bottles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "food_pairing_keywords",
                table: "wine_bottles",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "is_favorite",
                table: "wine_bottles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "start_maturity",
                table: "wine_bottles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_wine_bottles",
                table: "wine_bottles",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_wine_bottles",
                table: "wine_bottles");

            migrationBuilder.DropColumn(
                name: "domain",
                table: "wine_bottles");

            migrationBuilder.DropColumn(
                name: "end_maturity",
                table: "wine_bottles");

            migrationBuilder.DropColumn(
                name: "food_pairing_keywords",
                table: "wine_bottles");

            migrationBuilder.DropColumn(
                name: "is_favorite",
                table: "wine_bottles");

            migrationBuilder.DropColumn(
                name: "start_maturity",
                table: "wine_bottles");

            migrationBuilder.RenameTable(
                name: "wine_bottles",
                newName: "WineBottles");

            migrationBuilder.RenameColumn(
                name: "region",
                table: "WineBottles",
                newName: "Region");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "WineBottles",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "WineBottles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "WineBottles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "vintage",
                table: "WineBottles",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "WineBottles",
                newName: "Color");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "WineBottles",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Castle",
                table: "WineBottles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WineBottles",
                table: "WineBottles",
                column: "Id");
        }
    }
}
