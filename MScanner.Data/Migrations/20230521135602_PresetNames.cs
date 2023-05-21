using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MScanner.Data.Migrations
{
    /// <inheritdoc />
    public partial class PresetNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PresetName",
                table: "OpenAqPresets",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PresetName",
                table: "OpenAqPresets");
        }
    }
}
