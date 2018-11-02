using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactPersonList",
                keyColumn: "Id",
                keyValue: new Guid("0915cd0f-b4d5-4d0f-bc70-9c4897540619"));

            migrationBuilder.DeleteData(
                table: "ContactPersonList",
                keyColumn: "Id",
                keyValue: new Guid("0cc68b20-a7b8-4bcd-a743-8b1a79fdd6ab"));

            migrationBuilder.DeleteData(
                table: "ContactPersonList",
                keyColumn: "Id",
                keyValue: new Guid("1672623b-34fa-40ae-86a3-ea870a36c3cd"));

            migrationBuilder.DeleteData(
                table: "ContactPersonList",
                keyColumn: "Id",
                keyValue: new Guid("661443bc-0c92-4148-b8c1-d383ac179fbb"));

            migrationBuilder.DeleteData(
                table: "ContactPersonList",
                keyColumn: "Id",
                keyValue: new Guid("9dd2e076-605f-46f0-9315-d5721f5c17da"));

            migrationBuilder.DeleteData(
                table: "ContactPersonList",
                keyColumn: "Id",
                keyValue: new Guid("c3af421a-9f6b-4362-bd14-b66659428182"));

            migrationBuilder.DeleteData(
                table: "DeclarationList",
                keyColumn: "Id",
                keyValue: new Guid("3a24067c-639e-4868-a03b-8feee401ed2e"));

            migrationBuilder.DeleteData(
                table: "DeclarationList",
                keyColumn: "Id",
                keyValue: new Guid("779167eb-8b92-46ac-9b0f-0f4141165c1c"));

            migrationBuilder.DeleteData(
                table: "DeclarationList",
                keyColumn: "Id",
                keyValue: new Guid("7eb9a780-b2ec-4271-92d9-759c63eedd12"));

            migrationBuilder.DeleteData(
                table: "DeclarationList",
                keyColumn: "Id",
                keyValue: new Guid("961ac263-6fa8-4910-ab61-5280867e5653"));

            migrationBuilder.DeleteData(
                table: "DeclarationList",
                keyColumn: "Id",
                keyValue: new Guid("ba5d7737-9eb4-4f94-bf9d-cb4aec1fe60c"));

            migrationBuilder.DeleteData(
                table: "DeclarationList",
                keyColumn: "Id",
                keyValue: new Guid("e4227f36-6925-4994-b761-a5c1d1cccaa3"));

            migrationBuilder.DeleteData(
                table: "UserCompanyList",
                keyColumns: new[] { "UserItemId", "CompanyItemId" },
                keyValues: new object[] { new Guid("2f5c3c5f-9869-4ef9-a992-4ac8c2d1d751"), new Guid("626d1226-fdc4-4b01-a6c6-bca01828f0fa") });

            migrationBuilder.DeleteData(
                table: "UserRoleList",
                keyColumns: new[] { "UserItemId", "RoleItemId" },
                keyValues: new object[] { new Guid("2f5c3c5f-9869-4ef9-a992-4ac8c2d1d751"), new Guid("de09be5a-acd2-4a7f-9e04-af4ca266ca64") });

            migrationBuilder.DeleteData(
                table: "UserRoleList",
                keyColumns: new[] { "UserItemId", "RoleItemId" },
                keyValues: new object[] { new Guid("44f1ab9a-029f-499a-9baf-00776a6bcb44"), new Guid("78b6ea9b-f87c-4966-b636-01d648681462") });

            migrationBuilder.DeleteData(
                table: "UserRoleList",
                keyColumns: new[] { "UserItemId", "RoleItemId" },
                keyValues: new object[] { new Guid("8e469237-fe4e-4670-b137-e4c831868da4"), new Guid("175b54ba-c29e-46ce-874d-768ba96c0d8d") });

            migrationBuilder.DeleteData(
                table: "UserRoleList",
                keyColumns: new[] { "UserItemId", "RoleItemId" },
                keyValues: new object[] { new Guid("8e469237-fe4e-4670-b137-e4c831868da4"), new Guid("78b6ea9b-f87c-4966-b636-01d648681462") });

            migrationBuilder.DeleteData(
                table: "CompanyList",
                keyColumn: "Id",
                keyValue: new Guid("087a3650-7def-4e2d-bee6-3551ea407e38"));

            migrationBuilder.DeleteData(
                table: "CompanyList",
                keyColumn: "Id",
                keyValue: new Guid("1a4e0466-af1f-4053-a202-32f82316d565"));

            migrationBuilder.DeleteData(
                table: "CompanyList",
                keyColumn: "Id",
                keyValue: new Guid("1d3f6dce-f67c-4c02-8b66-f26756efddb8"));

            migrationBuilder.DeleteData(
                table: "CompanyList",
                keyColumn: "Id",
                keyValue: new Guid("4f751531-da1d-4b97-8459-4559e73a7b9b"));

            migrationBuilder.DeleteData(
                table: "CompanyList",
                keyColumn: "Id",
                keyValue: new Guid("626d1226-fdc4-4b01-a6c6-bca01828f0fa"));

            migrationBuilder.DeleteData(
                table: "CompanyList",
                keyColumn: "Id",
                keyValue: new Guid("8f41d94e-98aa-44ea-bd1c-54540dcbf395"));

            migrationBuilder.DeleteData(
                table: "RoleList",
                keyColumn: "Id",
                keyValue: new Guid("175b54ba-c29e-46ce-874d-768ba96c0d8d"));

            migrationBuilder.DeleteData(
                table: "RoleList",
                keyColumn: "Id",
                keyValue: new Guid("78b6ea9b-f87c-4966-b636-01d648681462"));

            migrationBuilder.DeleteData(
                table: "RoleList",
                keyColumn: "Id",
                keyValue: new Guid("de09be5a-acd2-4a7f-9e04-af4ca266ca64"));

            migrationBuilder.DeleteData(
                table: "UserList",
                keyColumn: "Id",
                keyValue: new Guid("2f5c3c5f-9869-4ef9-a992-4ac8c2d1d751"));

            migrationBuilder.DeleteData(
                table: "UserList",
                keyColumn: "Id",
                keyValue: new Guid("44f1ab9a-029f-499a-9baf-00776a6bcb44"));

            migrationBuilder.DeleteData(
                table: "UserList",
                keyColumn: "Id",
                keyValue: new Guid("8e469237-fe4e-4670-b137-e4c831868da4"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "CompanyList",
                columns: new[] { "Id", "Code", "CorporateIdentityNumber", "Name" },
                values: new object[,]
                {
                    { new Guid("626d1226-fdc4-4b01-a6c6-bca01828f0fa"), "1111", "123456789", "Narvesen" },
                    { new Guid("4f751531-da1d-4b97-8459-4559e73a7b9b"), "2222", "987654321", "Norwegian" },
                    { new Guid("1a4e0466-af1f-4053-a202-32f82316d565"), "3333", "1122334455", "NSB" },
                    { new Guid("087a3650-7def-4e2d-bee6-3551ea407e38"), "4444", "1122334455", "Esso" },
                    { new Guid("1d3f6dce-f67c-4c02-8b66-f26756efddb8"), "5555", "1122334455", "7 - eleven" },
                    { new Guid("8f41d94e-98aa-44ea-bd1c-54540dcbf395"), "6666", "1122334455", "Norske bank" }
                });

            migrationBuilder.InsertData(
                table: "RoleList",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("175b54ba-c29e-46ce-874d-768ba96c0d8d"), "Admin" },
                    { new Guid("78b6ea9b-f87c-4966-b636-01d648681462"), "Saksbehandlare" },
                    { new Guid("de09be5a-acd2-4a7f-9e04-af4ca266ca64"), "Verksamhet" }
                });

            migrationBuilder.InsertData(
                table: "UserList",
                columns: new[] { "Id", "Email", "IdPortenSub", "Name", "Phone", "SocialSecurityNumber" },
                values: new object[,]
                {
                    { new Guid("8e469237-fe4e-4670-b137-e4c831868da4"), "thea@difi.no", "fqgADdXVzSgBdjIGl1KloQWjN-qGPN66S1h8EiBtg3g=", "Thea", "712345678", "12089400420" },
                    { new Guid("44f1ab9a-029f-499a-9baf-00776a6bcb44"), "martin@difi.no", "72og6NuGTB95NqnWN4Mj2IF_pVgodGv_qZ1F8c8u77c=", "Martin", "912345678", "12089400269" },
                    { new Guid("2f5c3c5f-9869-4ef9-a992-4ac8c2d1d751"), null, "8zrqvL9yMbkJAfU_53_WE1jbTFUehgxmf7MADGcv98g=", "", null, "12089400188" }
                });

            migrationBuilder.InsertData(
                table: "ContactPersonList",
                columns: new[] { "Id", "CompanyItemId", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { new Guid("661443bc-0c92-4148-b8c1-d383ac179fbb"), new Guid("626d1226-fdc4-4b01-a6c6-bca01828f0fa"), "henrik.juhlin@funka.com", "Henrik Juhlin", "070-601 75 46" },
                    { new Guid("9dd2e076-605f-46f0-9315-d5721f5c17da"), new Guid("4f751531-da1d-4b97-8459-4559e73a7b9b"), "henrik.juhlin@funka.com", "Henrik Juhlin", "070-601 75 46" },
                    { new Guid("0915cd0f-b4d5-4d0f-bc70-9c4897540619"), new Guid("1a4e0466-af1f-4053-a202-32f82316d565"), "henrik.juhlin@funka.com", "Henrik Juhlin", "070-601 75 46" },
                    { new Guid("1672623b-34fa-40ae-86a3-ea870a36c3cd"), new Guid("087a3650-7def-4e2d-bee6-3551ea407e38"), "henrik.juhlin@funka.com", "Henrik Juhlin", "070-601 75 46" },
                    { new Guid("c3af421a-9f6b-4362-bd14-b66659428182"), new Guid("1d3f6dce-f67c-4c02-8b66-f26756efddb8"), "henrik.juhlin@funka.com", "Henrik Juhlin", "070-601 75 46" },
                    { new Guid("0cc68b20-a7b8-4bcd-a743-8b1a79fdd6ab"), new Guid("8f41d94e-98aa-44ea-bd1c-54540dcbf395"), "henrik.juhlin@funka.com", "Henrik Juhlin", "070-601 75 46" }
                });

            migrationBuilder.InsertData(
                table: "DeclarationList",
                columns: new[] { "Id", "CompanyItemId", "CreatedDate", "DeadLineDate", "Name", "SentInDate", "Status", "UserItemId" },
                values: new object[,]
                {
                    { new Guid("779167eb-8b92-46ac-9b0f-0f4141165c1c"), new Guid("8f41d94e-98aa-44ea-bd1c-54540dcbf395"), new DateTime(2018, 10, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Billettautomat Kristiansand", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new Guid("44f1ab9a-029f-499a-9baf-00776a6bcb44") },
                    { new Guid("e4227f36-6925-4994-b761-a5c1d1cccaa3"), new Guid("087a3650-7def-4e2d-bee6-3551ea407e38"), new DateTime(2018, 10, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Betalingsautomat Trondheim", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new Guid("44f1ab9a-029f-499a-9baf-00776a6bcb44") },
                    { new Guid("961ac263-6fa8-4910-ab61-5280867e5653"), new Guid("4f751531-da1d-4b97-8459-4559e73a7b9b"), new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Billettautomat Gardemoen", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("44f1ab9a-029f-499a-9baf-00776a6bcb44") },
                    { new Guid("7eb9a780-b2ec-4271-92d9-759c63eedd12"), new Guid("1d3f6dce-f67c-4c02-8b66-f26756efddb8"), new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Automat Grensen", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("8e469237-fe4e-4670-b137-e4c831868da4") },
                    { new Guid("ba5d7737-9eb4-4f94-bf9d-cb4aec1fe60c"), new Guid("1a4e0466-af1f-4053-a202-32f82316d565"), new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Billettautomat på Oslo S", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new Guid("8e469237-fe4e-4670-b137-e4c831868da4") },
                    { new Guid("3a24067c-639e-4868-a03b-8feee401ed2e"), new Guid("626d1226-fdc4-4b01-a6c6-bca01828f0fa"), new DateTime(2018, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Automat for betaling på Oslo S", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("8e469237-fe4e-4670-b137-e4c831868da4") }
                });

            migrationBuilder.InsertData(
                table: "UserCompanyList",
                columns: new[] { "UserItemId", "CompanyItemId" },
                values: new object[] { new Guid("2f5c3c5f-9869-4ef9-a992-4ac8c2d1d751"), new Guid("626d1226-fdc4-4b01-a6c6-bca01828f0fa") });

            migrationBuilder.InsertData(
                table: "UserRoleList",
                columns: new[] { "UserItemId", "RoleItemId" },
                values: new object[,]
                {
                    { new Guid("8e469237-fe4e-4670-b137-e4c831868da4"), new Guid("78b6ea9b-f87c-4966-b636-01d648681462") },
                    { new Guid("44f1ab9a-029f-499a-9baf-00776a6bcb44"), new Guid("78b6ea9b-f87c-4966-b636-01d648681462") },
                    { new Guid("8e469237-fe4e-4670-b137-e4c831868da4"), new Guid("175b54ba-c29e-46ce-874d-768ba96c0d8d") },
                    { new Guid("2f5c3c5f-9869-4ef9-a992-4ac8c2d1d751"), new Guid("de09be5a-acd2-4a7f-9e04-af4ca266ca64") }
                });
        }
    }
}
