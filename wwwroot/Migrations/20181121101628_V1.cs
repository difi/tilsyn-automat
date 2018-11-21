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
                    Name = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false)
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
                    TestGroupItemId = table.Column<Guid>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicatorTestGroupList", x => new { x.TestGroupItemId, x.IndicatorItemId });
                    table.ForeignKey(
                        name: "FK_IndicatorTestGroupList_IndicatorList_IndicatorItemId",
                        column: x => x.IndicatorItemId,
                        principalTable: "IndicatorList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndicatorTestGroupList_TestGroupList_TestGroupItemId",
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
                    IndicatorItemId = table.Column<Guid>(nullable: false),
                    ChapterItemId = table.Column<Guid>(nullable: false),
                    StandardItemId = table.Column<Guid>(nullable: false),
                    Order = table.Column<int>(nullable: false),
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
                        name: "FK_RuleList_IndicatorList_IndicatorItemId",
                        column: x => x.IndicatorItemId,
                        principalTable: "IndicatorList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RuleList_RequirementList_RequirementItemId",
                        column: x => x.RequirementItemId,
                        principalTable: "RequirementList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RuleList_StandardList_StandardItemId",
                        column: x => x.StandardItemId,
                        principalTable: "StandardList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeclarationIndicatorGroupList",
                columns: table => new
                {
                    DeclarationItemId = table.Column<Guid>(nullable: false),
                    IndicatorItemId = table.Column<Guid>(nullable: false),
                    IndicatorInTestGroupOrder = table.Column<int>(nullable: false),
                    TestGroupOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeclarationIndicatorGroupList", x => new { x.DeclarationItemId, x.IndicatorItemId });
                    table.ForeignKey(
                        name: "FK_DeclarationIndicatorGroupList_DeclarationList_DeclarationItemId",
                        column: x => x.DeclarationItemId,
                        principalTable: "DeclarationList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeclarationIndicatorGroupList_IndicatorList_IndicatorItemId",
                        column: x => x.IndicatorItemId,
                        principalTable: "IndicatorList",
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

            migrationBuilder.InsertData(
                table: "IndicatorList",
                columns: new[] { "Id", "LastChanged", "Name" },
                values: new object[,]
                {
                    { new Guid("692627b2-53bc-43f2-900d-44a40a21e7e9"), new DateTime(2018, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kundens betjeningsområde" },
                    { new Guid("6b4bf385-9174-4634-bc9e-bfbdab98586e"), new DateTime(2018, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avstand mellom automater" },
                    { new Guid("c52eb3bc-6464-4dc9-b9f3-eb975e2a012c"), new DateTime(2018, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Plassering av skilt" },
                    { new Guid("5b2a0a78-039f-4173-bf9e-1ca0060d1c53"), new DateTime(2018, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Høyde på betalingsterm" }
                });

            migrationBuilder.InsertData(
                table: "RoleList",
                columns: new[] { "Id", "IsAdminRole", "Name" },
                values: new object[,]
                {
                    { new Guid("9e184394-81bb-45cf-a157-dba79a3286d7"), true, "Saksbehandlare" },
                    { new Guid("e7a78cdc-49f9-4e6c-8abd-afcfc08ca5eb"), true, "Admin" },
                    { new Guid("5ae2ea91-e0a2-48e7-a77b-c1ede6b973e1"), false, "Virksomhet" }
                });

            migrationBuilder.InsertData(
                table: "StandardList",
                columns: new[] { "Id", "Name", "Standard" },
                values: new object[] { new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2"), "Identification Card Systems - Guidance on design for accessible card-activated devices", "CEN/TS 15291:2006" });

            migrationBuilder.InsertData(
                table: "TestGroupList",
                columns: new[] { "Id", "Name", "Order" },
                values: new object[,]
                {
                    { new Guid("9aae6bc9-4b60-405c-81a7-ec142d8c1ca6"), "Betjeningshøyde", 3 },
                    { new Guid("aec1869a-30f8-403c-b909-df115173f009"), "Betjeningsområde", 1 },
                    { new Guid("b6c22ac9-d775-4dfd-ac8e-b4ca565ea3fb"), "Skilt", 2 }
                });

            migrationBuilder.InsertData(
                table: "UserList",
                columns: new[] { "Id", "CountryCode", "Created", "Email", "LastOnline", "Name", "Phone", "SocialSecurityNumber", "Title", "Token" },
                values: new object[,]
                {
                    { new Guid("27e6f983-d5c8-4a18-a7f9-977c410e17f0"), "0047", new DateTime(2011, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "martin@difi.no", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martin Swartling", "912345678", "12089400420", "Avdelingssjef", "fqgADdXVzSgBdjIGl1KloQWjN-qGPN66S1h8EiBtg3g=" },
                    { new Guid("3812f52e-55a0-48d0-9a9c-54147c2fe90c"), "0047", new DateTime(2011, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "thea@difi.no", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thea Sneve", "712345678", "12089400269", "Handläggare", "72og6NuGTB95NqnWN4Mj2IF_pVgodGv_qZ1F8c8u77c=" }
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
                    { 1, "Betalingsterminal" },
                    { 2, "Billettautomat" },
                    { 3, "Selvbetjent kasse" }
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
                    { 23, "Verifone Yomani XR" },
                    { 14, "Ingenico iWL252" },
                    { 19, "Verifone VX 690" },
                    { 13, "Ingenico iWL251" },
                    { 4, "Ingenico iCT250r" },
                    { 11, "Ingenico iWL250B " },
                    { 10, "Ingenico iWL250" },
                    { 9, "Ingenico iUP" },
                    { 8, "Ingenico isMP4" },
                    { 7, "Ingenico iSMP" },
                    { 6, "Ingenico iSelf" },
                    { 5, "Ingenico iPP350" },
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
                columns: new[] { "Id", "ChapterHeading", "ChapterNumber", "StandardItemId" },
                values: new object[,]
                {
                    { new Guid("731a0f5c-f586-471f-b32c-ceb8027f735a"), "User operating space", "D.6.2", new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2") },
                    { new Guid("b80b9b15-8f0e-4702-b7d9-95cafa68f9fb"), "Overhead obstructions", "D.5.5", new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2") },
                    { new Guid("5f5abe28-1a74-4242-acc8-4b881ee4973a"), "Access from user operating area", "D.6.6", new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2") },
                    { new Guid("75468cd0-478b-45e9-8a8e-51b0e574fb3b"), "Location signs and visual indications", "5.2", new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2") },
                    { new Guid("6c0f12f8-0a91-4849-b18f-2af735017fcd"), "Layout of operating features", "6.3.1", new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2") }
                });

            migrationBuilder.InsertData(
                table: "IndicatorTestGroupList",
                columns: new[] { "TestGroupItemId", "IndicatorItemId", "Order" },
                values: new object[,]
                {
                    { new Guid("aec1869a-30f8-403c-b909-df115173f009"), new Guid("692627b2-53bc-43f2-900d-44a40a21e7e9"), 1 },
                    { new Guid("aec1869a-30f8-403c-b909-df115173f009"), new Guid("6b4bf385-9174-4634-bc9e-bfbdab98586e"), 2 },
                    { new Guid("b6c22ac9-d775-4dfd-ac8e-b4ca565ea3fb"), new Guid("c52eb3bc-6464-4dc9-b9f3-eb975e2a012c"), 1 },
                    { new Guid("9aae6bc9-4b60-405c-81a7-ec142d8c1ca6"), new Guid("5b2a0a78-039f-4173-bf9e-1ca0060d1c53"), 1 }
                });

            migrationBuilder.InsertData(
                table: "RequirementList",
                columns: new[] { "Id", "Description", "IndicatorItemId" },
                values: new object[,]
                {
                    { new Guid("875e76b5-c926-43a0-8738-c4f41c7a0b8b"), "Krav 3.1 Betjeningsområdet foran betalingsterminalen skal være minst 150 x 150 centimeter. Det skal ikke være hindringer i betjeningsområdet.", new Guid("692627b2-53bc-43f2-900d-44a40a21e7e9") },
                    { new Guid("c65786bb-1b93-4153-b88c-935cc2a7ab60"), "Krav 3.5 Dersom to eller flere automater står ved siden av hverandre, skal det være minst 150 centimeter fra midten av automaten til midten av neste automat.", new Guid("6b4bf385-9174-4634-bc9e-bfbdab98586e") },
                    { new Guid("aebd662d-9dd5-4a27-88d5-19d6c5e12e5a"), "Krav 1.3 Skilt skal plasseres over betalingsterminalen.", new Guid("c52eb3bc-6464-4dc9-b9f3-eb975e2a012c") },
                    { new Guid("e503322b-ed77-4b69-adc4-eca19b6eb97d"), "Krav 4.2: Høyden på betjeningskomponenter som skjerm og tastatur skal være mellom 75 centimeter og 130 centimeter over gulvet.", new Guid("5b2a0a78-039f-4173-bf9e-1ca0060d1c53") }
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
                columns: new[] { "Id", "ChapterItemId", "HelpText", "Illustration", "IndicatorItemId", "Order", "RequirementItemId", "StandardItemId", "ToolsNeed" },
                values: new object[,]
                {
                    { new Guid("eb160c6c-3a9e-4dff-93df-577d9eab4e09"), new Guid("731a0f5c-f586-471f-b32c-ceb8027f735a"), "", null, new Guid("692627b2-53bc-43f2-900d-44a40a21e7e9"), 1, new Guid("875e76b5-c926-43a0-8738-c4f41c7a0b8b"), new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2"), "Ingen" },
                    { new Guid("b64cac7e-6525-49e8-9112-0238e1588ed8"), new Guid("b80b9b15-8f0e-4702-b7d9-95cafa68f9fb"), "", null, new Guid("692627b2-53bc-43f2-900d-44a40a21e7e9"), 2, new Guid("875e76b5-c926-43a0-8738-c4f41c7a0b8b"), new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2"), "Ingen" },
                    { new Guid("0d6c763e-e0f6-4049-adeb-ae9429262b57"), new Guid("5f5abe28-1a74-4242-acc8-4b881ee4973a"), "", null, new Guid("6b4bf385-9174-4634-bc9e-bfbdab98586e"), 1, new Guid("c65786bb-1b93-4153-b88c-935cc2a7ab60"), new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2"), "Ingen" },
                    { new Guid("832e0843-cab3-4dbc-9799-974e283fcc0b"), new Guid("75468cd0-478b-45e9-8a8e-51b0e574fb3b"), "Krav: Skilt skal plasseres over betalingsterminalen.<br /><br />Det skal være et skilt som er synlig på avstand utenfor kundens betjeningsområde. Formålet er at brukeren kan finne fram til betalingsterminalen.<br /><br />Skiltet skal være plassert over området der kunden skal betale varene sine. Det kan for eksempel være over kassen eller disken der betalingsterminalen er plassert.<br /><br />Eksempler på tekst på skilt er<br />- Kasse<br />- Betal her<br />- Kort og kontant<br />- Nummer på kasse<br />", null, new Guid("c52eb3bc-6464-4dc9-b9f3-eb975e2a012c"), 1, new Guid("aebd662d-9dd5-4a27-88d5-19d6c5e12e5a"), new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2"), "Ingen" },
                    { new Guid("5b3af04b-f6c6-4425-a22f-c2e7479839a5"), new Guid("6c0f12f8-0a91-4849-b18f-2af735017fcd"), null, null, new Guid("5b2a0a78-039f-4173-bf9e-1ca0060d1c53"), 1, new Guid("e503322b-ed77-4b69-adc4-eca19b6eb97d"), new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2"), "Ingen" }
                });

            migrationBuilder.InsertData(
                table: "AnswerList",
                columns: new[] { "Id", "Bool", "MaxInt", "MinInt", "Order", "Question", "RuleItemId", "TypeOfAnswerId", "ViewIfOtherFaildId", "ViewIfOtherFailed" },
                values: new object[,]
                {
                    { new Guid("02d2db89-3717-48e1-883e-8e526bf6c727"), false, 0, 0, 1, "Finnes det hindringer i kundens betjeningsområde?", new Guid("eb160c6c-3a9e-4dff-93df-577d9eab4e09"), 2, new Guid("00000000-0000-0000-0000-000000000000"), false },
                    { new Guid("6912d4a0-b73b-4ecc-9fa8-49e1fd356635"), false, 0, 0, 2, "Ta bilde", new Guid("eb160c6c-3a9e-4dff-93df-577d9eab4e09"), 4, new Guid("00000000-0000-0000-0000-000000000000"), false },
                    { new Guid("d7b40e3c-e7fa-44e5-b44f-750759c971cc"), false, 0, 0, 3, "Beskriv hindringene i kundens betjeningsområde.", new Guid("eb160c6c-3a9e-4dff-93df-577d9eab4e09"), 1, new Guid("02d2db89-3717-48e1-883e-8e526bf6c727"), true },
                    { new Guid("a1964762-5c8f-40bb-a22d-c907149079d4"), false, 0, 0, 1, "Henger det gjenstander over kundens betjeningsområde?", new Guid("b64cac7e-6525-49e8-9112-0238e1588ed8"), 2, new Guid("00000000-0000-0000-0000-000000000000"), false },
                    { new Guid("8a12d92b-8a6a-44e7-9517-74331a4c2483"), false, 0, 0, 2, "Ta bilde", new Guid("b64cac7e-6525-49e8-9112-0238e1588ed8"), 4, new Guid("00000000-0000-0000-0000-000000000000"), false },
                    { new Guid("bf459d05-702d-47d7-a5b7-19f8b3fb67c9"), false, -1, 220, 3, "Hvor mange cm over gulvet henger den laveste gjenstanden i kundens betjeningsområde?", new Guid("b64cac7e-6525-49e8-9112-0238e1588ed8"), 3, new Guid("a1964762-5c8f-40bb-a22d-c907149079d4"), true },
                    { new Guid("202d20e0-61df-4a7c-8287-104e3b439f64"), false, 0, 0, 1, "Står betalingsterminalen ved siden av en annen betalingsterminal, på rett linje?", new Guid("0d6c763e-e0f6-4049-adeb-ae9429262b57"), 2, new Guid("00000000-0000-0000-0000-000000000000"), false },
                    { new Guid("13d6d530-e533-4510-9a66-8b862899dbdf"), false, 0, 0, 2, "Ta bilde", new Guid("0d6c763e-e0f6-4049-adeb-ae9429262b57"), 4, new Guid("00000000-0000-0000-0000-000000000000"), false },
                    { new Guid("89fd2205-1047-403d-a5bd-f70a1de2f247"), false, -1, 150, 3, "Hvor mange cm er det mellom betalingsterminalene?", new Guid("0d6c763e-e0f6-4049-adeb-ae9429262b57"), 3, new Guid("202d20e0-61df-4a7c-8287-104e3b439f64"), true },
                    { new Guid("d8611e84-0f00-4d75-bcab-cbf127fb68b5"), true, 0, 0, 1, "Finnes det et skilt som viser hvor kunden skal betale varene sine?", new Guid("832e0843-cab3-4dbc-9799-974e283fcc0b"), 2, new Guid("00000000-0000-0000-0000-000000000000"), false },
                    { new Guid("c4870935-ee11-4557-a9c3-aca678c17565"), false, 0, 0, 2, "Ta bilde", new Guid("832e0843-cab3-4dbc-9799-974e283fcc0b"), 4, new Guid("00000000-0000-0000-0000-000000000000"), false },
                    { new Guid("9a51cc68-857e-4822-ac81-0ec3ebe7bf43"), true, 0, 0, 3, "Er skiltet plassert over området der kunden skal betale varene sine?", new Guid("832e0843-cab3-4dbc-9799-974e283fcc0b"), 2, new Guid("d8611e84-0f00-4d75-bcab-cbf127fb68b5"), true },
                    { new Guid("f69c1e45-99d8-4293-a242-c5ed9e126e99"), true, 0, 0, 4, "Er skiltet synlig på avstand utenfor kundens betjeningsområde?", new Guid("832e0843-cab3-4dbc-9799-974e283fcc0b"), 2, new Guid("d8611e84-0f00-4d75-bcab-cbf127fb68b5"), true },
                    { new Guid("f98f67e5-cf6a-4afe-8998-3132640f9d70"), false, 130, 75, 1, "Hvor mange cm er det fra gulvet og opp til betalingsterminalen?", new Guid("5b3af04b-f6c6-4425-a22f-c2e7479839a5"), 3, new Guid("00000000-0000-0000-0000-000000000000"), false },
                    { new Guid("438787f3-b33b-489c-b5a8-2f046a634dea"), false, 0, 0, 2, "Ta bilde", new Guid("5b3af04b-f6c6-4425-a22f-c2e7479839a5"), 4, new Guid("00000000-0000-0000-0000-000000000000"), false }
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
                name: "IX_DeclarationIndicatorGroupList_IndicatorItemId",
                table: "DeclarationIndicatorGroupList",
                column: "IndicatorItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationList_CompanyItemId",
                table: "DeclarationList",
                column: "CompanyItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationList_UserItemId",
                table: "DeclarationList",
                column: "UserItemId");

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
                column: "IndicatorItemId",
                unique: true);

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
                name: "DeclarationIndicatorGroupList");

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
