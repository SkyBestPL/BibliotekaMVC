using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjektBibliotekaMVC.Migrations
{
    /// <inheritdoc />
    public partial class done3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "79fdb5b1-8933-405d-aa7f-dfd91d089d79", null, "Customer", "Customer" },
                    { "a6ae356d-65e1-4d92-8083-660360aa8c21", null, "Employee", "Employee" },
                    { "ab26f24b-b33f-471b-98f0-5a342603b890", null, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7573a846-0687-4ea8-8f01-8454b4840cc5", 0, "524b3586-f66c-45ed-8d65-f583ac0545d8", "admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", null, null, false, "ce1051b6-fab0-4567-a2cb-ce3294c14dcd", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ab26f24b-b33f-471b-98f0-5a342603b890", "7573a846-0687-4ea8-8f01-8454b4840cc5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79fdb5b1-8933-405d-aa7f-dfd91d089d79");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6ae356d-65e1-4d92-8083-660360aa8c21");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ab26f24b-b33f-471b-98f0-5a342603b890", "7573a846-0687-4ea8-8f01-8454b4840cc5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab26f24b-b33f-471b-98f0-5a342603b890");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7573a846-0687-4ea8-8f01-8454b4840cc5");
        }
    }
}
