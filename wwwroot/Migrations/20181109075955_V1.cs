using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: false),
                    CorporateIdentityNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CustomName = table.Column<string>(nullable: true),
                    AddressStreet = table.Column<string>(nullable: true),
                    AddressZip = table.Column<string>(nullable: true),
                    AddressCity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageList", x => x.Id);
                });

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
                name: "TypeOfMachineList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfMachineList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfSupplierAndVersionList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfSupplierAndVersionList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfTestList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfTestList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    SocialSecurityNumber = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true),
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
                    PhoneCountryCode = table.Column<string>(nullable: true),
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
                name: "DeclarationTestItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TypeOfMachineId = table.Column<int>(nullable: true),
                    TypeOfTestId = table.Column<int>(nullable: true),
                    SupplierAndVersionId = table.Column<int>(nullable: true),
                    SupplierAndVersionOther = table.Column<string>(nullable: true),
                    DescriptionInText = table.Column<string>(nullable: true),
                    Image1Id = table.Column<Guid>(nullable: true),
                    Image2Id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeclarationTestItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeclarationTestItem_ImageList_Image1Id",
                        column: x => x.Image1Id,
                        principalTable: "ImageList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeclarationTestItem_ImageList_Image2Id",
                        column: x => x.Image2Id,
                        principalTable: "ImageList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeclarationTestItem_TypeOfSupplierAndVersionList_SupplierAndVersionId",
                        column: x => x.SupplierAndVersionId,
                        principalTable: "TypeOfSupplierAndVersionList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeclarationTestItem_TypeOfMachineList_TypeOfMachineId",
                        column: x => x.TypeOfMachineId,
                        principalTable: "TypeOfMachineList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeclarationTestItem_TypeOfTestList_TypeOfTestId",
                        column: x => x.TypeOfTestId,
                        principalTable: "TypeOfTestList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "DeclarationList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyItemId = table.Column<Guid>(nullable: false),
                    UserItemId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DeadlineDate = table.Column<DateTime>(nullable: false),
                    SentInDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    DeclarationTestItemId = table.Column<Guid>(nullable: true)
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
                        name: "FK_DeclarationList_DeclarationTestItem_DeclarationTestItemId",
                        column: x => x.DeclarationTestItemId,
                        principalTable: "DeclarationTestItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeclarationList_UserList_UserItemId",
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
                    { new Guid("bdb5182d-8d56-4034-bfb3-36888e719ebe"), true, "Admin" },
                    { new Guid("ceb3e909-2d86-42de-951f-7646949718c1"), true, "Saksbehandlare" },
                    { new Guid("799cb2c6-ef81-4d43-aee5-c28fb405bcd6"), false, "Virksomhet" }
                });

            migrationBuilder.InsertData(
                table: "TypeOfMachineList",
                columns: new[] { "Id", "Text" },
                values: new object[,]
                {
                    { 4, "Minibank" },
                    { 3, "Selvbetjent kasse" },
                    { 2, "Billettautomat" },
                    { 5, "Vareautomat" },
                    { 1, "Betalingsterminal" }
                });

            migrationBuilder.InsertData(
                table: "TypeOfSupplierAndVersionList",
                columns: new[] { "Id", "Text" },
                values: new object[,]
                {
                    { 22, "Verifone Xenteo ECO" },
                    { 23, "Verifone Yomani XR" },
                    { 13, "Ingenico iWL251" },
                    { 21, "Verifone VX 820 Duet" },
                    { 20, "Verifone VX 820" },
                    { 19, "Verifone VX 690" },
                    { 18, "Verifone VX 680" },
                    { 17, "Verifone VX 520 C" },
                    { 16, "SumUp Air" },
                    { 15, "iZettle Reader" },
                    { 14, "Ingenico iWL252" },
                    { 12, "Ingenico iWL250G" },
                    { 8, "Ingenico isMP4" },
                    { 10, "Ingenico iWL250" },
                    { 9, "Ingenico iUP" },
                    { 7, "Ingenico iSMP" },
                    { 6, "Ingenico iSelf" },
                    { 5, "Ingenico iPP350" },
                    { 4, "Ingenico iCT250r" },
                    { 3, "Ingenico iCT250E" },
                    { 2, "Ingenico iCT250" },
                    { 1, "Vet ikke" },
                    { 11, "Ingenico iWL250B " }
                });

            migrationBuilder.InsertData(
                table: "TypeOfTestList",
                columns: new[] { "Id", "Text" },
                values: new object[,]
                {
                    { 2, "Webside" },
                    { 1, "Automat" },
                    { 3, "Applikasjon" }
                });

            migrationBuilder.InsertData(
                table: "UserList",
                columns: new[] { "Id", "CountryCode", "Created", "Email", "LastOnline", "Name", "Phone", "SocialSecurityNumber", "Title", "Token" },
                values: new object[,]
                {
                    { new Guid("04be8925-63ae-4253-8930-828e624cbea1"), "0047", new DateTime(2011, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "thea@difi.no", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thea Sneve", "712345678", "12089400269", "Handläggare", "72og6NuGTB95NqnWN4Mj2IF_pVgodGv_qZ1F8c8u77c=" },
                    { new Guid("1b21a2a1-36f5-47a3-a27b-49e241faafbe"), "0047", new DateTime(2011, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "martin@difi.no", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martin Swartling", "912345678", "12089400420", "Avdelingssjef", "fqgADdXVzSgBdjIGl1KloQWjN-qGPN66S1h8EiBtg3g=" }
                });

            migrationBuilder.InsertData(
                table: "UserRoleList",
                columns: new[] { "UserItemId", "RoleItemId" },
                values: new object[] { new Guid("1b21a2a1-36f5-47a3-a27b-49e241faafbe"), new Guid("bdb5182d-8d56-4034-bfb3-36888e719ebe") });

            migrationBuilder.InsertData(
                table: "UserRoleList",
                columns: new[] { "UserItemId", "RoleItemId" },
                values: new object[] { new Guid("1b21a2a1-36f5-47a3-a27b-49e241faafbe"), new Guid("ceb3e909-2d86-42de-951f-7646949718c1") });

            migrationBuilder.InsertData(
                table: "UserRoleList",
                columns: new[] { "UserItemId", "RoleItemId" },
                values: new object[] { new Guid("04be8925-63ae-4253-8930-828e624cbea1"), new Guid("ceb3e909-2d86-42de-951f-7646949718c1") });

            migrationBuilder.CreateIndex(
                name: "IX_ContactPersonList_CompanyItemId",
                table: "ContactPersonList",
                column: "CompanyItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationList_CompanyItemId",
                table: "DeclarationList",
                column: "CompanyItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationList_DeclarationTestItemId",
                table: "DeclarationList",
                column: "DeclarationTestItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationList_UserItemId",
                table: "DeclarationList",
                column: "UserItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationTestItem_Image1Id",
                table: "DeclarationTestItem",
                column: "Image1Id");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationTestItem_Image2Id",
                table: "DeclarationTestItem",
                column: "Image2Id");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationTestItem_SupplierAndVersionId",
                table: "DeclarationTestItem",
                column: "SupplierAndVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationTestItem_TypeOfMachineId",
                table: "DeclarationTestItem",
                column: "TypeOfMachineId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationTestItem_TypeOfTestId",
                table: "DeclarationTestItem",
                column: "TypeOfTestId");

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
                name: "LogList");

            migrationBuilder.DropTable(
                name: "UserCompanyList");

            migrationBuilder.DropTable(
                name: "UserRoleList");

            migrationBuilder.DropTable(
                name: "DeclarationTestItem");

            migrationBuilder.DropTable(
                name: "CompanyList");

            migrationBuilder.DropTable(
                name: "RoleList");

            migrationBuilder.DropTable(
                name: "UserList");

            migrationBuilder.DropTable(
                name: "ImageList");

            migrationBuilder.DropTable(
                name: "TypeOfSupplierAndVersionList");

            migrationBuilder.DropTable(
                name: "TypeOfMachineList");

            migrationBuilder.DropTable(
                name: "TypeOfTestList");
        }
    }
}
