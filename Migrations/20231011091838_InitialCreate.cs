using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webAPIMiniReddit.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kommentare",
                columns: table => new
                {
                    idKommentar = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    brugerKommentar = table.Column<string>(type: "TEXT", nullable: false),
                    text = table.Column<string>(type: "TEXT", nullable: false),
                    dato = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kommentare", x => x.idKommentar);
                });

            migrationBuilder.CreateTable(
                name: "Traade",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    brugerTraad = table.Column<string>(type: "TEXT", nullable: false),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    titel = table.Column<string>(type: "TEXT", nullable: false),
                    beskrivelse = table.Column<string>(type: "TEXT", nullable: false),
                    stem = table.Column<int>(type: "INTEGER", nullable: false),
                    totalStemmer = table.Column<int>(type: "INTEGER", nullable: false),
                    kommentar = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traade", x => x.id);
                });
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
