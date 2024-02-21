using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternshipTask.Identity.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cd1f3faf-3b03-4ced-85b8-1ad18aa1e406"), new Guid("a9f2cf0b-3ef2-4ac7-ba49-94e9e9c0c0a2") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cd1f3faf-3b03-4ced-85b8-1ad18aa1e406"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9f2cf0b-3ef2-4ac7-ba49-94e9e9c0c0a2"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("2e7041ef-7b35-4710-b567-d5120a585627"), null, "UserRole", "USERROLE" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("99da5af7-a7c9-41a3-276a-08dc327002ac"), 0, "1e4c2f11-154f-4be9-86fd-feadbe6fb26f", "", true, false, null, "", "PARSAA", "$2a$11$X6G/PMq6vmKcd8gB1KpTu.LfPE8w/Z4LKn78DmhAg3j1/cgmxnofW", null, false, "F5HE5ITOIQO2N3S5ZHUONLICGAQYI56U", false, "parsaa" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("2e7041ef-7b35-4710-b567-d5120a585627"), new Guid("99da5af7-a7c9-41a3-276a-08dc327002ac") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2e7041ef-7b35-4710-b567-d5120a585627"), new Guid("99da5af7-a7c9-41a3-276a-08dc327002ac") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2e7041ef-7b35-4710-b567-d5120a585627"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("99da5af7-a7c9-41a3-276a-08dc327002ac"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("cd1f3faf-3b03-4ced-85b8-1ad18aa1e406"), null, "UserRole", "USERROLE" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("a9f2cf0b-3ef2-4ac7-ba49-94e9e9c0c0a2"), 0, "99d604e6-6e41-45e3-a0b6-5d16bf6835dc", "", true, false, null, "", "PARSA", "$2a$11$3uX33CnjEASDcoZwQ9Eii.o6VbgrQk5T3Ej2Ov0Rr.HPxuSEWYcrS", null, false, null, false, "parsa" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("cd1f3faf-3b03-4ced-85b8-1ad18aa1e406"), new Guid("a9f2cf0b-3ef2-4ac7-ba49-94e9e9c0c0a2") });
        }
    }
}
