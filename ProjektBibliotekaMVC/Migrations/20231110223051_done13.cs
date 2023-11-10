using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjektBibliotekaMVC.Migrations
{
    /// <inheritdoc />
    public partial class done13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "WaitingBook",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBookCopy = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaitingBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaitingBook_AspNetUsers_IdUser",
                        column: x => x.IdUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WaitingBook_BooksCopies_IdBookCopy",
                        column: x => x.IdBookCopy,
                        principalTable: "BooksCopies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_WaitingBook_IdBookCopy",
                table: "WaitingBook",
                column: "IdBookCopy",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WaitingBook_IdUser",
                table: "WaitingBook",
                column: "IdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WaitingBook");

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
    }
}
