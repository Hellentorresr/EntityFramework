using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntroductionToEFCore.Migrations
{
    /// <inheritdoc />
    public partial class MovieGenreRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilmGenreMovie",
                columns: table => new
                {
                    FilmGenresId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmGenreMovie", x => new { x.FilmGenresId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_FilmGenreMovie_FilmGenres_FilmGenresId",
                        column: x => x.FilmGenresId,
                        principalTable: "FilmGenres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmGenreMovie_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmGenreMovie_MoviesId",
                table: "FilmGenreMovie",
                column: "MoviesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmGenreMovie");
        }
    }
}
