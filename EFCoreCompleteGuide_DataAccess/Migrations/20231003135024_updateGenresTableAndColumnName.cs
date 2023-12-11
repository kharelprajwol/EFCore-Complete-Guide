using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreCompleteGuide_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateGenresTableAndColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "db_genres");

            migrationBuilder.RenameColumn(
                name: "GenreName",
                table: "db_genres",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_db_genres",
                table: "db_genres",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_db_genres",
                table: "db_genres");

            migrationBuilder.RenameTable(
                name: "db_genres",
                newName: "Genres");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Genres",
                newName: "GenreName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "GenreId");
        }
    }
}
