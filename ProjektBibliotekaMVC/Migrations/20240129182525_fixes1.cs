using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjektBibliotekaMVC.Migrations
{
    /// <inheritdoc />
    public partial class fixes1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowsHistory_Books_IdBook",
                table: "BorrowsHistory");

            migrationBuilder.DropIndex(
                name: "IX_BorrowsHistory_IdBook",
                table: "BorrowsHistory");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a2c0431-f04d-470d-8214-a169aec23fea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa11490d-848a-46c1-aa9c-e0e40f47489d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "28bdaded-17e9-48ca-9565-1a43604992e4", "9a9140cc-cff2-4589-900c-2086fa1febf2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28bdaded-17e9-48ca-9565-1a43604992e4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a9140cc-cff2-4589-900c-2086fa1febf2");

            migrationBuilder.AddColumn<string>(
                name: "BookISBN",
                table: "BorrowsHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "BorrowsHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookTitle",
                table: "BorrowsHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "25aa9b3f-306c-4409-9037-6dce38da9932", null, "Employee", "Employee" },
                    { "9f5041a4-3f20-4472-86c4-0c13ec83c610", null, "Admin", "Admin" },
                    { "eb7c8c03-4658-410a-affb-0af26d57f63a", null, "Customer", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fbe7a13e-2aa2-4583-a5d1-6b946fe26fa8", 0, "c9ec22f7-a184-4138-b65c-565fcfe08bc4", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEPUNEAqcNcxGGHdqJaBhLcNgI80cGZXZUhMi7wKsptS9IJTF6BzFh8AlQAaDSqeA5g==", null, false, "0debacae-74d3-431e-9287-884125f9e572", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9f5041a4-3f20-4472-86c4-0c13ec83c610", "fbe7a13e-2aa2-4583-a5d1-6b946fe26fa8" });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowsHistory_BookId",
                table: "BorrowsHistory",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowsHistory_Books_BookId",
                table: "BorrowsHistory",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowsHistory_Books_BookId",
                table: "BorrowsHistory");

            migrationBuilder.DropIndex(
                name: "IX_BorrowsHistory_BookId",
                table: "BorrowsHistory");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25aa9b3f-306c-4409-9037-6dce38da9932");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb7c8c03-4658-410a-affb-0af26d57f63a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9f5041a4-3f20-4472-86c4-0c13ec83c610", "fbe7a13e-2aa2-4583-a5d1-6b946fe26fa8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f5041a4-3f20-4472-86c4-0c13ec83c610");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fbe7a13e-2aa2-4583-a5d1-6b946fe26fa8");

            migrationBuilder.DropColumn(
                name: "BookISBN",
                table: "BorrowsHistory");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BorrowsHistory");

            migrationBuilder.DropColumn(
                name: "BookTitle",
                table: "BorrowsHistory");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28bdaded-17e9-48ca-9565-1a43604992e4", null, "Admin", "Admin" },
                    { "6a2c0431-f04d-470d-8214-a169aec23fea", null, "Employee", "Employee" },
                    { "fa11490d-848a-46c1-aa9c-e0e40f47489d", null, "Customer", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9a9140cc-cff2-4589-900c-2086fa1febf2", 0, "4d7eb2d3-b278-42b2-a6ac-7cbe3a1948d5", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEPUNEAqcNcxGGHdqJaBhLcNgI80cGZXZUhMi7wKsptS9IJTF6BzFh8AlQAaDSqeA5g==", null, false, "59e44b58-9250-4b12-a24d-572301598f28", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "28bdaded-17e9-48ca-9565-1a43604992e4", "9a9140cc-cff2-4589-900c-2086fa1febf2" });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowsHistory_IdBook",
                table: "BorrowsHistory",
                column: "IdBook");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowsHistory_Books_IdBook",
                table: "BorrowsHistory",
                column: "IdBook",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
