using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cavavin.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        private const string TableName = "wine_bottles";
        private static readonly string[] Columns = new[] { "id", "domain", "end_maturity", "food_pairing_keywords", "is_favorite", "name", "quantity", "region", "start_maturity", "type", "vintage" };

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: TableName,
                columns: Columns,
                values: new object[,]
                {
                    { 1, "Chateau Margaux", 2050, "agneau,gibier,boeuf", true, "Chateau Margaux", 3, "bordeaux", 2025, "red", 2015 },
                    { 2, "Mailly Grand Cru", 2035, "aperitif,huitres,crevettes", false, "Cuvee des Enchanteleurs", 6, "champagne", 2020, "sparkling", 2012 },
                    { 3, "Henri Bourgeois", 2028, "poisson,chevre,volaille", true, "Sancerre d'Antan", 4, "loire", 2023, "white", 2021 },
                    { 4, "E. Guigal", 2045, "viande rouge,agneau,truffes", true, "Cote Rotie La Mouline", 2, "rhone", 2026, "red", 2018 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: TableName,
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: TableName,
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: TableName,
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: TableName,
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
