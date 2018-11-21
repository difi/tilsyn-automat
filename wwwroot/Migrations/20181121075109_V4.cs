using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "RequirementList");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "RequirementList",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "RequirementList",
                keyColumn: "Id",
                keyValue: new Guid("875e76b5-c926-43a0-8738-c4f41c7a0b8b"),
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RequirementList",
                keyColumn: "Id",
                keyValue: new Guid("aebd662d-9dd5-4a27-88d5-19d6c5e12e5a"),
                column: "Order",
                value: 3);

            migrationBuilder.UpdateData(
                table: "RequirementList",
                keyColumn: "Id",
                keyValue: new Guid("c65786bb-1b93-4153-b88c-935cc2a7ab60"),
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "RequirementList",
                keyColumn: "Id",
                keyValue: new Guid("e503322b-ed77-4b69-adc4-eca19b6eb97d"),
                column: "Order",
                value: 4);
        }
    }
}
