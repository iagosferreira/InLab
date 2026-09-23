using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InLab.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "area",
                columns: table => new
                {
                    id_are = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome_are = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_area", x => x.id_are);
                });

            migrationBuilder.CreateTable(
                name: "detector",
                columns: table => new
                {
                    id_ade = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_are = table.Column<int>(type: "INTEGER", nullable: false),
                    cadastro_det = table.Column<string>(type: "TEXT", nullable: false),
                    serial_det = table.Column<string>(type: "TEXT", nullable: false),
                    fabricante_det = table.Column<string>(type: "TEXT", nullable: false),
                    modelo_det = table.Column<string>(type: "TEXT", nullable: false),
                    status_uso_det = table.Column<string>(type: "TEXT", nullable: false),
                    status_co_det = table.Column<string>(type: "TEXT", nullable: false),
                    data_co_det = table.Column<DateTime>(type: "TEXT", nullable: true),
                    data_caç_det = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detector", x => x.id_ade);
                    table.ForeignKey(
                        name: "FK_detector_area_id_are",
                        column: x => x.id_are,
                        principalTable: "area",
                        principalColumn: "id_are",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "calibracao",
                columns: table => new
                {
                    id_cal = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_det = table.Column<int>(type: "INTEGER", nullable: false),
                    data_cal = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calibracao", x => x.id_cal);
                    table.ForeignKey(
                        name: "FK_calibracao_detector_id_det",
                        column: x => x.id_det,
                        principalTable: "detector",
                        principalColumn: "id_ade",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_calibracao_id_det",
                table: "calibracao",
                column: "id_det");

            migrationBuilder.CreateIndex(
                name: "IX_detector_id_are",
                table: "detector",
                column: "id_are");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "calibracao");

            migrationBuilder.DropTable(
                name: "detector");

            migrationBuilder.DropTable(
                name: "area");
        }
    }
}
