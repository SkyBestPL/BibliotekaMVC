using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjektBibliotekaMVC.Migrations
{
    /// <inheritdoc />
    public partial class done10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ef9696c-065c-4ab0-b8b5-5c275f6d197d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "491d31f0-2b18-4d6d-9ee6-ec7daeb065e0");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "be6f2179-4c7d-462d-a6c2-9afb495164f8", "4d377c6e-34c1-48ac-991f-319b23047936" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be6f2179-4c7d-462d-a6c2-9afb495164f8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4d377c6e-34c1-48ac-991f-319b23047936");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "428f85d8-9389-4970-9311-b5b1376eceb7", null, "Employee", "Employee" },
                    { "bb931e3b-b21d-44e1-9ffb-45de50dcae00", null, "Customer", "Customer" },
                    { "fd15fc01-de52-46ab-bfbe-2d05b851e786", null, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b3fdb3a4-f39b-41e0-a909-03587bc25ee5", 0, "35cedf19-6eb2-4408-914d-1ad66900c65c", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "Qwerty#123", null, false, "6b523a7f-73b4-4ca8-88a6-bb1e1e50d60e", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fd15fc01-de52-46ab-bfbe-2d05b851e786", "b3fdb3a4-f39b-41e0-a909-03587bc25ee5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "428f85d8-9389-4970-9311-b5b1376eceb7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb931e3b-b21d-44e1-9ffb-45de50dcae00");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fd15fc01-de52-46ab-bfbe-2d05b851e786", "b3fdb3a4-f39b-41e0-a909-03587bc25ee5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd15fc01-de52-46ab-bfbe-2d05b851e786");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b3fdb3a4-f39b-41e0-a909-03587bc25ee5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3ef9696c-065c-4ab0-b8b5-5c275f6d197d", null, "Customer", "Customer" },
                    { "491d31f0-2b18-4d6d-9ee6-ec7daeb065e0", null, "Employee", "Employee" },
                    { "be6f2179-4c7d-462d-a6c2-9afb495164f8", null, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4d377c6e-34c1-48ac-991f-319b23047936", 0, "0d876edf-71dc-4077-a598-b7647d07a5cd", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", null, null, false, "f61c32f5-d75f-41b1-9521-3576c7c97c5d", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "be6f2179-4c7d-462d-a6c2-9afb495164f8", "4d377c6e-34c1-48ac-991f-319b23047936" });
        }
    }
}
