using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjektBibliotekaMVC.Migrations
{
    /// <inheritdoc />
    public partial class start : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c2968b5-698e-421e-8ff1-200adfdc6551");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c1005ce-496d-4119-b486-39b1777c946d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e7eaaf3d-1a9c-41dd-b18c-d0777783ac01", "92c21599-2954-4a0a-88b3-f8666c16903c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7eaaf3d-1a9c-41dd-b18c-d0777783ac01");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92c21599-2954-4a0a-88b3-f8666c16903c");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "5c2968b5-698e-421e-8ff1-200adfdc6551", null, "Employee", "Employee" },
                    { "8c1005ce-496d-4119-b486-39b1777c946d", null, "Customer", "Customer" },
                    { "e7eaaf3d-1a9c-41dd-b18c-d0777783ac01", null, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "92c21599-2954-4a0a-88b3-f8666c16903c", 0, "8388b3ab-c4fc-4dea-a3a4-957bf7e3fafb", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEPUNEAqcNcxGGHdqJaBhLcNgI80cGZXZUhMi7wKsptS9IJTF6BzFh8AlQAaDSqeA5g==", null, false, "f0ffad36-90da-4428-a5b8-52898e3b846b", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e7eaaf3d-1a9c-41dd-b18c-d0777783ac01", "92c21599-2954-4a0a-88b3-f8666c16903c" });
        }
    }
}
