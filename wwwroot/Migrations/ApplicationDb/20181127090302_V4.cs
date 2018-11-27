using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TextAdmin",
                table: "VlTypeOfStatus",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Text", "TextAdmin", "TextCompany" },
                values: new object[] { "Opprettet", "Opprettet", "Ikke påbegynt" });

            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Text", "TextAdmin", "TextCompany" },
                values: new object[] { "Varslad", "Pågår", "Ikke påbegynt" });

            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Text", "TextAdmin", "TextCompany" },
                values: new object[] { "Påbegynt", "Pågår", "Påbegynt" });

            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Text", "TextAdmin", "TextCompany" },
                values: new object[] { "Fullført", "Pågår", "Fullført" });

            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Text", "TextAdmin", "TextCompany" },
                values: new object[] { "Sendt tilbake", "Pågår", "Sendt tilbake for korreksjon" });

            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Text", "TextAdmin", "TextCompany" },
                values: new object[] { "Avsluttet", "Avsluttet", "Fullført" });

            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Text", "TextAdmin", "TextCompany" },
                values: new object[] { "Avlyst", "Avlyst", "Avlyst" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TextAdmin",
                table: "VlTypeOfStatus");

            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Text", "TextCompany" },
                values: new object[] { "Created A", "Created C" });

            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Text", "TextCompany" },
                values: new object[] { "Sent A", "Sent C" });

            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Text", "TextCompany" },
                values: new object[] { "Started A", "Started C" });

            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Text", "TextCompany" },
                values: new object[] { "Complete A", "Complete C" });

            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Text", "TextCompany" },
                values: new object[] { "Return A", "Return C" });

            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Text", "TextCompany" },
                values: new object[] { "Finished A", "Finished C" });

            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Text", "TextCompany" },
                values: new object[] { "Canceled A", "Canceled C" });
        }
    }
}
