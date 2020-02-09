using System.Collections.Generic;
using BeAware.Models;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeAware.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Longitude = table.Column<int>(nullable: false),
                    Latitude = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Crime = table.Column<string>(nullable: true),
                    Occured = table.Column<bool>(nullable: false),
                    CrimeDetails = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PlatformName = table.Column<string>(nullable: true),
                    PlatformCategory = table.Column<string>(nullable: true),
                    PlatformDetails = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Devices = table.Column<List<Device>>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
