using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VlPurposeOfTest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlPurposeOfTest", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "VlPurposeOfTest",
                columns: new[] { "Id", "Text" },
                values: new object[] { 1, "Pilotmåling" });

            migrationBuilder.InsertData(
                table: "VlPurposeOfTest",
                columns: new[] { "Id", "Text" },
                values: new object[] { 2, "Tilsyn" });

            migrationBuilder.InsertData(
                table: "VlPurposeOfTest",
                columns: new[] { "Id", "Text" },
                values: new object[] { 3, "Statysmåling" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VlPurposeOfTest");
        }
    }
}
