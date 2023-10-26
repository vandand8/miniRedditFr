using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webAPIMiniReddit.Migrations
{
    /// <inheritdoc />
    public partial class jioepfjop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Traade",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    brugerTraad = table.Column<string>(type: "TEXT", nullable: true),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    titel = table.Column<string>(type: "TEXT", nullable: false),
                    beskrivelse = table.Column<string>(type: "TEXT", nullable: false),
                    stemOp = table.Column<int>(type: "INTEGER", nullable: false),
                    stemNed = table.Column<int>(type: "INTEGER", nullable: false),
                    totalStemmer = table.Column<int>(type: "INTEGER", nullable: false),
                    kommentar = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traade", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Kommentare",
                columns: table => new
                {
                    idKommentar = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    brugerKommentar = table.Column<string>(type: "TEXT", nullable: false),
                    text = table.Column<string>(type: "TEXT", nullable: false),
                    stemOpK = table.Column<int>(type: "INTEGER", nullable: false),
                    stemNedK = table.Column<int>(type: "INTEGER", nullable: false),
                    totalStemmerK = table.Column<int>(type: "INTEGER", nullable: false),
                    dato = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Traadid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kommentare", x => x.idKommentar);
                    table.ForeignKey(
                        name: "FK_Kommentare_Traade_Traadid",
                        column: x => x.Traadid,
                        principalTable: "Traade",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kommentare_Traadid",
                table: "Kommentare",
                column: "Traadid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kommentare");

            migrationBuilder.DropTable(
                name: "Traade");
        }
    }
}
