using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreCompleteGuide_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changePrimaryKeyAndRequiredInGenre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "db_genres",
                newName: "Genre_Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "db_genres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Genre_Id",
                table: "db_genres",
                newName: "GenreId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "db_genres",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
