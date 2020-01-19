using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MonctonUG.BlazorServer.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                columns: table => new
                {
                    Date = table.Column<DateTime>(nullable: false),
                    TemperatureC = table.Column<int>(nullable: false),
                    Summary = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecasts", x => x.Date);
                });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Date", "Summary", "TemperatureC" },
                values: new object[] { new DateTime(2020, 1, 18, 21, 29, 20, 659, DateTimeKind.Local).AddTicks(470), "Cold", -10 });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Date", "Summary", "TemperatureC" },
                values: new object[] { new DateTime(2020, 1, 19, 21, 29, 20, 664, DateTimeKind.Local).AddTicks(1065), "Warm", 25 });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Date", "Summary", "TemperatureC" },
                values: new object[] { new DateTime(2020, 1, 20, 21, 29, 20, 664, DateTimeKind.Local).AddTicks(1230), "Unbearably hot", 40 });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Date", "Summary", "TemperatureC" },
                values: new object[] { new DateTime(2020, 1, 21, 21, 29, 20, 664, DateTimeKind.Local).AddTicks(1241), "Deathly cold", -60 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherForecasts");
        }
    }
}
