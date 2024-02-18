using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternshipTask.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ManufacturePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufactureEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatorId", "IsAvailable", "ManufactureEmail", "ManufacturePhone", "Name", "ProductDate" },
                values: new object[] { new Guid("3726979c-1c78-4308-9e8a-84f5c390fb3a"), new Guid("a9f2cf0b-3ef2-4ac7-ba49-94e9e9c0c0a2"), true, "nadine@nadinsoft.com", "09994994949", "NadineSoft", new DateTime(2024, 1, 1, 0, 1, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
