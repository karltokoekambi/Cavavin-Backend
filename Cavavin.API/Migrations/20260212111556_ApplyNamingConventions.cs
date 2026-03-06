using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cavavin.API.Migrations
{
    /// <inheritdoc />
    public partial class ApplyNamingConventions : Migration
    {
        private const string NewTableName = "wine_bottles";
        private const string OldTableName = "WineBottles";
        
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WineBottles",
                table: OldTableName);

            migrationBuilder.DropColumn(
                name: "Castle",
                table: OldTableName);

            migrationBuilder.RenameTable(
                name: OldTableName,
                newName: NewTableName);

            migrationBuilder.RenameColumn(
                name: "Region",
                table: NewTableName,
                newName: "region");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: NewTableName,
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: NewTableName,
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: NewTableName,
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: NewTableName,
                newName: "vintage");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: NewTableName,
                newName: "type");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: NewTableName,
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "domain",
                table: NewTableName,
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "end_maturity",
                table: NewTableName,
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "food_pairing_keywords",
                table: NewTableName,
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "is_favorite",
                table: NewTableName,
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "start_maturity",
                table: NewTableName,
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_wine_bottles",
                table: NewTableName,
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_wine_bottles",
                table: NewTableName);

            migrationBuilder.DropColumn(
                name: "domain",
                table: NewTableName);

            migrationBuilder.DropColumn(
                name: "end_maturity",
                table: NewTableName);

            migrationBuilder.DropColumn(
                name: "food_pairing_keywords",
                table: NewTableName);

            migrationBuilder.DropColumn(
                name: "is_favorite",
                table: NewTableName);

            migrationBuilder.DropColumn(
                name: "start_maturity",
                table: NewTableName);

            migrationBuilder.RenameTable(
                name: NewTableName,
                newName: OldTableName);

            migrationBuilder.RenameColumn(
                name: "region",
                table: OldTableName,
                newName: "Region");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: OldTableName,
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "name",
                table: OldTableName,
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: OldTableName,
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "vintage",
                table: OldTableName,
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "type",
                table: OldTableName,
                newName: "Color");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: OldTableName,
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Castle",
                table: OldTableName,
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WineBottles",
                table: OldTableName,
                column: "Id");
        }
    }
}
