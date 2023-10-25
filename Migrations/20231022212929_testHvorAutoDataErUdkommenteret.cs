﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webAPIMiniReddit.Migrations
{
    /// <inheritdoc />
    public partial class testHvorAutoDataErUdkommenteret : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "brugerTraad",
                table: "Traade",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "brugerTraad",
                table: "Traade",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
