using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BasicCRUD.Migrations
{
    /// <inheritdoc />
    public partial class setupBDD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gamers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    FavouriteGame = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gamers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Gamers",
                columns: new[] { "Id", "Age", "FavouriteGame", "Name" },
                values: new object[,]
                {
                    { 1, 32, "Metaphor Re:Fantazio", "BladeRED" },
                    { 2, 26, "Légendes Pokémon: Arceus", "Eurons" },
                    { 3, 33, "Octopath Traveler 2", "Katsuki" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gamers");
        }
    }
}
