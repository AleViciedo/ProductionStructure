using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductionStructure.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CountryName = table.Column<string>(name: "Country Name", type: "TEXT", nullable: true),
                    PhoneCode = table.Column<string>(name: "Phone Code", type: "TEXT", nullable: true),
                    ShortCode = table.Column<string>(name: "Short Code", type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Email_Username = table.Column<string>(type: "TEXT", nullable: true),
                    Email_Server = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber_Country = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber_Phone = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SiteId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Work Centers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    WorkMode = table.Column<int>(type: "INTEGER", nullable: false),
                    AreaId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Work Centers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Work Centers_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Manufacturer = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CurrentWorkSessionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    WorkCenterId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Units_Work Centers_WorkCenterId",
                        column: x => x.WorkCenterId,
                        principalTable: "Work Centers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Work Sessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UnitId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Work Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Work Sessions_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_SiteId",
                table: "Areas",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_CurrentWorkSessionId",
                table: "Units",
                column: "CurrentWorkSessionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_WorkCenterId",
                table: "Units",
                column: "WorkCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Work Centers_AreaId",
                table: "Work Centers",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Work Sessions_UnitId",
                table: "Work Sessions",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Work Sessions_CurrentWorkSessionId",
                table: "Units",
                column: "CurrentWorkSessionId",
                principalTable: "Work Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Sites_SiteId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Work Centers_WorkCenterId",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Work Sessions_CurrentWorkSessionId",
                table: "Units");

            migrationBuilder.DropTable(
                name: "Sites");

            migrationBuilder.DropTable(
                name: "Work Centers");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Work Sessions");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
