using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektBibliotekaMVC.Migrations
{
    /// <inheritdoc />
    public partial class done4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdAuthor",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "IdCathegory",
                table: "Books",
                newName: "IdCategory");

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AuthorSurename",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorSurename",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "IdCategory",
                table: "Books",
                newName: "IdCathegory");

            migrationBuilder.AddColumn<int>(
                name: "IdAuthor",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
