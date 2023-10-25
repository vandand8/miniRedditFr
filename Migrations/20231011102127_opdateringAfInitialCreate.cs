using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webAPIMiniReddit.Migrations
{
    /// <inheritdoc />
    public partial class opdateringAfInitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "stem",
                table: "Traade",
                newName: "stemOp");

            migrationBuilder.AddColumn<int>(
                name: "stemNed",
                table: "Traade",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "stemNed",
                table: "Traade");

            migrationBuilder.RenameColumn(
                name: "stemOp",
                table: "Traade",
                newName: "stem");
        }
    }
}
