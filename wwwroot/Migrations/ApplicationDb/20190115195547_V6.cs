using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TextAdmin",
                table: "VlTypeOfStatus",
                newName: "CompanyNn");

            migrationBuilder.AddColumn<string>(
                name: "CompanyNb",
                table: "VlTypeOfStatus",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompanyNb", "CompanyNn", "Nb", "Nn", "Text", "TextCompany" },
                values: new object[] { "Ikke påbegynt", "Ikkje starta på", "Opprettet", "Oppretta", null, null });

            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CompanyNb", "CompanyNn", "Nb", "Nn", "Text", "TextCompany" },
                values: new object[] { "Ikke påbegynt", "Ikkje starta på", "Varslet", "Varsla", null, null });

            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CompanyNb", "CompanyNn", "Nb", "Nn", "Text", "TextCompany" },
                values: new object[] { "Påbegynt", "Starta på", "Påbegynt", "Starta på", null, null });

            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CompanyNb", "Nb", "Nn", "Text", "TextCompany" },
                values: new object[] { "Fullført", "Fullført", "Fullført", null, null });

            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CompanyNb", "CompanyNn", "Nb", "Nn", "Text", "TextCompany" },
                values: new object[] { "Åpen for korreksjon", "Open for korreksjon", "Åpen for korreksjon", "Open for korreksjon", null, null });

            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CompanyNb", "CompanyNn", "Nb", "Nn", "Text", "TextCompany" },
                values: new object[] { "Fullført", "Fullført", "Avsluttet", "Avslutta", null, null });

            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CompanyNb", "Nb", "Nn", "Text", "TextCompany" },
                values: new object[] { "Avlyst", "Avlyst", "Avlyst", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyNb",
                table: "VlTypeOfStatus");

            migrationBuilder.RenameColumn(
                name: "CompanyNn",
                table: "VlTypeOfStatus",
                newName: "TextAdmin");

            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Nb", "Nn", "Text", "TextAdmin", "TextCompany" },
                values: new object[] { null, null, "Opprettet", "Opprettet", "Ikke påbegynt" });

            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Nb", "Nn", "Text", "TextAdmin", "TextCompany" },
                values: new object[] { null, null, "Varslet", "Pågår", "Ikke påbegynt" });

            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Nb", "Nn", "Text", "TextAdmin", "TextCompany" },
                values: new object[] { null, null, "Påbegynt", "Pågår", "Påbegynt" });

            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Nb", "Nn", "Text", "TextCompany" },
                values: new object[] { null, null, "Fullført", "Fullført" });

            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Nb", "Nn", "Text", "TextAdmin", "TextCompany" },
                values: new object[] { null, null, "Åpen for korreksjon", "Pågår", "Åpen for korreksjon" });

            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Nb", "Nn", "Text", "TextAdmin", "TextCompany" },
                values: new object[] { null, null, "Avsluttet", "Avsluttet", "Fullført" });

            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Nb", "Nn", "Text", "TextCompany" },
                values: new object[] { null, null, "Avlyst", "Avlyst" });
        }
    }
}
