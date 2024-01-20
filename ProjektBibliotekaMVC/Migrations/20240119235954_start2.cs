using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjektBibliotekaMVC.Migrations
{
    /// <inheritdoc />
    public partial class start2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3729678-f532-41bc-8177-70bf1fd0a3e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd7ac112-dd8c-4a00-bacb-8d7f11f314c5");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3ea09afa-0bf7-47d4-a6d2-ce789d245dd7", "53fed8eb-140d-4144-b27b-211ef7f31dd4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ea09afa-0bf7-47d4-a6d2-ce789d245dd7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "53fed8eb-140d-4144-b27b-211ef7f31dd4");

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
                table: "Limits",
                columns: new[] { "Id", "InMagazineLimit", "WaitingLimit" },
                values: new object[] { 1, 100, 100 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "28bdaded-17e9-48ca-9565-1a43604992e4", "9a9140cc-cff2-4589-900c-2086fa1febf2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                table: "Limits",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28bdaded-17e9-48ca-9565-1a43604992e4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a9140cc-cff2-4589-900c-2086fa1febf2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3ea09afa-0bf7-47d4-a6d2-ce789d245dd7", null, "Admin", "Admin" },
                    { "a3729678-f532-41bc-8177-70bf1fd0a3e4", null, "Customer", "Customer" },
                    { "cd7ac112-dd8c-4a00-bacb-8d7f11f314c5", null, "Employee", "Employee" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "53fed8eb-140d-4144-b27b-211ef7f31dd4", 0, "8e9ba684-032d-4dcf-ae6b-2f1e868283f8", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEPUNEAqcNcxGGHdqJaBhLcNgI80cGZXZUhMi7wKsptS9IJTF6BzFh8AlQAaDSqeA5g==", null, false, "ce976d78-e7df-4c16-a352-7c32775e641c", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3ea09afa-0bf7-47d4-a6d2-ce789d245dd7", "53fed8eb-140d-4144-b27b-211ef7f31dd4" });
        }
    }
}
