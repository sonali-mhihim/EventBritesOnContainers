using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "catalog_event_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "catalog_hosts_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "catalog_types_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "CatalogEventHosts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogEventHosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogEventTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogEventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogEvents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PictureUrl = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Location = table.Column<string>(maxLength: 200, nullable: false),
                    CatalogHostId = table.Column<int>(nullable: false),
                    CatalogTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogEvents_CatalogEventHosts_CatalogHostId",
                        column: x => x.CatalogHostId,
                        principalTable: "CatalogEventHosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogEvents_CatalogEventTypes_CatalogTypeId",
                        column: x => x.CatalogTypeId,
                        principalTable: "CatalogEventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogEvents_CatalogHostId",
                table: "CatalogEvents",
                column: "CatalogHostId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogEvents_CatalogTypeId",
                table: "CatalogEvents",
                column: "CatalogTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogEvents");

            migrationBuilder.DropTable(
                name: "CatalogEventHosts");

            migrationBuilder.DropTable(
                name: "CatalogEventTypes");

            migrationBuilder.DropSequence(
                name: "catalog_event_hilo");

            migrationBuilder.DropSequence(
                name: "catalog_hosts_hilo");

            migrationBuilder.DropSequence(
                name: "catalog_types_hilo");
        }
    }
}
