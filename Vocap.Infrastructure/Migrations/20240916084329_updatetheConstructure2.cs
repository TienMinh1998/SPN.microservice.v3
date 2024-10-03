using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vocap.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatetheConstructure2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VietnamMeaning_Meaning",
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
                name: "VietnamMeaning_Meaning",
                schema: "vocap",
                table: "vocabularies");
        }
    }
}
