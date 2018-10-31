using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactPersonList",
                keyColumn: "Id",
                keyValue: new Guid("0448a490-87f3-48a4-b283-2bae744d50b3"));

            migrationBuilder.DeleteData(
                table: "ContactPersonList",
                keyColumn: "Id",
                keyValue: new Guid("14398b07-0c6d-4945-88c7-0ce6eff71111"));

            migrationBuilder.DeleteData(
                table: "ContactPersonList",
                keyColumn: "Id",
                keyValue: new Guid("36f61efa-04b1-4dcf-8574-18402fc1e68a"));

            migrationBuilder.DeleteData(
                table: "ContactPersonList",
                keyColumn: "Id",
                keyValue: new Guid("95e64f0b-bab2-4b1e-8988-c9a91daf6165"));

            migrationBuilder.DeleteData(
                table: "ContactPersonList",
                keyColumn: "Id",
                keyValue: new Guid("bf1cae40-31d5-4be5-a19f-7088ac55312d"));

            migrationBuilder.DeleteData(
                table: "ContactPersonList",
                keyColumn: "Id",
                keyValue: new Guid("c008576e-a5d7-4b68-83a1-072d9af27496"));

            migrationBuilder.DeleteData(
                table: "DeclarationList",
                keyColumn: "Id",
                keyValue: new Guid("2d73f979-3f9f-4ebd-9a4c-f777fe15074f"));

            migrationBuilder.DeleteData(
                table: "DeclarationList",
                keyColumn: "Id",
                keyValue: new Guid("367d7568-abaa-4ce9-a4f3-e829e8450c68"));

            migrationBuilder.DeleteData(
                table: "DeclarationList",
                keyColumn: "Id",
                keyValue: new Guid("3f523e86-22c9-4190-8c01-f05dcb18078a"));

            migrationBuilder.DeleteData(
                table: "DeclarationList",
                keyColumn: "Id",
                keyValue: new Guid("42ffe6ce-3922-42e0-a962-9c93b912dfe3"));

            migrationBuilder.DeleteData(
                table: "DeclarationList",
                keyColumn: "Id",
                keyValue: new Guid("9443e26b-d738-4df7-96f8-9a753dbaeb7c"));

            migrationBuilder.DeleteData(
                table: "DeclarationList",
                keyColumn: "Id",
                keyValue: new Guid("cc3f99f1-665f-4a29-bded-7c82c26531d9"));

            migrationBuilder.DeleteData(
                table: "UserCompanyList",
                keyColumns: new[] { "UserItemId", "CompanyItemId" },
                keyValues: new object[] { new Guid("4528be50-8862-47bd-8cef-554889d3ba98"), new Guid("51f48375-7d96-422e-a129-4bc03d5abedd") });

            migrationBuilder.DeleteData(
                table: "UserRoleList",
                keyColumns: new[] { "UserItemId", "RoleItemId" },
                keyValues: new object[] { new Guid("2c22c3e7-3e79-4e72-a967-130ffe7a3dda"), new Guid("575b7e24-8b5f-4f1b-b797-064ad5d4b29f") });

            migrationBuilder.DeleteData(
                table: "UserRoleList",
                keyColumns: new[] { "UserItemId", "RoleItemId" },
                keyValues: new object[] { new Guid("4528be50-8862-47bd-8cef-554889d3ba98"), new Guid("e2b7e34a-43b1-4537-8887-7d4b938beb99") });

            migrationBuilder.DeleteData(
                table: "UserRoleList",
                keyColumns: new[] { "UserItemId", "RoleItemId" },
                keyValues: new object[] { new Guid("54864875-bfa9-4435-919e-907f945c4634"), new Guid("575b7e24-8b5f-4f1b-b797-064ad5d4b29f") });

            migrationBuilder.DeleteData(
                table: "UserRoleList",
                keyColumns: new[] { "UserItemId", "RoleItemId" },
                keyValues: new object[] { new Guid("54864875-bfa9-4435-919e-907f945c4634"), new Guid("ed085d53-7077-428e-8280-5f7b7ee45533") });

            migrationBuilder.DeleteData(
                table: "CompanyList",
                keyColumn: "Id",
                keyValue: new Guid("2ddb0183-bb9a-4c6d-bd63-6bfac0afe045"));

            migrationBuilder.DeleteData(
                table: "CompanyList",
                keyColumn: "Id",
                keyValue: new Guid("51f48375-7d96-422e-a129-4bc03d5abedd"));

            migrationBuilder.DeleteData(
                table: "CompanyList",
                keyColumn: "Id",
                keyValue: new Guid("9bf11062-4de1-4fde-b807-fdc9405d57c0"));

            migrationBuilder.DeleteData(
                table: "CompanyList",
                keyColumn: "Id",
                keyValue: new Guid("c7aa255b-1a09-4dcc-bc8d-061f44353aec"));

            migrationBuilder.DeleteData(
                table: "CompanyList",
                keyColumn: "Id",
                keyValue: new Guid("e4f8d018-e745-4471-a3cd-80e5ddec071c"));

            migrationBuilder.DeleteData(
                table: "CompanyList",
                keyColumn: "Id",
                keyValue: new Guid("f9eafa03-f494-4794-a327-3bb959d268d8"));

            migrationBuilder.DeleteData(
                table: "RoleList",
                keyColumn: "Id",
                keyValue: new Guid("575b7e24-8b5f-4f1b-b797-064ad5d4b29f"));

            migrationBuilder.DeleteData(
                table: "RoleList",
                keyColumn: "Id",
                keyValue: new Guid("e2b7e34a-43b1-4537-8887-7d4b938beb99"));

            migrationBuilder.DeleteData(
                table: "RoleList",
                keyColumn: "Id",
                keyValue: new Guid("ed085d53-7077-428e-8280-5f7b7ee45533"));

            migrationBuilder.DeleteData(
                table: "UserList",
                keyColumn: "Id",
                keyValue: new Guid("2c22c3e7-3e79-4e72-a967-130ffe7a3dda"));

            migrationBuilder.DeleteData(
                table: "UserList",
                keyColumn: "Id",
                keyValue: new Guid("4528be50-8862-47bd-8cef-554889d3ba98"));

            migrationBuilder.DeleteData(
                table: "UserList",
                keyColumn: "Id",
                keyValue: new Guid("54864875-bfa9-4435-919e-907f945c4634"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeadLineDate",
                table: "DeclarationList",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SentInDate",
                table: "DeclarationList",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "CompanyList",
                columns: new[] { "Id", "Code", "CorporateIdentityNumber", "Name" },
                values: new object[,]
                {
                    { new Guid("217bca57-cb46-49e4-9c6a-c59df606ae81"), "1111", "123456789", "Narvesen" },
                    { new Guid("75efef68-2248-40b5-a6cb-ee4455949605"), "2222", "987654321", "Norwegian" },
                    { new Guid("08d5d059-4469-4c35-b2f7-0e402588c28d"), "3333", "1122334455", "NSB" },
                    { new Guid("6419618e-d641-45a9-8a90-5d5c5878bb99"), "4444", "1122334455", "Esso" },
                    { new Guid("f5c759dc-b0ce-4f7c-8273-5938e0ca613c"), "5555", "1122334455", "7 - eleven" },
                    { new Guid("e2d4b5de-e887-4777-9f66-1cfc508bc105"), "6666", "1122334455", "Norske bank" }
                });

            migrationBuilder.InsertData(
                table: "RoleList",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2d1e5be4-9885-498a-9daa-295c3c931c30"), "Admin" },
                    { new Guid("42689f82-21bd-4766-a504-7637302f18a5"), "Saksbehandlare" },
                    { new Guid("2eb2cb19-2be7-4df6-807f-20de54a29786"), "Verksamhet" }
                });

            migrationBuilder.InsertData(
                table: "UserList",
                columns: new[] { "Id", "Email", "IdPortenSub", "Name", "Phone", "SocialSecurityNumber" },
                values: new object[,]
                {
                    { new Guid("59d08447-fa82-4b09-94f1-5e6eb0b80624"), null, "fqgADdXVzSgBdjIGl1KloQWjN-qGPN66S1h8EiBtg3g=", "Thea", null, "12089400420" },
                    { new Guid("ff6c5592-2594-419e-a147-82e233e80f8d"), null, "72og6NuGTB95NqnWN4Mj2IF_pVgodGv_qZ1F8c8u77c=", "Martin", null, "12089400269" },
                    { new Guid("aef385a1-a72f-4e71-8a53-05f5403dfe02"), null, "8zrqvL9yMbkJAfU_53_WE1jbTFUehgxmf7MADGcv98g=", "", null, "12089400188" }
                });

            migrationBuilder.InsertData(
                table: "ContactPersonList",
                columns: new[] { "Id", "CompanyItemId", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { new Guid("9895b72d-1842-4b18-a44b-a1e2f0840553"), new Guid("217bca57-cb46-49e4-9c6a-c59df606ae81"), "henrik.juhlin@funka.com", "Henrik Juhlin", "070-601 75 46" },
                    { new Guid("807f15cf-3573-4da0-988b-5a2db115b706"), new Guid("75efef68-2248-40b5-a6cb-ee4455949605"), "henrik.juhlin@funka.com", "Henrik Juhlin", "070-601 75 46" },
                    { new Guid("5bb4865d-b202-4d9f-aadb-bd91ec561416"), new Guid("08d5d059-4469-4c35-b2f7-0e402588c28d"), "henrik.juhlin@funka.com", "Henrik Juhlin", "070-601 75 46" },
                    { new Guid("ac6e2c54-9dbe-4fb3-8e63-c6ff22e33988"), new Guid("6419618e-d641-45a9-8a90-5d5c5878bb99"), "henrik.juhlin@funka.com", "Henrik Juhlin", "070-601 75 46" },
                    { new Guid("dfdd5dbd-a26b-4a20-a3d0-24c75fcf5a40"), new Guid("f5c759dc-b0ce-4f7c-8273-5938e0ca613c"), "henrik.juhlin@funka.com", "Henrik Juhlin", "070-601 75 46" },
                    { new Guid("1e5ef8cd-3c47-4fe9-99cd-a2dd990f834e"), new Guid("e2d4b5de-e887-4777-9f66-1cfc508bc105"), "henrik.juhlin@funka.com", "Henrik Juhlin", "070-601 75 46" }
                });

            migrationBuilder.InsertData(
                table: "DeclarationList",
                columns: new[] { "Id", "CompanyItemId", "CreatedDate", "DeadLineDate", "Name", "SentInDate", "Status", "UserItemId" },
                values: new object[,]
                {
                    { new Guid("e3f6952a-9ca2-4683-960a-2a544c761af1"), new Guid("e2d4b5de-e887-4777-9f66-1cfc508bc105"), new DateTime(2018, 10, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Billettautomat Kristiansand", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new Guid("ff6c5592-2594-419e-a147-82e233e80f8d") },
                    { new Guid("87140fbe-bcc4-4f1a-933d-75ccc5dedd96"), new Guid("6419618e-d641-45a9-8a90-5d5c5878bb99"), new DateTime(2018, 10, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Betalingsautomat Trondheim", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new Guid("ff6c5592-2594-419e-a147-82e233e80f8d") },
                    { new Guid("0b50e67c-d07d-4c8b-b7ac-b68289d9abec"), new Guid("75efef68-2248-40b5-a6cb-ee4455949605"), new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Billettautomat Gardemoen", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("ff6c5592-2594-419e-a147-82e233e80f8d") },
                    { new Guid("bc92c366-234f-480d-8f61-0a735cc70789"), new Guid("f5c759dc-b0ce-4f7c-8273-5938e0ca613c"), new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Automat Grensen", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("59d08447-fa82-4b09-94f1-5e6eb0b80624") },
                    { new Guid("bd87a432-b6bb-47ec-90d4-ef4cf2123658"), new Guid("08d5d059-4469-4c35-b2f7-0e402588c28d"), new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Billettautomat på Oslo S", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new Guid("59d08447-fa82-4b09-94f1-5e6eb0b80624") },
                    { new Guid("3aa82697-77b6-4885-b716-ea6a96e7a72c"), new Guid("217bca57-cb46-49e4-9c6a-c59df606ae81"), new DateTime(2018, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Automat for betaling på Oslo S", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("59d08447-fa82-4b09-94f1-5e6eb0b80624") }
                });

            migrationBuilder.InsertData(
                table: "UserCompanyList",
                columns: new[] { "UserItemId", "CompanyItemId" },
                values: new object[] { new Guid("aef385a1-a72f-4e71-8a53-05f5403dfe02"), new Guid("217bca57-cb46-49e4-9c6a-c59df606ae81") });

            migrationBuilder.InsertData(
                table: "UserRoleList",
                columns: new[] { "UserItemId", "RoleItemId" },
                values: new object[,]
                {
                    { new Guid("59d08447-fa82-4b09-94f1-5e6eb0b80624"), new Guid("42689f82-21bd-4766-a504-7637302f18a5") },
                    { new Guid("ff6c5592-2594-419e-a147-82e233e80f8d"), new Guid("42689f82-21bd-4766-a504-7637302f18a5") },
                    { new Guid("59d08447-fa82-4b09-94f1-5e6eb0b80624"), new Guid("2d1e5be4-9885-498a-9daa-295c3c931c30") },
                    { new Guid("aef385a1-a72f-4e71-8a53-05f5403dfe02"), new Guid("2eb2cb19-2be7-4df6-807f-20de54a29786") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactPersonList",
                keyColumn: "Id",
                keyValue: new Guid("1e5ef8cd-3c47-4fe9-99cd-a2dd990f834e"));

            migrationBuilder.DeleteData(
                table: "ContactPersonList",
                keyColumn: "Id",
                keyValue: new Guid("5bb4865d-b202-4d9f-aadb-bd91ec561416"));

            migrationBuilder.DeleteData(
                table: "ContactPersonList",
                keyColumn: "Id",
                keyValue: new Guid("807f15cf-3573-4da0-988b-5a2db115b706"));

            migrationBuilder.DeleteData(
                table: "ContactPersonList",
                keyColumn: "Id",
                keyValue: new Guid("9895b72d-1842-4b18-a44b-a1e2f0840553"));

            migrationBuilder.DeleteData(
                table: "ContactPersonList",
                keyColumn: "Id",
                keyValue: new Guid("ac6e2c54-9dbe-4fb3-8e63-c6ff22e33988"));

            migrationBuilder.DeleteData(
                table: "ContactPersonList",
                keyColumn: "Id",
                keyValue: new Guid("dfdd5dbd-a26b-4a20-a3d0-24c75fcf5a40"));

            migrationBuilder.DeleteData(
                table: "DeclarationList",
                keyColumn: "Id",
                keyValue: new Guid("0b50e67c-d07d-4c8b-b7ac-b68289d9abec"));

            migrationBuilder.DeleteData(
                table: "DeclarationList",
                keyColumn: "Id",
                keyValue: new Guid("3aa82697-77b6-4885-b716-ea6a96e7a72c"));

            migrationBuilder.DeleteData(
                table: "DeclarationList",
                keyColumn: "Id",
                keyValue: new Guid("87140fbe-bcc4-4f1a-933d-75ccc5dedd96"));

            migrationBuilder.DeleteData(
                table: "DeclarationList",
                keyColumn: "Id",
                keyValue: new Guid("bc92c366-234f-480d-8f61-0a735cc70789"));

            migrationBuilder.DeleteData(
                table: "DeclarationList",
                keyColumn: "Id",
                keyValue: new Guid("bd87a432-b6bb-47ec-90d4-ef4cf2123658"));

            migrationBuilder.DeleteData(
                table: "DeclarationList",
                keyColumn: "Id",
                keyValue: new Guid("e3f6952a-9ca2-4683-960a-2a544c761af1"));

            migrationBuilder.DeleteData(
                table: "UserCompanyList",
                keyColumns: new[] { "UserItemId", "CompanyItemId" },
                keyValues: new object[] { new Guid("aef385a1-a72f-4e71-8a53-05f5403dfe02"), new Guid("217bca57-cb46-49e4-9c6a-c59df606ae81") });

            migrationBuilder.DeleteData(
                table: "UserRoleList",
                keyColumns: new[] { "UserItemId", "RoleItemId" },
                keyValues: new object[] { new Guid("59d08447-fa82-4b09-94f1-5e6eb0b80624"), new Guid("2d1e5be4-9885-498a-9daa-295c3c931c30") });

            migrationBuilder.DeleteData(
                table: "UserRoleList",
                keyColumns: new[] { "UserItemId", "RoleItemId" },
                keyValues: new object[] { new Guid("59d08447-fa82-4b09-94f1-5e6eb0b80624"), new Guid("42689f82-21bd-4766-a504-7637302f18a5") });

            migrationBuilder.DeleteData(
                table: "UserRoleList",
                keyColumns: new[] { "UserItemId", "RoleItemId" },
                keyValues: new object[] { new Guid("aef385a1-a72f-4e71-8a53-05f5403dfe02"), new Guid("2eb2cb19-2be7-4df6-807f-20de54a29786") });

            migrationBuilder.DeleteData(
                table: "UserRoleList",
                keyColumns: new[] { "UserItemId", "RoleItemId" },
                keyValues: new object[] { new Guid("ff6c5592-2594-419e-a147-82e233e80f8d"), new Guid("42689f82-21bd-4766-a504-7637302f18a5") });

            migrationBuilder.DeleteData(
                table: "CompanyList",
                keyColumn: "Id",
                keyValue: new Guid("08d5d059-4469-4c35-b2f7-0e402588c28d"));

            migrationBuilder.DeleteData(
                table: "CompanyList",
                keyColumn: "Id",
                keyValue: new Guid("217bca57-cb46-49e4-9c6a-c59df606ae81"));

            migrationBuilder.DeleteData(
                table: "CompanyList",
                keyColumn: "Id",
                keyValue: new Guid("6419618e-d641-45a9-8a90-5d5c5878bb99"));

            migrationBuilder.DeleteData(
                table: "CompanyList",
                keyColumn: "Id",
                keyValue: new Guid("75efef68-2248-40b5-a6cb-ee4455949605"));

            migrationBuilder.DeleteData(
                table: "CompanyList",
                keyColumn: "Id",
                keyValue: new Guid("e2d4b5de-e887-4777-9f66-1cfc508bc105"));

            migrationBuilder.DeleteData(
                table: "CompanyList",
                keyColumn: "Id",
                keyValue: new Guid("f5c759dc-b0ce-4f7c-8273-5938e0ca613c"));

            migrationBuilder.DeleteData(
                table: "RoleList",
                keyColumn: "Id",
                keyValue: new Guid("2d1e5be4-9885-498a-9daa-295c3c931c30"));

            migrationBuilder.DeleteData(
                table: "RoleList",
                keyColumn: "Id",
                keyValue: new Guid("2eb2cb19-2be7-4df6-807f-20de54a29786"));

            migrationBuilder.DeleteData(
                table: "RoleList",
                keyColumn: "Id",
                keyValue: new Guid("42689f82-21bd-4766-a504-7637302f18a5"));

            migrationBuilder.DeleteData(
                table: "UserList",
                keyColumn: "Id",
                keyValue: new Guid("59d08447-fa82-4b09-94f1-5e6eb0b80624"));

            migrationBuilder.DeleteData(
                table: "UserList",
                keyColumn: "Id",
                keyValue: new Guid("aef385a1-a72f-4e71-8a53-05f5403dfe02"));

            migrationBuilder.DeleteData(
                table: "UserList",
                keyColumn: "Id",
                keyValue: new Guid("ff6c5592-2594-419e-a147-82e233e80f8d"));

            migrationBuilder.DropColumn(
                name: "DeadLineDate",
                table: "DeclarationList");

            migrationBuilder.DropColumn(
                name: "SentInDate",
                table: "DeclarationList");

            migrationBuilder.InsertData(
                table: "CompanyList",
                columns: new[] { "Id", "Code", "CorporateIdentityNumber", "Name" },
                values: new object[,]
                {
                    { new Guid("51f48375-7d96-422e-a129-4bc03d5abedd"), "1111", "123456789", "Narvesen" },
                    { new Guid("c7aa255b-1a09-4dcc-bc8d-061f44353aec"), "2222", "987654321", "Norwegian" },
                    { new Guid("e4f8d018-e745-4471-a3cd-80e5ddec071c"), "3333", "1122334455", "NSB" },
                    { new Guid("f9eafa03-f494-4794-a327-3bb959d268d8"), "4444", "1122334455", "Esso" },
                    { new Guid("9bf11062-4de1-4fde-b807-fdc9405d57c0"), "5555", "1122334455", "7 - eleven" },
                    { new Guid("2ddb0183-bb9a-4c6d-bd63-6bfac0afe045"), "6666", "1122334455", "Norske bank" }
                });

            migrationBuilder.InsertData(
                table: "RoleList",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("ed085d53-7077-428e-8280-5f7b7ee45533"), "Admin" },
                    { new Guid("575b7e24-8b5f-4f1b-b797-064ad5d4b29f"), "Saksbehandlare" },
                    { new Guid("e2b7e34a-43b1-4537-8887-7d4b938beb99"), "Verksamhet" }
                });

            migrationBuilder.InsertData(
                table: "UserList",
                columns: new[] { "Id", "Email", "IdPortenSub", "Name", "Phone", "SocialSecurityNumber" },
                values: new object[,]
                {
                    { new Guid("54864875-bfa9-4435-919e-907f945c4634"), null, "fqgADdXVzSgBdjIGl1KloQWjN-qGPN66S1h8EiBtg3g=", "Thea", null, "12089400420" },
                    { new Guid("2c22c3e7-3e79-4e72-a967-130ffe7a3dda"), null, "72og6NuGTB95NqnWN4Mj2IF_pVgodGv_qZ1F8c8u77c=", "Martin", null, "12089400269" },
                    { new Guid("4528be50-8862-47bd-8cef-554889d3ba98"), null, "8zrqvL9yMbkJAfU_53_WE1jbTFUehgxmf7MADGcv98g=", "", null, "12089400188" }
                });

            migrationBuilder.InsertData(
                table: "ContactPersonList",
                columns: new[] { "Id", "CompanyItemId", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { new Guid("c008576e-a5d7-4b68-83a1-072d9af27496"), new Guid("51f48375-7d96-422e-a129-4bc03d5abedd"), "henrik.juhlin@funka.com", "Henrik Juhlin", "070-601 75 46" },
                    { new Guid("bf1cae40-31d5-4be5-a19f-7088ac55312d"), new Guid("c7aa255b-1a09-4dcc-bc8d-061f44353aec"), "henrik.juhlin@funka.com", "Henrik Juhlin", "070-601 75 46" },
                    { new Guid("0448a490-87f3-48a4-b283-2bae744d50b3"), new Guid("e4f8d018-e745-4471-a3cd-80e5ddec071c"), "henrik.juhlin@funka.com", "Henrik Juhlin", "070-601 75 46" },
                    { new Guid("14398b07-0c6d-4945-88c7-0ce6eff71111"), new Guid("f9eafa03-f494-4794-a327-3bb959d268d8"), "henrik.juhlin@funka.com", "Henrik Juhlin", "070-601 75 46" },
                    { new Guid("36f61efa-04b1-4dcf-8574-18402fc1e68a"), new Guid("9bf11062-4de1-4fde-b807-fdc9405d57c0"), "henrik.juhlin@funka.com", "Henrik Juhlin", "070-601 75 46" },
                    { new Guid("95e64f0b-bab2-4b1e-8988-c9a91daf6165"), new Guid("2ddb0183-bb9a-4c6d-bd63-6bfac0afe045"), "henrik.juhlin@funka.com", "Henrik Juhlin", "070-601 75 46" }
                });

            migrationBuilder.InsertData(
                table: "DeclarationList",
                columns: new[] { "Id", "CompanyItemId", "CreatedDate", "Name", "Status", "UserItemId" },
                values: new object[,]
                {
                    { new Guid("367d7568-abaa-4ce9-a4f3-e829e8450c68"), new Guid("2ddb0183-bb9a-4c6d-bd63-6bfac0afe045"), new DateTime(2018, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), "Billettautomat Kristiansand", 4, new Guid("2c22c3e7-3e79-4e72-a967-130ffe7a3dda") },
                    { new Guid("9443e26b-d738-4df7-96f8-9a753dbaeb7c"), new Guid("f9eafa03-f494-4794-a327-3bb959d268d8"), new DateTime(2018, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), "Betalingsautomat Trondheim", 3, new Guid("2c22c3e7-3e79-4e72-a967-130ffe7a3dda") },
                    { new Guid("42ffe6ce-3922-42e0-a962-9c93b912dfe3"), new Guid("c7aa255b-1a09-4dcc-bc8d-061f44353aec"), new DateTime(2018, 10, 25, 0, 0, 0, 0, DateTimeKind.Local), "Billettautomat Gardemoen", 0, new Guid("2c22c3e7-3e79-4e72-a967-130ffe7a3dda") },
                    { new Guid("3f523e86-22c9-4190-8c01-f05dcb18078a"), new Guid("9bf11062-4de1-4fde-b807-fdc9405d57c0"), new DateTime(2018, 10, 25, 0, 0, 0, 0, DateTimeKind.Local), "Automat Grensen", 2, new Guid("54864875-bfa9-4435-919e-907f945c4634") },
                    { new Guid("cc3f99f1-665f-4a29-bded-7c82c26531d9"), new Guid("e4f8d018-e745-4471-a3cd-80e5ddec071c"), new DateTime(2018, 10, 25, 0, 0, 0, 0, DateTimeKind.Local), "Billettautomat på Oslo S", 3, new Guid("54864875-bfa9-4435-919e-907f945c4634") },
                    { new Guid("2d73f979-3f9f-4ebd-9a4c-f777fe15074f"), new Guid("51f48375-7d96-422e-a129-4bc03d5abedd"), new DateTime(2018, 10, 20, 0, 0, 0, 0, DateTimeKind.Local), "Automat for betaling på Oslo S", 1, new Guid("54864875-bfa9-4435-919e-907f945c4634") }
                });

            migrationBuilder.InsertData(
                table: "UserCompanyList",
                columns: new[] { "UserItemId", "CompanyItemId" },
                values: new object[] { new Guid("4528be50-8862-47bd-8cef-554889d3ba98"), new Guid("51f48375-7d96-422e-a129-4bc03d5abedd") });

            migrationBuilder.InsertData(
                table: "UserRoleList",
                columns: new[] { "UserItemId", "RoleItemId" },
                values: new object[,]
                {
                    { new Guid("54864875-bfa9-4435-919e-907f945c4634"), new Guid("575b7e24-8b5f-4f1b-b797-064ad5d4b29f") },
                    { new Guid("2c22c3e7-3e79-4e72-a967-130ffe7a3dda"), new Guid("575b7e24-8b5f-4f1b-b797-064ad5d4b29f") },
                    { new Guid("54864875-bfa9-4435-919e-907f945c4634"), new Guid("ed085d53-7077-428e-8280-5f7b7ee45533") },
                    { new Guid("4528be50-8862-47bd-8cef-554889d3ba98"), new Guid("e2b7e34a-43b1-4537-8887-7d4b938beb99") }
                });
        }
    }
}
