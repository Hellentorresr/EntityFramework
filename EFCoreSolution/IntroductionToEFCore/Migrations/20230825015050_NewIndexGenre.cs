using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntroductionToEFCore.Migrations
{
    /// <inheritdoc />
    public partial class NewIndexGenre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FilmGenres_Name",
                table: "FilmGenres",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FilmGenres_Name",
                table: "FilmGenres");
        }
    }
}
