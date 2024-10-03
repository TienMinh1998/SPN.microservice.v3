using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vocap.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatetheConstructure3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WordType",
                schema: "vocap",
                table: "vocabularies",
                newName: "CamVocabulary_WordType");

            migrationBuilder.RenameColumn(
                name: "Phonetic",
                schema: "vocap",
                table: "vocabularies",
                newName: "CamVocabulary_Phonetic");

            migrationBuilder.RenameColumn(
                name: "Audio",
                schema: "vocap",
                table: "vocabularies",
                newName: "CamVocabulary_Audio");

            migrationBuilder.AddColumn<string>(
                name: "CamVocabulary_DaftWord",
                schema: "vocap",
                table: "vocabularies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "WorkFlowOfVocabulary",
                schema: "vocap",
                table: "vocabularies",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CamVocabulary_DaftWord",
                schema: "vocap",
                table: "vocabularies");

            migrationBuilder.DropColumn(
                name: "WorkFlowOfVocabulary",
                schema: "vocap",
                table: "vocabularies");

            migrationBuilder.RenameColumn(
                name: "CamVocabulary_WordType",
                schema: "vocap",
                table: "vocabularies",
                newName: "WordType");

            migrationBuilder.RenameColumn(
                name: "CamVocabulary_Phonetic",
                schema: "vocap",
                table: "vocabularies",
                newName: "Phonetic");

            migrationBuilder.RenameColumn(
                name: "CamVocabulary_Audio",
                schema: "vocap",
                table: "vocabularies",
                newName: "Audio");
        }
    }
}
