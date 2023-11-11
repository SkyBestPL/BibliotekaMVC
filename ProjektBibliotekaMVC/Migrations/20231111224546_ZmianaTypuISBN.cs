using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjektBibliotekaMVC.Migrations
{
    /// <inheritdoc />
    public partial class ZmianaTypuISBN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f9db6a4-2079-4cc7-b654-eecce2524547");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "839ff988-0351-458d-8baf-3a1ba452b797");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b715cd2b-48d5-4e79-a8b2-76dabb588d7d", "10fbf09f-bf39-4c19-a923-0f3b855586ec" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b715cd2b-48d5-4e79-a8b2-76dabb588d7d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10fbf09f-bf39-4c19-a923-0f3b855586ec");

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e8df28a-dfd2-400f-baa8-39c4436a6c64", null, "Customer", "Customer" },
                    { "6f62b845-6858-419c-b98c-44901adaf1bf", null, "Admin", "Admin" },
                    { "f90f1fad-4d52-42f9-873e-5455e4466e03", null, "Employee", "Employee" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ed5f8844-e71f-4387-b7e8-8aed25406d54", 0, "638961dd-025f-4802-8180-e8785de27fc0", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEPUNEAqcNcxGGHdqJaBhLcNgI80cGZXZUhMi7wKsptS9IJTF6BzFh8AlQAaDSqeA5g==", null, false, "575d17e2-2684-4667-82dc-573e7c30a95c", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6f62b845-6858-419c-b98c-44901adaf1bf", "ed5f8844-e71f-4387-b7e8-8aed25406d54" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e8df28a-dfd2-400f-baa8-39c4436a6c64");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f90f1fad-4d52-42f9-873e-5455e4466e03");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6f62b845-6858-419c-b98c-44901adaf1bf", "ed5f8844-e71f-4387-b7e8-8aed25406d54" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f62b845-6858-419c-b98c-44901adaf1bf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed5f8844-e71f-4387-b7e8-8aed25406d54");

            migrationBuilder.AlterColumn<int>(
                name: "ISBN",
                table: "Books",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f9db6a4-2079-4cc7-b654-eecce2524547", null, "Employee", "Employee" },
                    { "839ff988-0351-458d-8baf-3a1ba452b797", null, "Customer", "Customer" },
                    { "b715cd2b-48d5-4e79-a8b2-76dabb588d7d", null, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "10fbf09f-bf39-4c19-a923-0f3b855586ec", 0, "ee58a062-f6d9-47f5-b095-0e8963f71b2e", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEPUNEAqcNcxGGHdqJaBhLcNgI80cGZXZUhMi7wKsptS9IJTF6BzFh8AlQAaDSqeA5g==", null, false, "ffbabe86-aa06-4992-8b97-0f9bcec60d26", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b715cd2b-48d5-4e79-a8b2-76dabb588d7d", "10fbf09f-bf39-4c19-a923-0f3b855586ec" });
        }
    }
}
