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
                name: "IndicatorList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LastChanged = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicatorList", x => x.Id);
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
                    Standard = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
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
                name: "RequirementList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IndicatorItemId = table.Column<Guid>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequirementList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequirementList_IndicatorList_IndicatorItemId",
                        column: x => x.IndicatorItemId,
                        principalTable: "IndicatorList",
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
                    ChapterHeading = table.Column<string>(nullable: true)
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
                name: "IndicatorTestGroupList",
                columns: table => new
                {
                    IndicatorItemId = table.Column<Guid>(nullable: false),
                    TestGroupItemId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicatorTestGroupList", x => new { x.TestGroupItemId, x.IndicatorItemId });
                    table.ForeignKey(
                        name: "FK_IndicatorTestGroupList_TestGroupList_IndicatorItemId",
                        column: x => x.IndicatorItemId,
                        principalTable: "TestGroupList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndicatorTestGroupList_IndicatorList_TestGroupItemId",
                        column: x => x.TestGroupItemId,
                        principalTable: "IndicatorList",
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
                name: "IndicatorUserPrerequisite",
                columns: table => new
                {
                    IndicatorItemId = table.Column<Guid>(nullable: false),
                    ValueListUserPrerequisiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicatorUserPrerequisite", x => new { x.IndicatorItemId, x.ValueListUserPrerequisiteId });
                    table.ForeignKey(
                        name: "FK_IndicatorUserPrerequisite_IndicatorList_IndicatorItemId",
                        column: x => x.IndicatorItemId,
                        principalTable: "IndicatorList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndicatorUserPrerequisite_VlUserPrerequisiteList_ValueListUserPrerequisiteId",
                        column: x => x.ValueListUserPrerequisiteId,
                        principalTable: "VlUserPrerequisiteList",
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
                    Illustration = table.Column<string>(nullable: true),
                    HelpText = table.Column<string>(nullable: true),
                    ToolsNeed = table.Column<string>(nullable: true),
                    IndicatorItemId = table.Column<Guid>(nullable: true)
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
                        name: "FK_RuleList_IndicatorList_IndicatorItemId",
                        column: x => x.IndicatorItemId,
                        principalTable: "IndicatorList",
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
                    Question = table.Column<string>(nullable: true),
                    ViewIfOtherFailed = table.Column<bool>(nullable: false),
                    ViewIfOtherFaildId = table.Column<Guid>(nullable: false),
                    Bool = table.Column<bool>(nullable: false),
                    MinInt = table.Column<int>(nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
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
                    IndicatorItemId = table.Column<Guid>(nullable: false),
                    RequirementItemId = table.Column<Guid>(nullable: false),
                    DeclarationTestItemId = table.Column<Guid>(nullable: false),
                    ResultId = table.Column<int>(nullable: false),
                    ResultText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutcomeData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutcomeData_DeclarationTestItem_DeclarationTestItemId",
                        column: x => x.DeclarationTestItemId,
                        principalTable: "DeclarationTestItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutcomeData_IndicatorList_IndicatorItemId",
                        column: x => x.IndicatorItemId,
                        principalTable: "IndicatorList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OutcomeData_RequirementList_RequirementItemId",
                        column: x => x.RequirementItemId,
                        principalTable: "RequirementList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    RuleItemId = table.Column<Guid>(nullable: false),
                    ResultId = table.Column<int>(nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RuleData_VlTypeOfResult_ResultId",
                        column: x => x.ResultId,
                        principalTable: "VlTypeOfResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RuleData_RuleList_RuleItemId",
                        column: x => x.RuleItemId,
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
                    ResultId = table.Column<int>(nullable: false),
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
                        name: "FK_AnswerData_VlTypeOfResult_ResultId",
                        column: x => x.ResultId,
                        principalTable: "VlTypeOfResult",
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

            migrationBuilder.CreateIndex(
                name: "IX_AnswerData_AnswerItemId",
                table: "AnswerData",
                column: "AnswerItemId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerData_ImageId",
                table: "AnswerData",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerData_ResultId",
                table: "AnswerData",
                column: "ResultId");

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
                name: "IX_IndicatorTestGroupList_IndicatorItemId",
                table: "IndicatorTestGroupList",
                column: "IndicatorItemId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicatorUserPrerequisite_ValueListUserPrerequisiteId",
                table: "IndicatorUserPrerequisite",
                column: "ValueListUserPrerequisiteId");

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeData_DeclarationTestItemId",
                table: "OutcomeData",
                column: "DeclarationTestItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeData_IndicatorItemId",
                table: "OutcomeData",
                column: "IndicatorItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeData_RequirementItemId",
                table: "OutcomeData",
                column: "RequirementItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeData_ResultId",
                table: "OutcomeData",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_RequirementList_IndicatorItemId",
                table: "RequirementList",
                column: "IndicatorItemId");

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
                name: "IX_RuleData_RuleItemId",
                table: "RuleData",
                column: "RuleItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RuleList_ChapterItemId",
                table: "RuleList",
                column: "ChapterItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RuleList_IndicatorItemId",
                table: "RuleList",
                column: "IndicatorItemId");

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
                name: "IndicatorTestGroupList");

            migrationBuilder.DropTable(
                name: "IndicatorUserPrerequisite");

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
                name: "TestGroupList");

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
                name: "IndicatorList");

            migrationBuilder.DropTable(
                name: "CompanyList");

            migrationBuilder.DropTable(
                name: "UserList");
        }
    }
}
