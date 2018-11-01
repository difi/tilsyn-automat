using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoleList",
                keyColumns: new[] { "UserItemId", "RoleItemId" },
                keyValues: new object[] { new Guid("2ca5b5ca-5d69-4349-bc90-1a17eb4ca8bc"), new Guid("1e6104aa-a651-4783-8aa1-e97d40e8765c") });

            migrationBuilder.DeleteData(
                table: "UserRoleList",
                keyColumns: new[] { "UserItemId", "RoleItemId" },
                keyValues: new object[] { new Guid("2ca5b5ca-5d69-4349-bc90-1a17eb4ca8bc"), new Guid("afcd1219-172b-4300-aadc-695824efbb37") });

            migrationBuilder.DeleteData(
                table: "UserRoleList",
                keyColumns: new[] { "UserItemId", "RoleItemId" },
                keyValues: new object[] { new Guid("5612debc-8937-4b87-955f-8ecf1e301dda"), new Guid("afcd1219-172b-4300-aadc-695824efbb37") });

            migrationBuilder.DeleteData(
                table: "UserRoleList",
                keyColumns: new[] { "UserItemId", "RoleItemId" },
                keyValues: new object[] { new Guid("a76969cd-19e1-4ec8-9513-66abc721f601"), new Guid("f7538941-a1c8-42fd-954e-f66801fb170e") });

            migrationBuilder.DeleteData(
                table: "RoleList",
                keyColumn: "Id",
                keyValue: new Guid("1e6104aa-a651-4783-8aa1-e97d40e8765c"));

            migrationBuilder.DeleteData(
                table: "RoleList",
                keyColumn: "Id",
                keyValue: new Guid("afcd1219-172b-4300-aadc-695824efbb37"));

            migrationBuilder.DeleteData(
                table: "RoleList",
                keyColumn: "Id",
                keyValue: new Guid("f7538941-a1c8-42fd-954e-f66801fb170e"));

            migrationBuilder.DeleteData(
                table: "UserList",
                keyColumn: "Id",
                keyValue: new Guid("2ca5b5ca-5d69-4349-bc90-1a17eb4ca8bc"));

            migrationBuilder.DeleteData(
                table: "UserList",
                keyColumn: "Id",
                keyValue: new Guid("5612debc-8937-4b87-955f-8ecf1e301dda"));

            migrationBuilder.DeleteData(
                table: "UserList",
                keyColumn: "Id",
                keyValue: new Guid("a76969cd-19e1-4ec8-9513-66abc721f601"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "UserList",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastOnline",
                table: "UserList",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "UserList",
                nullable: true);

            migrationBuilder.InsertData(
                table: "RoleList",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("bc0d58a4-8872-4ef9-87fd-392ff9a23164"), "Admin" },
                    { new Guid("4e4e0a39-54ed-4a39-88b7-b0b006fd109c"), "Saksbehandlare" },
                    { new Guid("12ab8a0e-8d47-48cc-bcc8-7d8c5e50eceb"), "Verksamhet" }
                });

            migrationBuilder.InsertData(
                table: "UserList",
                columns: new[] { "Id", "Created", "Email", "IdPortenSub", "LastOnline", "Name", "Phone", "SocialSecurityNumber", "Title" },
                values: new object[,]
                {
                    { new Guid("08fff097-7a05-452c-aa18-e93e8bd9516c"), new DateTime(2018, 11, 1, 10, 7, 7, 450, DateTimeKind.Local), "martin@difi.no", "fqgADdXVzSgBdjIGl1KloQWjN-qGPN66S1h8EiBtg3g=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martin Swartling", "912345678", "12089400420", "Avdelingssjef" },
                    { new Guid("d99e0f7f-9a5a-42c2-bd45-66a9f7cf09dd"), new DateTime(2018, 11, 1, 10, 7, 7, 451, DateTimeKind.Local), "thea@difi.no", "72og6NuGTB95NqnWN4Mj2IF_pVgodGv_qZ1F8c8u77c=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thea Sneve", "712345678", "12089400269", "Handläggare" }
                });

            migrationBuilder.InsertData(
                table: "UserRoleList",
                columns: new[] { "UserItemId", "RoleItemId" },
                values: new object[] { new Guid("08fff097-7a05-452c-aa18-e93e8bd9516c"), new Guid("bc0d58a4-8872-4ef9-87fd-392ff9a23164") });

            migrationBuilder.InsertData(
                table: "UserRoleList",
                columns: new[] { "UserItemId", "RoleItemId" },
                values: new object[] { new Guid("08fff097-7a05-452c-aa18-e93e8bd9516c"), new Guid("4e4e0a39-54ed-4a39-88b7-b0b006fd109c") });

            migrationBuilder.InsertData(
                table: "UserRoleList",
                columns: new[] { "UserItemId", "RoleItemId" },
                values: new object[] { new Guid("d99e0f7f-9a5a-42c2-bd45-66a9f7cf09dd"), new Guid("4e4e0a39-54ed-4a39-88b7-b0b006fd109c") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleList",
                keyColumn: "Id",
                keyValue: new Guid("12ab8a0e-8d47-48cc-bcc8-7d8c5e50eceb"));

            migrationBuilder.DeleteData(
                table: "UserRoleList",
                keyColumns: new[] { "UserItemId", "RoleItemId" },
                keyValues: new object[] { new Guid("08fff097-7a05-452c-aa18-e93e8bd9516c"), new Guid("4e4e0a39-54ed-4a39-88b7-b0b006fd109c") });

            migrationBuilder.DeleteData(
                table: "UserRoleList",
                keyColumns: new[] { "UserItemId", "RoleItemId" },
                keyValues: new object[] { new Guid("08fff097-7a05-452c-aa18-e93e8bd9516c"), new Guid("bc0d58a4-8872-4ef9-87fd-392ff9a23164") });

            migrationBuilder.DeleteData(
                table: "UserRoleList",
                keyColumns: new[] { "UserItemId", "RoleItemId" },
                keyValues: new object[] { new Guid("d99e0f7f-9a5a-42c2-bd45-66a9f7cf09dd"), new Guid("4e4e0a39-54ed-4a39-88b7-b0b006fd109c") });

            migrationBuilder.DeleteData(
                table: "RoleList",
                keyColumn: "Id",
                keyValue: new Guid("4e4e0a39-54ed-4a39-88b7-b0b006fd109c"));

            migrationBuilder.DeleteData(
                table: "RoleList",
                keyColumn: "Id",
                keyValue: new Guid("bc0d58a4-8872-4ef9-87fd-392ff9a23164"));

            migrationBuilder.DeleteData(
                table: "UserList",
                keyColumn: "Id",
                keyValue: new Guid("08fff097-7a05-452c-aa18-e93e8bd9516c"));

            migrationBuilder.DeleteData(
                table: "UserList",
                keyColumn: "Id",
                keyValue: new Guid("d99e0f7f-9a5a-42c2-bd45-66a9f7cf09dd"));

            migrationBuilder.DropColumn(
                name: "Created",
                table: "UserList");

            migrationBuilder.DropColumn(
                name: "LastOnline",
                table: "UserList");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "UserList");

            migrationBuilder.InsertData(
                table: "RoleList",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1e6104aa-a651-4783-8aa1-e97d40e8765c"), "Admin" },
                    { new Guid("afcd1219-172b-4300-aadc-695824efbb37"), "Saksbehandlare" },
                    { new Guid("f7538941-a1c8-42fd-954e-f66801fb170e"), "Verksamhet" }
                });

            migrationBuilder.InsertData(
                table: "UserList",
                columns: new[] { "Id", "Email", "IdPortenSub", "Name", "Phone", "SocialSecurityNumber" },
                values: new object[,]
                {
                    { new Guid("2ca5b5ca-5d69-4349-bc90-1a17eb4ca8bc"), "thea@difi.no", "fqgADdXVzSgBdjIGl1KloQWjN-qGPN66S1h8EiBtg3g=", "Thea", "712345678", "12089400420" },
                    { new Guid("5612debc-8937-4b87-955f-8ecf1e301dda"), "martin@difi.no", "72og6NuGTB95NqnWN4Mj2IF_pVgodGv_qZ1F8c8u77c=", "Martin", "912345678", "12089400269" },
                    { new Guid("a76969cd-19e1-4ec8-9513-66abc721f601"), null, "8zrqvL9yMbkJAfU_53_WE1jbTFUehgxmf7MADGcv98g=", "", null, "12089400188" }
                });

            migrationBuilder.InsertData(
                table: "UserRoleList",
                columns: new[] { "UserItemId", "RoleItemId" },
                values: new object[,]
                {
                    { new Guid("2ca5b5ca-5d69-4349-bc90-1a17eb4ca8bc"), new Guid("1e6104aa-a651-4783-8aa1-e97d40e8765c") },
                    { new Guid("2ca5b5ca-5d69-4349-bc90-1a17eb4ca8bc"), new Guid("afcd1219-172b-4300-aadc-695824efbb37") },
                    { new Guid("5612debc-8937-4b87-955f-8ecf1e301dda"), new Guid("afcd1219-172b-4300-aadc-695824efbb37") },
                    { new Guid("a76969cd-19e1-4ec8-9513-66abc721f601"), new Guid("f7538941-a1c8-42fd-954e-f66801fb170e") }
                });
        }
    }
}
