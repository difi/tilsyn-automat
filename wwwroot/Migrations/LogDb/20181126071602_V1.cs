using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.LogDb
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Class = table.Column<string>(nullable: true),
                    Function = table.Column<string>(nullable: true),
                    CallParameter1 = table.Column<string>(nullable: true),
                    CallParameter2 = table.Column<string>(nullable: true),
                    ResultSucceeded = table.Column<bool>(nullable: false),
                    ResultId = table.Column<Guid>(nullable: false),
                    ResultString = table.Column<string>(nullable: true),
                    ResultException = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogList", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogList");
        }
    }
}
