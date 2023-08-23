using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IntroductionToEFCore.Migrations
{
    /// <inheritdoc />
    public partial class DefaultValFilmGenre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FilmGenres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 9, "Fiction" },
                    { 10, "Animation" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
