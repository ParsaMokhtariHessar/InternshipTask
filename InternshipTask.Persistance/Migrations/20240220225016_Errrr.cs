using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternshipTask.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Errrr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManufactureEmail",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ManufacturePhone",
                table: "Products",
                newName: "ManufacturerPhone");

            migrationBuilder.AddColumn<string>(
                name: "ManufacturerEmail",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3726979c-1c78-4308-9e8a-84f5c390fb3a"),
                column: "ManufacturerEmail",
                value: "nadine@nadinsoft.com");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManufacturerEmail",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ManufacturerPhone",
                table: "Products",
                newName: "ManufacturePhone");

            migrationBuilder.AddColumn<string>(
                name: "ManufactureEmail",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3726979c-1c78-4308-9e8a-84f5c390fb3a"),
                column: "ManufactureEmail",
                value: "nadine@nadinsoft.com");
        }
    }
}
