using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vocap.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatetheConstructure1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Audio",
                schema: "vocap",
                table: "vocabularies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DaftWord",
                schema: "vocap",
                table: "vocabularies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phonetic",
                schema: "vocap",
                table: "vocabularies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WordType",
                schema: "vocap",
                table: "vocabularies",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Audio",
                schema: "vocap",
                table: "vocabularies");

            migrationBuilder.DropColumn(
                name: "DaftWord",
                schema: "vocap",
                table: "vocabularies");

            migrationBuilder.DropColumn(
                name: "Phonetic",
                schema: "vocap",
                table: "vocabularies");

            migrationBuilder.DropColumn(
                name: "WordType",
                schema: "vocap",
                table: "vocabularies");
        }
    }
}
