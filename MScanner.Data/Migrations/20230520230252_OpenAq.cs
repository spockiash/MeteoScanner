using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MScanner.Data.Migrations
{
    /// <inheritdoc />
    public partial class OpenAq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OpenAqPresets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Limit = table.Column<string>(type: "TEXT", nullable: true),
                    Page = table.Column<string>(type: "TEXT", nullable: true),
                    Offset = table.Column<string>(type: "TEXT", nullable: true),
                    Sort = table.Column<string>(type: "TEXT", nullable: true),
                    CountryId = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    ApiService = table.Column<int>(type: "INTEGER", nullable: false),
                    UrlHost = table.Column<string>(type: "TEXT", nullable: true),
                    UrlPath = table.Column<string>(type: "TEXT", nullable: true),
                    UrlQuery = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenAqPresets", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpenAqPresets");
        }
    }
}
