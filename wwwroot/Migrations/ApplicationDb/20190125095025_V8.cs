using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserList",
                columns: new[] { "Id", "Created", "Email", "LastOnline", "Name", "Phone", "PhoneCountryCode", "SocialSecurityNumber", "Title", "Token" },
                values: new object[] { new Guid("781e8896-c130-4096-b9fc-ae63e9f6fda5"), new DateTime(2019, 1, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), "henrik.juhlin@funka.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Henrik Juhlin", "706017546", "0046", 19107928319L, "Utvecklare", "Ma6zh1iAzdglm8PNAoilxzuJqNFecLp4xoNWQa1IDx8=" });

            migrationBuilder.InsertData(
                table: "UserRoleList",
                columns: new[] { "UserItemId", "RoleItemId" },
                values: new object[] { new Guid("781e8896-c130-4096-b9fc-ae63e9f6fda5"), new Guid("e7a78cdc-49f9-4e6c-8abd-afcfc08ca5eb") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoleList",
                keyColumns: new[] { "UserItemId", "RoleItemId" },
                keyValues: new object[] { new Guid("781e8896-c130-4096-b9fc-ae63e9f6fda5"), new Guid("e7a78cdc-49f9-4e6c-8abd-afcfc08ca5eb") });

            migrationBuilder.DeleteData(
                table: "UserList",
                keyColumn: "Id",
                keyValue: new Guid("781e8896-c130-4096-b9fc-ae63e9f6fda5"));
        }
    }
}
