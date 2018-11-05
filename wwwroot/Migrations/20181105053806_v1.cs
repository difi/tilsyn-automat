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
                    Name = table.Column<string>(nullable: true),
                    IsAdminRole = table.Column<bool>(nullable: false)
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
                    SocialSecurityNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastOnline = table.Column<DateTime>(nullable: false)
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
                    DeadLineDate = table.Column<DateTime>(nullable: false),
                    SentInDate = table.Column<DateTime>(nullable: false),
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
