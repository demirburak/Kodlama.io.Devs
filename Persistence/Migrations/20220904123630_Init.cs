using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgramLanguages",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramLanguages", x => x.LanguageId);
                });

            migrationBuilder.InsertData(
                table: "ProgramLanguages",
                columns: new[] { "LanguageId", "LanguageName" },
                values: new object[] { 1, "C#" });

            migrationBuilder.InsertData(
                table: "ProgramLanguages",
                columns: new[] { "LanguageId", "LanguageName" },
                values: new object[] { 2, "Java" });

            migrationBuilder.InsertData(
                table: "ProgramLanguages",
                columns: new[] { "LanguageId", "LanguageName" },
                values: new object[] { 3, "Python" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramLanguages");
        }
    }
}
