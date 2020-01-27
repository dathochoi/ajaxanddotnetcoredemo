using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class Updatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Salary = table.Column<float>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "CreatedDate", "Name", "Salary", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 23, 0, 0, 0, 0, DateTimeKind.Local), "Nguyen Van A", 20000f, true },
                    { 2, new DateTime(2020, 1, 23, 0, 0, 0, 0, DateTimeKind.Local), "Nguyen Van B", 3000f, true },
                    { 3, new DateTime(2020, 1, 23, 0, 0, 0, 0, DateTimeKind.Local), "Nguyen Van F", 80000f, true },
                    { 4, new DateTime(2020, 1, 23, 0, 0, 0, 0, DateTimeKind.Local), "Nguyen Van A", 20000f, true },
                    { 5, new DateTime(2020, 1, 23, 0, 0, 0, 0, DateTimeKind.Local), "Van D", 5000f, true },
                    { 6, new DateTime(2020, 1, 23, 0, 0, 0, 0, DateTimeKind.Local), " Van A", 13000f, true },
                    { 7, new DateTime(2020, 1, 23, 0, 0, 0, 0, DateTimeKind.Local), "Nguyen C", 90000f, true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
