using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreCompleteGuide_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class correctingMistake : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMap_Authors_Author_Id1",
                table: "BookAuthorMap");

            migrationBuilder.DropIndex(
                name: "IX_BookAuthorMap_Author_Id1",
                table: "BookAuthorMap");

            migrationBuilder.DropColumn(
                name: "Author_Id1",
                table: "BookAuthorMap");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMap_Authors_Author_Id",
                table: "BookAuthorMap",
                column: "Author_Id",
                principalTable: "Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMap_Authors_Author_Id",
                table: "BookAuthorMap");

            migrationBuilder.AddColumn<int>(
                name: "Author_Id1",
                table: "BookAuthorMap",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthorMap_Author_Id1",
                table: "BookAuthorMap",
                column: "Author_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMap_Authors_Author_Id1",
                table: "BookAuthorMap",
                column: "Author_Id1",
                principalTable: "Authors",
                principalColumn: "Author_Id");
        }
    }
}
