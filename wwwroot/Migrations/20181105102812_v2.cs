using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleList",
                keyColumn: "Id",
                keyValue: new Guid("400a7c12-ef37-4cb9-ac3e-da4d4a621a8f"));

            migrationBuilder.DeleteData(
                table: "UserRoleList",
                keyColumns: new[] { "UserItemId", "RoleItemId" },
                keyValues: new object[] { new Guid("9ffecba1-0658-4f04-bc15-2a140722503f"), new Guid("a8eb1103-23c1-4c65-bb46-4c891fe25121") });

            migrationBuilder.DeleteData(
                table: "UserRoleList",
                keyColumns: new[] { "UserItemId", "RoleItemId" },
                keyValues: new object[] { new Guid("9ffecba1-0658-4f04-bc15-2a140722503f"), new Guid("b06763ff-349d-4366-9856-443303e308d0") });

            migrationBuilder.DeleteData(
                table: "UserRoleList",
                keyColumns: new[] { "UserItemId", "RoleItemId" },
                keyValues: new object[] { new Guid("b53d85c0-2f39-4bd1-98db-fdfc2b01ab11"), new Guid("a8eb1103-23c1-4c65-bb46-4c891fe25121") });

            migrationBuilder.DeleteData(
                table: "RoleList",
                keyColumn: "Id",
                keyValue: new Guid("a8eb1103-23c1-4c65-bb46-4c891fe25121"));

            migrationBuilder.DeleteData(
                table: "RoleList",
                keyColumn: "Id",
                keyValue: new Guid("b06763ff-349d-4366-9856-443303e308d0"));

            migrationBuilder.DeleteData(
                table: "UserList",
                keyColumn: "Id",
                keyValue: new Guid("9ffecba1-0658-4f04-bc15-2a140722503f"));

            migrationBuilder.DeleteData(
                table: "UserList",
                keyColumn: "Id",
                keyValue: new Guid("b53d85c0-2f39-4bd1-98db-fdfc2b01ab11"));

            migrationBuilder.RenameColumn(
                name: "IdPortenSub",
                table: "UserList",
                newName: "Token");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserList",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "RoleList",
                columns: new[] { "Id", "IsAdminRole", "Name" },
                values: new object[,]
                {
                    { new Guid("86256d80-3c70-4143-a4aa-0662a0c7d247"), true, "Admin" },
                    { new Guid("b12ddbf6-1e3d-4a11-9880-fe4ff5b14c01"), true, "Saksbehandlare" },
                    { new Guid("8f53bf26-92ca-405b-af3e-22fe6cc07dad"), false, "Virksomhet" }
                });

            migrationBuilder.InsertData(
                table: "UserList",
                columns: new[] { "Id", "Created", "Email", "LastOnline", "Name", "Phone", "SocialSecurityNumber", "Title", "Token" },
                values: new object[,]
                {
                    { new Guid("9604fda2-43ed-41f2-af64-bbcc81afb4f9"), new DateTime(2018, 11, 5, 11, 28, 11, 806, DateTimeKind.Local), "martin@difi.no", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martin Swartling", "912345678", "12089400420", "Avdelingssjef", "fqgADdXVzSgBdjIGl1KloQWjN-qGPN66S1h8EiBtg3g=" },
                    { new Guid("4658d37d-b3d8-47e3-a0fb-e18a4c73734b"), new DateTime(2018, 11, 5, 11, 28, 11, 808, DateTimeKind.Local), "thea@difi.no", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thea Sneve", "712345678", "12089400269", "Handläggare", "72og6NuGTB95NqnWN4Mj2IF_pVgodGv_qZ1F8c8u77c=" }
                });

            migrationBuilder.InsertData(
                table: "UserRoleList",
                columns: new[] { "UserItemId", "RoleItemId" },
                values: new object[] { new Guid("9604fda2-43ed-41f2-af64-bbcc81afb4f9"), new Guid("86256d80-3c70-4143-a4aa-0662a0c7d247") });

            migrationBuilder.InsertData(
                table: "UserRoleList",
                columns: new[] { "UserItemId", "RoleItemId" },
                values: new object[] { new Guid("9604fda2-43ed-41f2-af64-bbcc81afb4f9"), new Guid("b12ddbf6-1e3d-4a11-9880-fe4ff5b14c01") });

            migrationBuilder.InsertData(
                table: "UserRoleList",
                columns: new[] { "UserItemId", "RoleItemId" },
                values: new object[] { new Guid("4658d37d-b3d8-47e3-a0fb-e18a4c73734b"), new Guid("b12ddbf6-1e3d-4a11-9880-fe4ff5b14c01") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleList",
                keyColumn: "Id",
                keyValue: new Guid("8f53bf26-92ca-405b-af3e-22fe6cc07dad"));

            migrationBuilder.DeleteData(
                table: "UserRoleList",
                keyColumns: new[] { "UserItemId", "RoleItemId" },
                keyValues: new object[] { new Guid("4658d37d-b3d8-47e3-a0fb-e18a4c73734b"), new Guid("b12ddbf6-1e3d-4a11-9880-fe4ff5b14c01") });

            migrationBuilder.DeleteData(
                table: "UserRoleList",
                keyColumns: new[] { "UserItemId", "RoleItemId" },
                keyValues: new object[] { new Guid("9604fda2-43ed-41f2-af64-bbcc81afb4f9"), new Guid("86256d80-3c70-4143-a4aa-0662a0c7d247") });

            migrationBuilder.DeleteData(
                table: "UserRoleList",
                keyColumns: new[] { "UserItemId", "RoleItemId" },
                keyValues: new object[] { new Guid("9604fda2-43ed-41f2-af64-bbcc81afb4f9"), new Guid("b12ddbf6-1e3d-4a11-9880-fe4ff5b14c01") });

            migrationBuilder.DeleteData(
                table: "RoleList",
                keyColumn: "Id",
                keyValue: new Guid("86256d80-3c70-4143-a4aa-0662a0c7d247"));

            migrationBuilder.DeleteData(
                table: "RoleList",
                keyColumn: "Id",
                keyValue: new Guid("b12ddbf6-1e3d-4a11-9880-fe4ff5b14c01"));

            migrationBuilder.DeleteData(
                table: "UserList",
                keyColumn: "Id",
                keyValue: new Guid("4658d37d-b3d8-47e3-a0fb-e18a4c73734b"));

            migrationBuilder.DeleteData(
                table: "UserList",
                keyColumn: "Id",
                keyValue: new Guid("9604fda2-43ed-41f2-af64-bbcc81afb4f9"));

            migrationBuilder.RenameColumn(
                name: "Token",
                table: "UserList",
                newName: "IdPortenSub");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserList",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.InsertData(
                table: "RoleList",
                columns: new[] { "Id", "IsAdminRole", "Name" },
                values: new object[,]
                {
                    { new Guid("b06763ff-349d-4366-9856-443303e308d0"), true, "Admin" },
                    { new Guid("a8eb1103-23c1-4c65-bb46-4c891fe25121"), true, "Saksbehandlare" },
                    { new Guid("400a7c12-ef37-4cb9-ac3e-da4d4a621a8f"), false, "Verksamhet" }
                });

            migrationBuilder.InsertData(
                table: "UserList",
                columns: new[] { "Id", "Created", "Email", "IdPortenSub", "LastOnline", "Name", "Phone", "SocialSecurityNumber", "Title" },
                values: new object[,]
                {
                    { new Guid("9ffecba1-0658-4f04-bc15-2a140722503f"), new DateTime(2018, 11, 5, 6, 38, 6, 216, DateTimeKind.Local), "martin@difi.no", "fqgADdXVzSgBdjIGl1KloQWjN-qGPN66S1h8EiBtg3g=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martin Swartling", "912345678", "12089400420", "Avdelingssjef" },
                    { new Guid("b53d85c0-2f39-4bd1-98db-fdfc2b01ab11"), new DateTime(2018, 11, 5, 6, 38, 6, 218, DateTimeKind.Local), "thea@difi.no", "72og6NuGTB95NqnWN4Mj2IF_pVgodGv_qZ1F8c8u77c=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thea Sneve", "712345678", "12089400269", "Handläggare" }
                });

            migrationBuilder.InsertData(
                table: "UserRoleList",
                columns: new[] { "UserItemId", "RoleItemId" },
                values: new object[] { new Guid("9ffecba1-0658-4f04-bc15-2a140722503f"), new Guid("b06763ff-349d-4366-9856-443303e308d0") });

            migrationBuilder.InsertData(
                table: "UserRoleList",
                columns: new[] { "UserItemId", "RoleItemId" },
                values: new object[] { new Guid("9ffecba1-0658-4f04-bc15-2a140722503f"), new Guid("a8eb1103-23c1-4c65-bb46-4c891fe25121") });

            migrationBuilder.InsertData(
                table: "UserRoleList",
                columns: new[] { "UserItemId", "RoleItemId" },
                values: new object[] { new Guid("b53d85c0-2f39-4bd1-98db-fdfc2b01ab11"), new Guid("a8eb1103-23c1-4c65-bb46-4c891fe25121") });
        }
    }
}
