using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CorporateIdentityNumber = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdPortenSub = table.Column<string>(nullable: true),
                    SocialSecurityNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactPersonList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    CompanyItemId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPersonList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactPersonList_CompanyList_CompanyItemId",
                        column: x => x.CompanyItemId,
                        principalTable: "CompanyList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeclarationList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyItemId = table.Column<Guid>(nullable: false),
                    UserItemId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeclarationList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeclarationList_CompanyList_CompanyItemId",
                        column: x => x.CompanyItemId,
                        principalTable: "CompanyList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeclarationList_UserList_UserItemId",
                        column: x => x.UserItemId,
                        principalTable: "UserList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCompanyList",
                columns: table => new
                {
                    UserItemId = table.Column<Guid>(nullable: false),
                    CompanyItemId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCompanyList", x => new { x.UserItemId, x.CompanyItemId });
                    table.ForeignKey(
                        name: "FK_UserCompanyList_CompanyList_CompanyItemId",
                        column: x => x.CompanyItemId,
                        principalTable: "CompanyList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCompanyList_UserList_UserItemId",
                        column: x => x.UserItemId,
                        principalTable: "UserList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleList",
                columns: table => new
                {
                    UserItemId = table.Column<Guid>(nullable: false),
                    RoleItemId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleList", x => new { x.UserItemId, x.RoleItemId });
                    table.ForeignKey(
                        name: "FK_UserRoleList_RoleList_RoleItemId",
                        column: x => x.RoleItemId,
                        principalTable: "RoleList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleList_UserList_UserItemId",
                        column: x => x.UserItemId,
                        principalTable: "UserList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ContactPersonList_CompanyItemId",
                table: "ContactPersonList",
                column: "CompanyItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationList_CompanyItemId",
                table: "DeclarationList",
                column: "CompanyItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationList_UserItemId",
                table: "DeclarationList",
                column: "UserItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompanyList_CompanyItemId",
                table: "UserCompanyList",
                column: "CompanyItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleList_RoleItemId",
                table: "UserRoleList",
                column: "RoleItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactPersonList");

            migrationBuilder.DropTable(
                name: "DeclarationList");

            migrationBuilder.DropTable(
                name: "UserCompanyList");

            migrationBuilder.DropTable(
                name: "UserRoleList");

            migrationBuilder.DropTable(
                name: "CompanyList");

            migrationBuilder.DropTable(
                name: "RoleList");

            migrationBuilder.DropTable(
                name: "UserList");
        }
    }
}
