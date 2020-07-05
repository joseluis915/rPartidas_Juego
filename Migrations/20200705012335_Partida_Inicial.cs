using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace rPartidas_Juego.Migrations
{
    public partial class Partida_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jugadores",
                columns: table => new
                {
                    JugadorId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugadores", x => x.JugadorId);
                });

            migrationBuilder.CreateTable(
                name: "Partidas",
                columns: table => new
                {
                    PartidaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidas", x => x.PartidaId);
                });

            migrationBuilder.CreateTable(
                name: "PartidasDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PartidaId = table.Column<int>(nullable: false),
                    JugadorId = table.Column<int>(nullable: false),
                    Posicion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartidasDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartidasDetalle_Jugadores_JugadorId",
                        column: x => x.JugadorId,
                        principalTable: "Jugadores",
                        principalColumn: "JugadorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartidasDetalle_Partidas_PartidaId",
                        column: x => x.PartidaId,
                        principalTable: "Partidas",
                        principalColumn: "PartidaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Jugadores",
                columns: new[] { "JugadorId", "Nombres" },
                values: new object[] { 1, "Jose" });

            migrationBuilder.InsertData(
                table: "Jugadores",
                columns: new[] { "JugadorId", "Nombres" },
                values: new object[] { 2, "Luis" });

            migrationBuilder.InsertData(
                table: "Jugadores",
                columns: new[] { "JugadorId", "Nombres" },
                values: new object[] { 3, "Burgos" });

            migrationBuilder.InsertData(
                table: "Jugadores",
                columns: new[] { "JugadorId", "Nombres" },
                values: new object[] { 4, "Hernandez" });

            migrationBuilder.CreateIndex(
                name: "IX_PartidasDetalle_JugadorId",
                table: "PartidasDetalle",
                column: "JugadorId");

            migrationBuilder.CreateIndex(
                name: "IX_PartidasDetalle_PartidaId",
                table: "PartidasDetalle",
                column: "PartidaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartidasDetalle");

            migrationBuilder.DropTable(
                name: "Jugadores");

            migrationBuilder.DropTable(
                name: "Partidas");
        }
    }
}
