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
                    ExternalId = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    CorporateIdentityNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    MailingAddressStreet = table.Column<string>(nullable: true),
                    MailingAddressZip = table.Column<string>(nullable: true),
                    MailingAddressCity = table.Column<string>(nullable: true),
                    LocationAddressStreet = table.Column<string>(nullable: true),
                    LocationAddressZip = table.Column<string>(nullable: true),
                    LocationAddressCity = table.Column<string>(nullable: true),
                    BusinessAddressStreet = table.Column<string>(nullable: true),
                    BusinessAddressZip = table.Column<string>(nullable: true),
                    BusinessAddressCity = table.Column<string>(nullable: true),
                    IndustryGroupCode = table.Column<string>(nullable: true),
                    IndustryGroupDescription = table.Column<string>(nullable: true),
                    IndustryGroupAggregated = table.Column<string>(nullable: true),
                    InstitutionalSectorCode = table.Column<string>(nullable: true),
                    InstitutionalSectorDescription = table.Column<string>(nullable: true),
                    OwenerCorporateIdentityNumber = table.Column<string>(nullable: true),
                    CustomName = table.Column<string>(nullable: true),
                    CustomAddressStreet = table.Column<string>(nullable: true),
                    CustomAddressZip = table.Column<string>(nullable: true),
                    CustomAddressCity = table.Column<string>(nullable: true)
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
                name: "StandardList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Standard = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestGroupList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestGroupList", x => x.Id);
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
                name: "VlFinishedStatusList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlFinishedStatusList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VlTypeOfAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlTypeOfAnswer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VlTypeOfMachineList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlTypeOfMachineList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VlTypeOfResult",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlTypeOfResult", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VlTypeOfSupplierAndVersionList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlTypeOfSupplierAndVersionList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VlTypeOfTestList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlTypeOfTestList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VlUserPrerequisiteList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlUserPrerequisiteList", x => x.Id);
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
                name: "ChapterList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StandardItemId = table.Column<Guid>(nullable: false),
                    ChapterNumber = table.Column<string>(nullable: true),
                    ChapterHeading = table.Column<string>(nullable: true),
                    RequirementsInSupervisor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChapterList_StandardList_StandardItemId",
                        column: x => x.StandardItemId,
                        principalTable: "StandardList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequirementList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TestGroupItemId = table.Column<Guid>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IndicatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequirementList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequirementList_TestGroupList_TestGroupItemId",
                        column: x => x.TestGroupItemId,
                        principalTable: "TestGroupList",
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

            migrationBuilder.CreateTable(
                name: "RequirementUserPrerequisiteList",
                columns: table => new
                {
                    RequirementItemId = table.Column<Guid>(nullable: false),
                    ValueListUserPrerequisiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequirementUserPrerequisiteList", x => new { x.RequirementItemId, x.ValueListUserPrerequisiteId });
                    table.ForeignKey(
                        name: "FK_RequirementUserPrerequisiteList_RequirementList_RequirementItemId",
                        column: x => x.RequirementItemId,
                        principalTable: "RequirementList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequirementUserPrerequisiteList_VlUserPrerequisiteList_ValueListUserPrerequisiteId",
                        column: x => x.ValueListUserPrerequisiteId,
                        principalTable: "VlUserPrerequisiteList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RuleList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RequirementItemId = table.Column<Guid>(nullable: false),
                    ChapterItemId = table.Column<Guid>(nullable: false),
                    StandardItemId = table.Column<Guid>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    Instruction = table.Column<string>(nullable: true),
                    Illustration = table.Column<string>(nullable: true),
                    HelpText = table.Column<string>(nullable: true),
                    ToolsNeed = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RuleList_ChapterList_ChapterItemId",
                        column: x => x.ChapterItemId,
                        principalTable: "ChapterList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RuleList_RequirementList_RequirementItemId",
                        column: x => x.RequirementItemId,
                        principalTable: "RequirementList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RuleList_StandardList_StandardItemId",
                        column: x => x.StandardItemId,
                        principalTable: "StandardList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeclarationTestGroupList",
                columns: table => new
                {
                    DeclarationItemId = table.Column<Guid>(nullable: false),
                    TestGroupItemId = table.Column<Guid>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeclarationTestGroupList", x => new { x.TestGroupItemId, x.DeclarationItemId });
                    table.ForeignKey(
                        name: "FK_DeclarationTestGroupList_DeclarationList_DeclarationItemId",
                        column: x => x.DeclarationItemId,
                        principalTable: "DeclarationList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeclarationTestGroupList_TestGroupList_TestGroupItemId",
                        column: x => x.TestGroupItemId,
                        principalTable: "TestGroupList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeclarationTestItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DeclarationItemId = table.Column<Guid>(nullable: false),
                    TypeOfMachineId = table.Column<int>(nullable: true),
                    TypeOfTestId = table.Column<int>(nullable: true),
                    SupplierAndVersionId = table.Column<int>(nullable: true),
                    SupplierAndVersionOther = table.Column<string>(nullable: true),
                    DescriptionInText = table.Column<string>(nullable: true),
                    CaseNumber = table.Column<string>(nullable: true),
                    FinishedStatusId = table.Column<int>(nullable: true),
                    Image1Id = table.Column<Guid>(nullable: true),
                    Image2Id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeclarationTestItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeclarationTestItem_DeclarationList_DeclarationItemId",
                        column: x => x.DeclarationItemId,
                        principalTable: "DeclarationList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeclarationTestItem_VlFinishedStatusList_FinishedStatusId",
                        column: x => x.FinishedStatusId,
                        principalTable: "VlFinishedStatusList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_DeclarationTestItem_VlTypeOfSupplierAndVersionList_SupplierAndVersionId",
                        column: x => x.SupplierAndVersionId,
                        principalTable: "VlTypeOfSupplierAndVersionList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeclarationTestItem_VlTypeOfMachineList_TypeOfMachineId",
                        column: x => x.TypeOfMachineId,
                        principalTable: "VlTypeOfMachineList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeclarationTestItem_VlTypeOfTestList_TypeOfTestId",
                        column: x => x.TypeOfTestId,
                        principalTable: "VlTypeOfTestList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnswerList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RuleItemId = table.Column<Guid>(nullable: false),
                    TypeOfAnswerId = table.Column<int>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    Bool = table.Column<bool>(nullable: false),
                    String = table.Column<string>(nullable: true),
                    MiniInt = table.Column<int>(nullable: false),
                    MaxInt = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerList_RuleList_RuleItemId",
                        column: x => x.RuleItemId,
                        principalTable: "RuleList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnswerList_VlTypeOfAnswer_TypeOfAnswerId",
                        column: x => x.TypeOfAnswerId,
                        principalTable: "VlTypeOfAnswer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutcomeData",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RequirementItemId = table.Column<Guid>(nullable: false),
                    ResultId = table.Column<int>(nullable: true),
                    ResultText = table.Column<string>(nullable: true),
                    DeclarationTestItemId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutcomeData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutcomeData_DeclarationTestItem_DeclarationTestItemId",
                        column: x => x.DeclarationTestItemId,
                        principalTable: "DeclarationTestItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OutcomeData_RequirementList_RequirementItemId",
                        column: x => x.RequirementItemId,
                        principalTable: "RequirementList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OutcomeData_VlTypeOfResult_ResultId",
                        column: x => x.ResultId,
                        principalTable: "VlTypeOfResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RuleData",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RuleId = table.Column<Guid>(nullable: true),
                    ResultId = table.Column<int>(nullable: true),
                    OutcomeDataId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RuleData_OutcomeData_OutcomeDataId",
                        column: x => x.OutcomeDataId,
                        principalTable: "OutcomeData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RuleData_VlTypeOfResult_ResultId",
                        column: x => x.ResultId,
                        principalTable: "VlTypeOfResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RuleData_RuleList_RuleId",
                        column: x => x.RuleId,
                        principalTable: "RuleList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnswerData",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RuleDataId = table.Column<Guid>(nullable: false),
                    TypeOfAnswerId = table.Column<int>(nullable: false),
                    AnswerItemId = table.Column<Guid>(nullable: false),
                    Bool = table.Column<bool>(nullable: false),
                    String = table.Column<string>(nullable: true),
                    Int = table.Column<int>(nullable: false),
                    ImageId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerData_AnswerList_AnswerItemId",
                        column: x => x.AnswerItemId,
                        principalTable: "AnswerList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnswerData_ImageList_ImageId",
                        column: x => x.ImageId,
                        principalTable: "ImageList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnswerData_RuleData_RuleDataId",
                        column: x => x.RuleDataId,
                        principalTable: "RuleData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnswerData_VlTypeOfAnswer_TypeOfAnswerId",
                        column: x => x.TypeOfAnswerId,
                        principalTable: "VlTypeOfAnswer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RoleList",
                columns: new[] { "Id", "IsAdminRole", "Name" },
                values: new object[,]
                {
                    { new Guid("e7a78cdc-49f9-4e6c-8abd-afcfc08ca5eb"), true, "Admin" },
                    { new Guid("9e184394-81bb-45cf-a157-dba79a3286d7"), true, "Saksbehandlare" },
                    { new Guid("5ae2ea91-e0a2-48e7-a77b-c1ede6b973e1"), false, "Virksomhet" }
                });

            migrationBuilder.InsertData(
                table: "StandardList",
                columns: new[] { "Id", "Standard" },
                values: new object[] { new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2"), "CEN/TS" });

            migrationBuilder.InsertData(
                table: "TestGroupList",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("aec1869a-30f8-403c-b909-df115173f009"), "Kundens betjeningsområde" },
                    { new Guid("b6c22ac9-d775-4dfd-ac8e-b4ca565ea3fb"), "Skilt" },
                    { new Guid("9aae6bc9-4b60-405c-81a7-ec142d8c1ca6"), "Betjeningshøyde" }
                });

            migrationBuilder.InsertData(
                table: "UserList",
                columns: new[] { "Id", "CountryCode", "Created", "Email", "LastOnline", "Name", "Phone", "SocialSecurityNumber", "Title", "Token" },
                values: new object[,]
                {
                    { new Guid("3812f52e-55a0-48d0-9a9c-54147c2fe90c"), "0047", new DateTime(2011, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "thea@difi.no", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thea Sneve", "712345678", "12089400269", "Handläggare", "72og6NuGTB95NqnWN4Mj2IF_pVgodGv_qZ1F8c8u77c=" },
                    { new Guid("27e6f983-d5c8-4a18-a7f9-977c410e17f0"), "0047", new DateTime(2011, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "martin@difi.no", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martin Swartling", "912345678", "12089400420", "Avdelingssjef", "fqgADdXVzSgBdjIGl1KloQWjN-qGPN66S1h8EiBtg3g=" }
                });

            migrationBuilder.InsertData(
                table: "VlFinishedStatusList",
                columns: new[] { "Id", "Text" },
                values: new object[,]
                {
                    { 1, "Inget" },
                    { 2, "Avvik" },
                    { 3, "Merknad" }
                });

            migrationBuilder.InsertData(
                table: "VlTypeOfAnswer",
                columns: new[] { "Id", "Text" },
                values: new object[,]
                {
                    { 1, "string" },
                    { 2, "bool" },
                    { 3, "int" },
                    { 4, "image" }
                });

            migrationBuilder.InsertData(
                table: "VlTypeOfMachineList",
                columns: new[] { "Id", "Text" },
                values: new object[,]
                {
                    { 5, "Vareautomat" },
                    { 4, "Minibank" },
                    { 3, "Selvbetjent kasse" },
                    { 2, "Billettautomat" },
                    { 1, "Betalingsterminal" }
                });

            migrationBuilder.InsertData(
                table: "VlTypeOfResult",
                columns: new[] { "Id", "Text" },
                values: new object[,]
                {
                    { 1, "Samsvar" },
                    { 2, "Brudd" },
                    { 3, "Ikke-forekomst" },
                    { 4, "Ikke testbar" },
                    { 5, "Ikke testa" }
                });

            migrationBuilder.InsertData(
                table: "VlTypeOfSupplierAndVersionList",
                columns: new[] { "Id", "Text" },
                values: new object[,]
                {
                    { 15, "iZettle Reader" },
                    { 16, "SumUp Air" },
                    { 17, "Verifone VX 520 C" },
                    { 18, "Verifone VX 680" },
                    { 22, "Verifone Xenteo ECO" },
                    { 20, "Verifone VX 820" },
                    { 21, "Verifone VX 820 Duet" },
                    { 14, "Ingenico iWL252" },
                    { 23, "Verifone Yomani XR" },
                    { 19, "Verifone VX 690" },
                    { 13, "Ingenico iWL251" },
                    { 6, "Ingenico iSelf" },
                    { 11, "Ingenico iWL250B " },
                    { 10, "Ingenico iWL250" },
                    { 9, "Ingenico iUP" },
                    { 8, "Ingenico isMP4" },
                    { 7, "Ingenico iSMP" },
                    { 5, "Ingenico iPP350" },
                    { 4, "Ingenico iCT250r" },
                    { 3, "Ingenico iCT250E" },
                    { 2, "Ingenico iCT250" },
                    { 1, "Vet ikke" },
                    { 12, "Ingenico iWL250G" }
                });

            migrationBuilder.InsertData(
                table: "VlTypeOfTestList",
                columns: new[] { "Id", "Text" },
                values: new object[,]
                {
                    { 3, "Applikasjon" },
                    { 2, "Webside" },
                    { 1, "Automat" }
                });

            migrationBuilder.InsertData(
                table: "VlUserPrerequisiteList",
                columns: new[] { "Id", "Text" },
                values: new object[,]
                {
                    { 10, "Fysisk størrelse" },
                    { 1, "Blinde" },
                    { 2, "Svaksynte" },
                    { 3, "Fargeblinde" },
                    { 4, "Døvblinde" },
                    { 5, "Døve" },
                    { 6, "Nedsett høyrsel/tunghøyrde" },
                    { 7, "Nedsett kognisjon" },
                    { 8, "Nedsett motorikk" },
                    { 9, "Fotosensitivitet/anfall" },
                    { 11, "Redusert taktil sensibilitet" }
                });

            migrationBuilder.InsertData(
                table: "ChapterList",
                columns: new[] { "Id", "ChapterHeading", "ChapterNumber", "RequirementsInSupervisor", "StandardItemId" },
                values: new object[] { new Guid("75468cd0-478b-45e9-8a8e-51b0e574fb3b"), "Location signs and visual indications ", "15291:2006 5.2", "Krav 1.3 Skilt skal plasseres over betalingsterminalen.", new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2") });

            migrationBuilder.InsertData(
                table: "RequirementList",
                columns: new[] { "Id", "Description", "IndicatorId", "Order", "TestGroupItemId" },
                values: new object[,]
                {
                    { new Guid("875e76b5-c926-43a0-8738-c4f41c7a0b8b"), "Krav 3.1 Betjeningsområdet foran betalingsterminalen skal være minst 150 x 150 centimeter. Det skal ikke være hindringer i betjeningsområdet.", 1, 1, new Guid("aec1869a-30f8-403c-b909-df115173f009") },
                    { new Guid("c65786bb-1b93-4153-b88c-935cc2a7ab60"), "Krav 3.5 Dersom to eller flere automater står ved siden av hverandre, skal det være minst 150 centimeter fra midten av automaten til midten av neste automat.", 1, 2, new Guid("aec1869a-30f8-403c-b909-df115173f009") },
                    { new Guid("aebd662d-9dd5-4a27-88d5-19d6c5e12e5a"), "Krav 1.3 Skilt skal plasseres over betalingsterminalen.", 1, 3, new Guid("b6c22ac9-d775-4dfd-ac8e-b4ca565ea3fb") },
                    { new Guid("e503322b-ed77-4b69-adc4-eca19b6eb97d"), "Krav 4.2: Høyden på betjeningskomponenter som skjerm og tastatur skal være mellom 75 centimeter og 130 centimeter over gulvet.", 1, 4, new Guid("9aae6bc9-4b60-405c-81a7-ec142d8c1ca6") }
                });

            migrationBuilder.InsertData(
                table: "UserRoleList",
                columns: new[] { "UserItemId", "RoleItemId" },
                values: new object[,]
                {
                    { new Guid("27e6f983-d5c8-4a18-a7f9-977c410e17f0"), new Guid("e7a78cdc-49f9-4e6c-8abd-afcfc08ca5eb") },
                    { new Guid("27e6f983-d5c8-4a18-a7f9-977c410e17f0"), new Guid("9e184394-81bb-45cf-a157-dba79a3286d7") },
                    { new Guid("3812f52e-55a0-48d0-9a9c-54147c2fe90c"), new Guid("9e184394-81bb-45cf-a157-dba79a3286d7") }
                });

            migrationBuilder.InsertData(
                table: "RuleList",
                columns: new[] { "Id", "ChapterItemId", "HelpText", "Illustration", "Instruction", "Order", "RequirementItemId", "StandardItemId", "ToolsNeed" },
                values: new object[] { new Guid("832e0843-cab3-4dbc-9799-974e283fcc0b"), new Guid("75468cd0-478b-45e9-8a8e-51b0e574fb3b"), "Krav: Skilt skal plasseres over betalingsterminalen.<br /><br />Det skal være et skilt som er synlig på avstand utenfor kundens betjeningsområde. Formålet er at brukeren kan finne fram til betalingsterminalen.<br /><br />Skiltet skal være plassert over området der kunden skal betale varene sine. Det kan for eksempel være over kassen eller disken der betalingsterminalen er plassert.<br /><br />Eksempler på tekst på skilt er<br />- Kasse<br />- Betal her<br />- Kort og kontant<br />- Nummer på kasse<br />", null, "Finnes det et skilt som viser hvor kunden skal betale varene sine?", 1, new Guid("e503322b-ed77-4b69-adc4-eca19b6eb97d"), new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2"), "Ingen" });

            migrationBuilder.InsertData(
                table: "RuleList",
                columns: new[] { "Id", "ChapterItemId", "HelpText", "Illustration", "Instruction", "Order", "RequirementItemId", "StandardItemId", "ToolsNeed" },
                values: new object[] { new Guid("4c4cd93b-ad4c-49b3-af05-f9e9fc7cb15a"), new Guid("75468cd0-478b-45e9-8a8e-51b0e574fb3b"), null, null, "Er skiltet plassert over området der kunden skal betale varene sine?", 2, new Guid("e503322b-ed77-4b69-adc4-eca19b6eb97d"), new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2"), "Ingen" });

            migrationBuilder.InsertData(
                table: "RuleList",
                columns: new[] { "Id", "ChapterItemId", "HelpText", "Illustration", "Instruction", "Order", "RequirementItemId", "StandardItemId", "ToolsNeed" },
                values: new object[] { new Guid("5cec30b8-2c28-4f7e-b9d7-6655a745c2ef"), new Guid("75468cd0-478b-45e9-8a8e-51b0e574fb3b"), null, null, "Er skiltet synlig på avstand utenfor kundens betjeningsområde?", 3, new Guid("e503322b-ed77-4b69-adc4-eca19b6eb97d"), new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2"), "Ingen" });

            migrationBuilder.InsertData(
                table: "AnswerList",
                columns: new[] { "Id", "Bool", "MaxInt", "MiniInt", "Order", "RuleItemId", "String", "TypeOfAnswerId" },
                values: new object[,]
                {
                    { new Guid("d8611e84-0f00-4d75-bcab-cbf127fb68b5"), true, 0, 0, 1, new Guid("832e0843-cab3-4dbc-9799-974e283fcc0b"), null, 2 },
                    { new Guid("c4870935-ee11-4557-a9c3-aca678c17565"), true, 0, 0, 2, new Guid("832e0843-cab3-4dbc-9799-974e283fcc0b"), null, 4 },
                    { new Guid("9a51cc68-857e-4822-ac81-0ec3ebe7bf43"), true, 0, 0, 1, new Guid("4c4cd93b-ad4c-49b3-af05-f9e9fc7cb15a"), null, 2 },
                    { new Guid("f69c1e45-99d8-4293-a242-c5ed9e126e99"), true, 0, 0, 1, new Guid("5cec30b8-2c28-4f7e-b9d7-6655a745c2ef"), null, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerData_AnswerItemId",
                table: "AnswerData",
                column: "AnswerItemId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerData_ImageId",
                table: "AnswerData",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerData_RuleDataId",
                table: "AnswerData",
                column: "RuleDataId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerData_TypeOfAnswerId",
                table: "AnswerData",
                column: "TypeOfAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerList_RuleItemId",
                table: "AnswerList",
                column: "RuleItemId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerList_TypeOfAnswerId",
                table: "AnswerList",
                column: "TypeOfAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_ChapterList_StandardItemId",
                table: "ChapterList",
                column: "StandardItemId");

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
                name: "IX_DeclarationTestGroupList_DeclarationItemId",
                table: "DeclarationTestGroupList",
                column: "DeclarationItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationTestItem_DeclarationItemId",
                table: "DeclarationTestItem",
                column: "DeclarationItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationTestItem_FinishedStatusId",
                table: "DeclarationTestItem",
                column: "FinishedStatusId");

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
                name: "IX_OutcomeData_DeclarationTestItemId",
                table: "OutcomeData",
                column: "DeclarationTestItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeData_RequirementItemId",
                table: "OutcomeData",
                column: "RequirementItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeData_ResultId",
                table: "OutcomeData",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_RequirementList_TestGroupItemId",
                table: "RequirementList",
                column: "TestGroupItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RequirementUserPrerequisiteList_ValueListUserPrerequisiteId",
                table: "RequirementUserPrerequisiteList",
                column: "ValueListUserPrerequisiteId");

            migrationBuilder.CreateIndex(
                name: "IX_RuleData_OutcomeDataId",
                table: "RuleData",
                column: "OutcomeDataId");

            migrationBuilder.CreateIndex(
                name: "IX_RuleData_ResultId",
                table: "RuleData",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_RuleData_RuleId",
                table: "RuleData",
                column: "RuleId");

            migrationBuilder.CreateIndex(
                name: "IX_RuleList_ChapterItemId",
                table: "RuleList",
                column: "ChapterItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RuleList_RequirementItemId",
                table: "RuleList",
                column: "RequirementItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RuleList_StandardItemId",
                table: "RuleList",
                column: "StandardItemId");

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
                name: "AnswerData");

            migrationBuilder.DropTable(
                name: "ContactPersonList");

            migrationBuilder.DropTable(
                name: "DeclarationTestGroupList");

            migrationBuilder.DropTable(
                name: "LogList");

            migrationBuilder.DropTable(
                name: "RequirementUserPrerequisiteList");

            migrationBuilder.DropTable(
                name: "UserCompanyList");

            migrationBuilder.DropTable(
                name: "UserRoleList");

            migrationBuilder.DropTable(
                name: "AnswerList");

            migrationBuilder.DropTable(
                name: "RuleData");

            migrationBuilder.DropTable(
                name: "VlUserPrerequisiteList");

            migrationBuilder.DropTable(
                name: "RoleList");

            migrationBuilder.DropTable(
                name: "VlTypeOfAnswer");

            migrationBuilder.DropTable(
                name: "OutcomeData");

            migrationBuilder.DropTable(
                name: "RuleList");

            migrationBuilder.DropTable(
                name: "DeclarationTestItem");

            migrationBuilder.DropTable(
                name: "VlTypeOfResult");

            migrationBuilder.DropTable(
                name: "ChapterList");

            migrationBuilder.DropTable(
                name: "RequirementList");

            migrationBuilder.DropTable(
                name: "DeclarationList");

            migrationBuilder.DropTable(
                name: "VlFinishedStatusList");

            migrationBuilder.DropTable(
                name: "ImageList");

            migrationBuilder.DropTable(
                name: "VlTypeOfSupplierAndVersionList");

            migrationBuilder.DropTable(
                name: "VlTypeOfMachineList");

            migrationBuilder.DropTable(
                name: "VlTypeOfTestList");

            migrationBuilder.DropTable(
                name: "StandardList");

            migrationBuilder.DropTable(
                name: "TestGroupList");

            migrationBuilder.DropTable(
                name: "CompanyList");

            migrationBuilder.DropTable(
                name: "UserList");
        }
    }
}
