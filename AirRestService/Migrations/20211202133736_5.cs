using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace AirRestService.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Averages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Temperature = table.Column<string>(type: "varchar(max)", nullable: false),
                    CO2 = table.Column<string>(type: "varchar(max)", nullable: false),
                    Humidity = table.Column<string>(type: "varchar(max)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Averages", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
