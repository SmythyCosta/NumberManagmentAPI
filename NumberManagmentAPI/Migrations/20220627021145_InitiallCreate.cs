using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NumberManagmentAPI.Migrations
{
    public partial class InitiallCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORY",
                columns: table => new
                {
                    CATEGORY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CATEGORY_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CATEGORY_DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DH_CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DH_UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORY", x => x.CATEGORY_ID);
                });

            migrationBuilder.CreateTable(
                name: "EQUIPAMENT",
                columns: table => new
                {
                    ID_EQUIPAMENT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DH_CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DH_UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EQUIPAMENT", x => x.ID_EQUIPAMENT);
                });

            migrationBuilder.CreateTable(
                name: "NUMBER_STATUS",
                columns: table => new
                {
                    ID_NUMBER_STATUS = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NUMBER_STATUS_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NUMBER_STATUS", x => x.ID_NUMBER_STATUS);
                });

            migrationBuilder.CreateTable(
                name: "QUARENTINE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FULL_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    START_DATE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QUANTITY_DAYS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USER_UPDATE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TXT_DESCRIPTION_JOB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DH_CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DH_UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUARENTINE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NUMBER",
                columns: table => new
                {
                    ID_NUMBER = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COUNTRY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DDD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PREFIX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUFIX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CATEGORY_ID = table.Column<int>(type: "int", nullable: false),
                    DH_CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DH_UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NUMBER", x => x.ID_NUMBER);
                    table.ForeignKey(
                        name: "FK_NUMBER_CATEGORY_CATEGORY_ID",
                        column: x => x.CATEGORY_ID,
                        principalTable: "CATEGORY",
                        principalColumn: "CATEGORY_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NUMBER_EQUIPAMENT",
                columns: table => new
                {
                    ID_EQUIPAMENT = table.Column<int>(type: "int", nullable: false),
                    ID_NUMBER = table.Column<int>(type: "int", nullable: false),
                    DH_CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DH_UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NUMBER_EQUIPAMENT", x => new { x.ID_EQUIPAMENT, x.ID_NUMBER });
                    table.ForeignKey(
                        name: "FK_NUMBER_EQUIPAMENT_EQUIPAMENT_ID_EQUIPAMENT",
                        column: x => x.ID_EQUIPAMENT,
                        principalTable: "EQUIPAMENT",
                        principalColumn: "ID_EQUIPAMENT",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NUMBER_EQUIPAMENT_NUMBER_ID_NUMBER",
                        column: x => x.ID_NUMBER,
                        principalTable: "NUMBER",
                        principalColumn: "ID_NUMBER",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NUMBER_CATEGORY_ID",
                table: "NUMBER",
                column: "CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NUMBER_EQUIPAMENT_ID_NUMBER",
                table: "NUMBER_EQUIPAMENT",
                column: "ID_NUMBER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NUMBER_EQUIPAMENT");

            migrationBuilder.DropTable(
                name: "NUMBER_STATUS");

            migrationBuilder.DropTable(
                name: "QUARENTINE");

            migrationBuilder.DropTable(
                name: "EQUIPAMENT");

            migrationBuilder.DropTable(
                name: "NUMBER");

            migrationBuilder.DropTable(
                name: "CATEGORY");
        }
    }
}
