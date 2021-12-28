using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab2.Migrations
{
    public partial class code_first_initialize_my_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimalTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfLegs = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalTypeID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Animals_AnimalTypes",
                        column: x => x.AnimalTypeID,
                        principalTable: "AnimalTypes",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "AnimalTypes",
                columns: new[] { "ID", "Name", "NumberOfLegs" },
                values: new object[] { 1, "dog", 4 });

            migrationBuilder.InsertData(
                table: "AnimalTypes",
                columns: new[] { "ID", "Name", "NumberOfLegs" },
                values: new object[] { 2, "bird", 2 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "ID", "AnimalTypeID", "DateOfBirth", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 12, 28, 20, 33, 52, 499, DateTimeKind.Local).AddTicks(9381), "Animal1" },
                    { 2, 1, new DateTime(2021, 12, 28, 20, 33, 52, 499, DateTimeKind.Local).AddTicks(9430), "Animal2" },
                    { 3, 1, new DateTime(2021, 12, 28, 20, 33, 52, 499, DateTimeKind.Local).AddTicks(9433), "Animal3" },
                    { 4, 2, new DateTime(2021, 12, 28, 20, 33, 52, 499, DateTimeKind.Local).AddTicks(9435), "Animal4" },
                    { 5, 2, new DateTime(2021, 12, 28, 20, 33, 52, 499, DateTimeKind.Local).AddTicks(9437), "Animal5" },
                    { 6, 2, new DateTime(2021, 12, 28, 20, 33, 52, 499, DateTimeKind.Local).AddTicks(9439), "Animal6" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_AnimalTypeID",
                table: "Animals",
                column: "AnimalTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "AnimalTypes");
        }
    }
}
