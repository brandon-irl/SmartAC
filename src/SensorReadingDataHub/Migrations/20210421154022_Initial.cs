using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SensorReadingDataHub.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SensorReading",
                columns: table => new
                {
                    DeviceSerialNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Temperature = table.Column<double>(type: "REAL", nullable: false),
                    Humidity = table.Column<int>(type: "INTEGER", nullable: false),
                    COLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    HealthStatus = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorReading", x => new { x.DeviceSerialNumber, x.Time });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SensorReading");
        }
    }
}
