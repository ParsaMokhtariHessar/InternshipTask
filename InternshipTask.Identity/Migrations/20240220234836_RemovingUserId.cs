using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternshipTask.Identity.Migrations
{
    /// <inheritdoc />
    public partial class RemovingUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9f2cf0b-3ef2-4ac7-ba49-94e9e9c0c0a2"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "99d604e6-6e41-45e3-a0b6-5d16bf6835dc", "PARSA", "$2a$11$3uX33CnjEASDcoZwQ9Eii.o6VbgrQk5T3Ej2Ov0Rr.HPxuSEWYcrS" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9f2cf0b-3ef2-4ac7-ba49-94e9e9c0c0a2"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "UserId" },
                values: new object[] { "913be279-e6bd-438e-8d74-6aeed60de552", null, "$2a$11$Hqjcd.tOm.c2A31r4nCpo.nc7JNb4odsfBmTYX9YXrlzNilnetFsW", new Guid("474d474d-6559-4ce4-a7f8-ba4b1b2c2b0f") });
        }
    }
}
