using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Path",
                table: "ImageList",
                newName: "Uuid");

            migrationBuilder.AddColumn<string>(
                name: "Blob",
                table: "ImageList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Container",
                table: "ImageList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ImageList",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Blob",
                table: "ImageList");

            migrationBuilder.DropColumn(
                name: "Container",
                table: "ImageList");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ImageList");

            migrationBuilder.RenameColumn(
                name: "Uuid",
                table: "ImageList",
                newName: "Path");
        }
    }
}
