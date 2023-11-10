using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjektBibliotekaMVC.Migrations
{
    /// <inheritdoc />
    public partial class done12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "1ce3bdb1-3cf6-46d0-b313-ae587ef63034", null, "Customer", "Customer" },
                    { "3b228713-b4c2-4507-b448-de00eaf96cbe", null, "Employee", "Employee" },
                    { "a6637e3d-b8a1-42a7-8da9-07b05306cfb0", null, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4f0aafb3-758d-4ad2-8297-20db0d4661a8", 0, "8053421e-1e12-4038-bb62-74a008e6c16a", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEPUNEAqcNcxGGHdqJaBhLcNgI80cGZXZUhMi7wKsptS9IJTF6BzFh8AlQAaDSqeA5g==", null, false, "a0e721ed-33fc-4c96-98cc-dd659fd2cb4c", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a6637e3d-b8a1-42a7-8da9-07b05306cfb0", "4f0aafb3-758d-4ad2-8297-20db0d4661a8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ce3bdb1-3cf6-46d0-b313-ae587ef63034");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b228713-b4c2-4507-b448-de00eaf96cbe");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a6637e3d-b8a1-42a7-8da9-07b05306cfb0", "4f0aafb3-758d-4ad2-8297-20db0d4661a8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6637e3d-b8a1-42a7-8da9-07b05306cfb0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f0aafb3-758d-4ad2-8297-20db0d4661a8");

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
    }
}
