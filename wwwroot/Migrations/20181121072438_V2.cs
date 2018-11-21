using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "IndicatorList");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "IndicatorTestGroupList",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "IndicatorTestGroupList",
                keyColumns: new[] { "TestGroupItemId", "IndicatorItemId" },
                keyValues: new object[] { new Guid("9aae6bc9-4b60-405c-81a7-ec142d8c1ca6"), new Guid("5b2a0a78-039f-4173-bf9e-1ca0060d1c53") },
                column: "Order",
                value: 4);

            migrationBuilder.UpdateData(
                table: "IndicatorTestGroupList",
                keyColumns: new[] { "TestGroupItemId", "IndicatorItemId" },
                keyValues: new object[] { new Guid("aec1869a-30f8-403c-b909-df115173f009"), new Guid("692627b2-53bc-43f2-900d-44a40a21e7e9") },
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IndicatorTestGroupList",
                keyColumns: new[] { "TestGroupItemId", "IndicatorItemId" },
                keyValues: new object[] { new Guid("aec1869a-30f8-403c-b909-df115173f009"), new Guid("6b4bf385-9174-4634-bc9e-bfbdab98586e") },
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IndicatorTestGroupList",
                keyColumns: new[] { "TestGroupItemId", "IndicatorItemId" },
                keyValues: new object[] { new Guid("b6c22ac9-d775-4dfd-ac8e-b4ca565ea3fb"), new Guid("c52eb3bc-6464-4dc9-b9f3-eb975e2a012c") },
                column: "Order",
                value: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "IndicatorTestGroupList");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "IndicatorList",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "IndicatorList",
                keyColumn: "Id",
                keyValue: new Guid("5b2a0a78-039f-4173-bf9e-1ca0060d1c53"),
                column: "Order",
                value: 4);

            migrationBuilder.UpdateData(
                table: "IndicatorList",
                keyColumn: "Id",
                keyValue: new Guid("692627b2-53bc-43f2-900d-44a40a21e7e9"),
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IndicatorList",
                keyColumn: "Id",
                keyValue: new Guid("6b4bf385-9174-4634-bc9e-bfbdab98586e"),
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IndicatorList",
                keyColumn: "Id",
                keyValue: new Guid("c52eb3bc-6464-4dc9-b9f3-eb975e2a012c"),
                column: "Order",
                value: 3);
        }
    }
}
