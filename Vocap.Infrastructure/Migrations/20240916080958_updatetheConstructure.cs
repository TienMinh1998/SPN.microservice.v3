using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vocap.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatetheConstructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Audio",
                schema: "vocap",
                table: "vocabularies");

            migrationBuilder.DropColumn(
                name: "EnglishType",
                schema: "vocap",
                table: "vocabularies");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "vocap",
                table: "vocabularies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Audio",
                schema: "vocap",
                table: "vocabularies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EnglishType",
                schema: "vocap",
                table: "vocabularies",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "vocap",
                table: "vocabularies",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
