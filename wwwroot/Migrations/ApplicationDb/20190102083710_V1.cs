using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
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
                    Code = table.Column<string>(nullable: true),
                    ExternalId = table.Column<string>(nullable: true),
                    CorporateIdentityNumber = table.Column<long>(nullable: true),
                    OwenerCorporateIdentityNumber = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    CustomName = table.Column<string>(nullable: true),
                    MailingAddressStreet = table.Column<string>(nullable: true),
                    MailingAddressZip = table.Column<string>(nullable: true),
                    MailingAddressCity = table.Column<string>(nullable: true),
                    LocationAddressStreet = table.Column<string>(nullable: true),
                    LocationAddressZip = table.Column<string>(nullable: true),
                    LocationAddressCity = table.Column<string>(nullable: true),
                    CustomLocationAddressStreet = table.Column<string>(nullable: true),
                    CustomLocationAddressZip = table.Column<string>(nullable: true),
                    CustomLocationAddressCity = table.Column<string>(nullable: true),
                    BusinessAddressStreet = table.Column<string>(nullable: true),
                    BusinessAddressZip = table.Column<string>(nullable: true),
                    BusinessAddressCity = table.Column<string>(nullable: true),
                    CustomBusinessAddressStreet = table.Column<string>(nullable: true),
                    CustomBusinessAddressZip = table.Column<string>(nullable: true),
                    CustomBusinessAddressCity = table.Column<string>(nullable: true),
                    IndustryGroupCode = table.Column<string>(nullable: true),
                    IndustryGroupDescription = table.Column<string>(nullable: true),
                    IndustryGroupAggregated = table.Column<string>(nullable: true),
                    InstitutionalSectorCode = table.Column<string>(nullable: true),
                    InstitutionalSectorDescription = table.Column<string>(nullable: true)
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
                    Blob = table.Column<string>(nullable: true),
                    Uuid = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Container = table.Column<string>(nullable: true)
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
                name: "LanguageList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequirementList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IndicatorItemId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequirementList", x => x.Id);
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
                    SocialSecurityNumber = table.Column<long>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PhoneCountryCode = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
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
                name: "VlPurposeOfTest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlPurposeOfTest", x => x.Id);
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
                name: "VlTypeOfStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true),
                    TextAdmin = table.Column<string>(nullable: true),
                    TextCompany = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlTypeOfStatus", x => x.Id);
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
                name: "IndicatorOutcomeList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    ResultString1 = table.Column<string>(nullable: true),
                    ResultString2 = table.Column<string>(nullable: true),
                    IndicatorItemId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicatorOutcomeList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndicatorOutcomeList_IndicatorList_IndicatorItemId",
                        column: x => x.IndicatorItemId,
                        principalTable: "IndicatorList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequirementLanguageList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RequirementItemId = table.Column<Guid>(nullable: false),
                    LanguageItemId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequirementLanguageList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequirementLanguageList_LanguageList_LanguageItemId",
                        column: x => x.LanguageItemId,
                        principalTable: "LanguageList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequirementLanguageList_RequirementList_RequirementItemId",
                        column: x => x.RequirementItemId,
                        principalTable: "RequirementList",
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
                name: "TestGroupLanguageList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TestGroupItemId = table.Column<Guid>(nullable: false),
                    LanguageItemId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestGroupLanguageList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestGroupLanguageList_LanguageList_LanguageItemId",
                        column: x => x.LanguageItemId,
                        principalTable: "LanguageList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestGroupLanguageList_TestGroupList_TestGroupItemId",
                        column: x => x.TestGroupItemId,
                        principalTable: "TestGroupList",
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
                name: "DeclarationList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyItemId = table.Column<Guid>(nullable: false),
                    UserItemId = table.Column<Guid>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CaseNumber = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DeadlineDate = table.Column<DateTime>(nullable: false),
                    SentInDate = table.Column<DateTime>(nullable: false)
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
                        name: "FK_DeclarationList_VlTypeOfStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "VlTypeOfStatus",
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
                name: "IndicatorOutcomeLanguageList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IndicatorOutcomeItemId = table.Column<Guid>(nullable: false),
                    LanguageItemId = table.Column<Guid>(nullable: false),
                    OutcomeText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicatorOutcomeLanguageList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndicatorOutcomeLanguageList_IndicatorOutcomeList_IndicatorOutcomeItemId",
                        column: x => x.IndicatorOutcomeItemId,
                        principalTable: "IndicatorOutcomeList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndicatorOutcomeLanguageList_LanguageList_LanguageItemId",
                        column: x => x.LanguageItemId,
                        principalTable: "LanguageList",
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
                    Order = table.Column<int>(nullable: false)
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
                        onDelete: ReferentialAction.Cascade);
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
                    TestGroupItemId = table.Column<Guid>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_DeclarationIndicatorGroupList_TestGroupList_TestGroupItemId",
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
                    StatusCount = table.Column<int>(nullable: false),
                    PurposeOfTestId = table.Column<int>(nullable: false),
                    HaveMachine = table.Column<bool>(nullable: false),
                    TypeOfMachineId = table.Column<int>(nullable: true),
                    TypeOfTestId = table.Column<int>(nullable: true),
                    SupplierAndVersionId = table.Column<int>(nullable: true),
                    SupplierAndVersionOther = table.Column<string>(nullable: true),
                    DescriptionInText = table.Column<string>(nullable: true),
                    Image1Id = table.Column<Guid>(nullable: true),
                    Image2Id = table.Column<Guid>(nullable: true),
                    FinishedStatusId = table.Column<int>(nullable: true)
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
                        name: "FK_DeclarationTestItem_VlPurposeOfTest_PurposeOfTestId",
                        column: x => x.PurposeOfTestId,
                        principalTable: "VlPurposeOfTest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    LinkedParentFailedId = table.Column<Guid>(nullable: false),
                    LinkedParentCorrectId = table.Column<Guid>(nullable: false),
                    AlwaysVisible = table.Column<bool>(nullable: false),
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
                name: "RuleLanguageList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RuleItemId = table.Column<Guid>(nullable: false),
                    LanguageItemId = table.Column<Guid>(nullable: false),
                    HelpText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleLanguageList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RuleLanguageList_LanguageList_LanguageItemId",
                        column: x => x.LanguageItemId,
                        principalTable: "LanguageList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RuleLanguageList_RuleList_RuleItemId",
                        column: x => x.RuleItemId,
                        principalTable: "RuleList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutcomeData",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IndicatorItemId = table.Column<Guid>(nullable: false),
                    IndicatorOutcomeItemId = table.Column<Guid>(nullable: true),
                    DeclarationTestItemId = table.Column<Guid>(nullable: false),
                    ResultId = table.Column<int>(nullable: false),
                    AllDone = table.Column<bool>(nullable: false),
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
                        name: "FK_OutcomeData_IndicatorOutcomeList_IndicatorOutcomeItemId",
                        column: x => x.IndicatorOutcomeItemId,
                        principalTable: "IndicatorOutcomeList",
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
                name: "AnswerLanguageList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AnswerItemId = table.Column<Guid>(nullable: false),
                    LanguageItemId = table.Column<Guid>(nullable: false),
                    Question = table.Column<string>(nullable: true),
                    BoolTrueText = table.Column<string>(nullable: true),
                    BoolFalseText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerLanguageList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerLanguageList_AnswerList_AnswerItemId",
                        column: x => x.AnswerItemId,
                        principalTable: "AnswerList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnswerLanguageList_LanguageList_LanguageItemId",
                        column: x => x.LanguageItemId,
                        principalTable: "LanguageList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    ImageId = table.Column<Guid>(nullable: true),
                    Bool = table.Column<bool>(nullable: true),
                    String = table.Column<string>(nullable: true),
                    Int = table.Column<int>(nullable: true)
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
                table: "LanguageList",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "nb-NO" },
                    { new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "nn-NO" }
                });

            migrationBuilder.InsertData(
                table: "RequirementList",
                columns: new[] { "Id", "IndicatorItemId" },
                values: new object[,]
                {
                    { new Guid("875e76b5-c926-43a0-8738-c4f41c7a0b8b"), new Guid("692627b2-53bc-43f2-900d-44a40a21e7e9") },
                    { new Guid("c65786bb-1b93-4153-b88c-935cc2a7ab60"), new Guid("6b4bf385-9174-4634-bc9e-bfbdab98586e") },
                    { new Guid("aebd662d-9dd5-4a27-88d5-19d6c5e12e5a"), new Guid("c52eb3bc-6464-4dc9-b9f3-eb975e2a012c") },
                    { new Guid("e503322b-ed77-4b69-adc4-eca19b6eb97d"), new Guid("5b2a0a78-039f-4173-bf9e-1ca0060d1c53") }
                });

            migrationBuilder.InsertData(
                table: "RoleList",
                columns: new[] { "Id", "IsAdminRole", "Name" },
                values: new object[,]
                {
                    { new Guid("5ae2ea91-e0a2-48e7-a77b-c1ede6b973e1"), false, "Virksomhet" },
                    { new Guid("9e184394-81bb-45cf-a157-dba79a3286d7"), true, "Saksbehandler" },
                    { new Guid("e7a78cdc-49f9-4e6c-8abd-afcfc08ca5eb"), true, "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "StandardList",
                columns: new[] { "Id", "Name", "Standard" },
                values: new object[] { new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2"), "Identification Card Systems - Guidance on design for accessible card-activated devices", "CEN/TS 15291:2006" });

            migrationBuilder.InsertData(
                table: "TestGroupList",
                columns: new[] { "Id", "Order" },
                values: new object[,]
                {
                    { new Guid("aec1869a-30f8-403c-b909-df115173f009"), 1 },
                    { new Guid("b6c22ac9-d775-4dfd-ac8e-b4ca565ea3fb"), 2 },
                    { new Guid("9aae6bc9-4b60-405c-81a7-ec142d8c1ca6"), 3 }
                });

            migrationBuilder.InsertData(
                table: "UserList",
                columns: new[] { "Id", "Created", "Email", "LastOnline", "Name", "Phone", "PhoneCountryCode", "SocialSecurityNumber", "Title", "Token" },
                values: new object[,]
                {
                    { new Guid("3812f52e-55a0-48d0-9a9c-54147c2fe90c"), new DateTime(2018, 12, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "thea@difi.no", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thea Sneve", "712345678", "0047", 12089400269L, "Handläggare", "72og6NuGTB95NqnWN4Mj2IF_pVgodGv_qZ1F8c8u77c=" },
                    { new Guid("27e6f983-d5c8-4a18-a7f9-977c410e17f0"), new DateTime(2018, 12, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "martin@difi.no", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martin Swartling", "912345678", "0047", 12089400420L, "Avdelingssjef", "fqgADdXVzSgBdjIGl1KloQWjN-qGPN66S1h8EiBtg3g=" }
                });

            migrationBuilder.InsertData(
                table: "VlFinishedStatusList",
                columns: new[] { "Id", "Text" },
                values: new object[,]
                {
                    { 3, "Merknad" },
                    { 2, "Avvik" },
                    { 1, "Inget" }
                });

            migrationBuilder.InsertData(
                table: "VlPurposeOfTest",
                columns: new[] { "Id", "Text" },
                values: new object[,]
                {
                    { 1, "Pilotmåling" },
                    { 2, "Tilsyn" },
                    { 3, "Statusmåling" }
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
                table: "VlTypeOfStatus",
                columns: new[] { "Id", "Text", "TextAdmin", "TextCompany" },
                values: new object[,]
                {
                    { 7, "Avlyst", "Avlyst", "Avlyst" },
                    { 6, "Avsluttet", "Avsluttet", "Fullført" },
                    { 5, "Åpen for korreksjon", "Pågår", "Åpen for korreksjon" },
                    { 4, "Fullført", "Fullført", "Fullført" },
                    { 3, "Påbegynt", "Pågår", "Påbegynt" },
                    { 2, "Varslet", "Pågår", "Ikke påbegynt" },
                    { 1, "Opprettet", "Opprettet", "Ikke påbegynt" }
                });

            migrationBuilder.InsertData(
                table: "VlTypeOfSupplierAndVersionList",
                columns: new[] { "Id", "Text" },
                values: new object[,]
                {
                    { 99999, "Annet" },
                    { 2300, "Verifone Yomani XR" },
                    { 2200, "Verifone Xenteo ECO" },
                    { 2100, "Verifone VX 820 Duet" },
                    { 2000, "Verifone VX 820" },
                    { 1900, "Verifone VX 690" },
                    { 1800, "Verifone VX 680" },
                    { 1600, "SumUp Air" },
                    { 1500, "iZettle Reader" },
                    { 1400, "Ingenico iWL252" },
                    { 1300, "Ingenico iWL251" },
                    { 1200, "Ingenico iWL250G" },
                    { 1700, "Verifone VX 520 C" },
                    { 1000, "Ingenico iWL250" },
                    { 900, "Ingenico iUP" },
                    { 800, "Ingenico isMP4" },
                    { 700, "Ingenico iSMP" },
                    { 600, "Ingenico iSelf" },
                    { 500, "Ingenico iPP350" },
                    { 400, "Ingenico iCT250r" },
                    { 300, "Ingenico iCT250E" },
                    { 200, "Ingenico iCT250" },
                    { 100, "Vet ikke" },
                    { 1, "Velg betalingsterminal" },
                    { 1100, "Ingenico iWL250B " }
                });

            migrationBuilder.InsertData(
                table: "VlTypeOfTestList",
                columns: new[] { "Id", "Text" },
                values: new object[,]
                {
                    { 3, "Applikasjon" },
                    { 1, "Automat" },
                    { 2, "Webside" }
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
                    { new Guid("b80b9b15-8f0e-4702-b7d9-95cafa68f9fb"), "Overhead obstructions", "D.5.5", new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2") },
                    { new Guid("6c0f12f8-0a91-4849-b18f-2af735017fcd"), "Layout of operating features", "6.3.1", new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2") },
                    { new Guid("75468cd0-478b-45e9-8a8e-51b0e574fb3b"), "Location signs and visual indications", "5.2", new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2") },
                    { new Guid("5f5abe28-1a74-4242-acc8-4b881ee4973a"), "Access from user operating area", "D.6.6", new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2") },
                    { new Guid("731a0f5c-f586-471f-b32c-ceb8027f735a"), "User operating space", "D.6.2", new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2") }
                });

            migrationBuilder.InsertData(
                table: "IndicatorOutcomeList",
                columns: new[] { "Id", "IndicatorItemId", "Order", "ResultString1", "ResultString2" },
                values: new object[,]
                {
                    { new Guid("8d69236d-8940-417e-aab6-d41d74539ef2"), new Guid("5b2a0a78-039f-4173-bf9e-1ca0060d1c53"), 2, "2,2", null },
                    { new Guid("043ccfc1-ff23-43f3-a130-3d399638f24f"), new Guid("5b2a0a78-039f-4173-bf9e-1ca0060d1c53"), 1, "1", "1,1" },
                    { new Guid("54d4cb13-a006-4a8b-9fdb-89a01a9b9040"), new Guid("c52eb3bc-6464-4dc9-b9f3-eb975e2a012c"), 5, "2", null },
                    { new Guid("402f1644-36d0-4ad5-853b-aee2f4bfbf75"), new Guid("c52eb3bc-6464-4dc9-b9f3-eb975e2a012c"), 4, "1,2,2", null },
                    { new Guid("d0ab6b63-c6c9-4a4f-81b0-5be0a4497278"), new Guid("c52eb3bc-6464-4dc9-b9f3-eb975e2a012c"), 3, "1,2,1", null },
                    { new Guid("0025bb09-6dfe-4069-ae6b-27cb28ba8300"), new Guid("692627b2-53bc-43f2-900d-44a40a21e7e9"), 1, "1,1", null },
                    { new Guid("e5a123b7-f2d4-4d25-b6d7-544c3b7c63b8"), new Guid("c52eb3bc-6464-4dc9-b9f3-eb975e2a012c"), 1, "1,1,1", null },
                    { new Guid("c11dcd56-0aaa-4253-8565-34132b640f15"), new Guid("6b4bf385-9174-4634-bc9e-bfbdab98586e"), 3, "1", null },
                    { new Guid("ae869b09-090d-459b-827c-4d61a1578478"), new Guid("6b4bf385-9174-4634-bc9e-bfbdab98586e"), 2, "2,2,2", null },
                    { new Guid("30f07a36-ff0b-4692-b7bf-0f2d8dee923a"), new Guid("6b4bf385-9174-4634-bc9e-bfbdab98586e"), 1, "1,1", "1,1,1" },
                    { new Guid("6cd1b621-12e6-4a03-bd6e-a7c8b39de251"), new Guid("692627b2-53bc-43f2-900d-44a40a21e7e9"), 6, "2,2,2,2", null },
                    { new Guid("4edceffe-eb77-4ca0-a498-24be5372d333"), new Guid("692627b2-53bc-43f2-900d-44a40a21e7e9"), 5, "2,1,1", "2,1,1,1" },
                    { new Guid("a9b2bb20-7240-4a93-ba1a-ae270e8679f1"), new Guid("692627b2-53bc-43f2-900d-44a40a21e7e9"), 4, "2,1", null },
                    { new Guid("d18a7bce-556c-45cc-87d7-c765261166d5"), new Guid("692627b2-53bc-43f2-900d-44a40a21e7e9"), 3, "1,2,2,2", null },
                    { new Guid("d438e931-f57c-4a5c-bb5c-3e3a66824827"), new Guid("692627b2-53bc-43f2-900d-44a40a21e7e9"), 2, "1,1,1", "1,1,1,1" },
                    { new Guid("85d5b052-1f22-449d-b0a3-2883593ace54"), new Guid("c52eb3bc-6464-4dc9-b9f3-eb975e2a012c"), 2, "1,1,2", null }
                });

            migrationBuilder.InsertData(
                table: "IndicatorTestGroupList",
                columns: new[] { "TestGroupItemId", "IndicatorItemId", "Order" },
                values: new object[,]
                {
                    { new Guid("9aae6bc9-4b60-405c-81a7-ec142d8c1ca6"), new Guid("5b2a0a78-039f-4173-bf9e-1ca0060d1c53"), 1 },
                    { new Guid("b6c22ac9-d775-4dfd-ac8e-b4ca565ea3fb"), new Guid("c52eb3bc-6464-4dc9-b9f3-eb975e2a012c"), 1 },
                    { new Guid("aec1869a-30f8-403c-b909-df115173f009"), new Guid("6b4bf385-9174-4634-bc9e-bfbdab98586e"), 2 },
                    { new Guid("aec1869a-30f8-403c-b909-df115173f009"), new Guid("692627b2-53bc-43f2-900d-44a40a21e7e9"), 1 }
                });

            migrationBuilder.InsertData(
                table: "RequirementLanguageList",
                columns: new[] { "Id", "Description", "LanguageItemId", "RequirementItemId" },
                values: new object[,]
                {
                    { new Guid("0290478b-5818-437b-9097-7fbeaf3433a2"), "Krav 3.1 Betjeningsområdet foran betalingsterminalen skal være minst 150 x 150 centimeter. Det skal ikke være hindringer i betjeningsområdet.", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), new Guid("875e76b5-c926-43a0-8738-c4f41c7a0b8b") },
                    { new Guid("b9247a56-97d9-4aeb-ad1d-224c1d410eaf"), "Krav 3.5 Dersom to eller flere automater står ved siden av hverandre, skal det være minst 150 centimeter fra midten av automaten til midten av neste automat.", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), new Guid("c65786bb-1b93-4153-b88c-935cc2a7ab60") },
                    { new Guid("5c873d77-9c1e-4c6f-82b6-83fdd77e892a"), "Krav 1.3 Skilt skal plasseres over betalingsterminalen.", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), new Guid("aebd662d-9dd5-4a27-88d5-19d6c5e12e5a") },
                    { new Guid("5ec84619-9cd3-4ee8-adad-9e55d04482d7"), "Krav 4.2: Høyden på betjeningskomponenter som skjerm og tastatur skal være mellom 75 centimeter og 130 centimeter over gulvet.", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), new Guid("e503322b-ed77-4b69-adc4-eca19b6eb97d") }
                });

            migrationBuilder.InsertData(
                table: "TestGroupLanguageList",
                columns: new[] { "Id", "LanguageItemId", "Name", "TestGroupItemId" },
                values: new object[,]
                {
                    { new Guid("d7f6c8de-9435-4c39-bd19-9642eca25e65"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Betjeningsområde", new Guid("aec1869a-30f8-403c-b909-df115173f009") },
                    { new Guid("2b1d1f9a-1c00-43f5-b8f1-f598d146bc77"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Skilt", new Guid("b6c22ac9-d775-4dfd-ac8e-b4ca565ea3fb") },
                    { new Guid("3b00207c-83a8-49a8-a65e-503b63cc73b1"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Betjeningshøyde", new Guid("9aae6bc9-4b60-405c-81a7-ec142d8c1ca6") }
                });

            migrationBuilder.InsertData(
                table: "UserRoleList",
                columns: new[] { "UserItemId", "RoleItemId" },
                values: new object[,]
                {
                    { new Guid("27e6f983-d5c8-4a18-a7f9-977c410e17f0"), new Guid("9e184394-81bb-45cf-a157-dba79a3286d7") },
                    { new Guid("27e6f983-d5c8-4a18-a7f9-977c410e17f0"), new Guid("e7a78cdc-49f9-4e6c-8abd-afcfc08ca5eb") },
                    { new Guid("3812f52e-55a0-48d0-9a9c-54147c2fe90c"), new Guid("9e184394-81bb-45cf-a157-dba79a3286d7") }
                });

            migrationBuilder.InsertData(
                table: "IndicatorOutcomeLanguageList",
                columns: new[] { "Id", "IndicatorOutcomeItemId", "LanguageItemId", "OutcomeText" },
                values: new object[,]
                {
                    { new Guid("2e230687-302b-4da7-ae95-00d615f1fc2a"), new Guid("0025bb09-6dfe-4069-ae6b-27cb28ba8300"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Kundens betjeningsområde foran betalingsterminalen er uten hindringer. Det henger ikke gjenstander over kundens betjeningsområde." },
                    { new Guid("840d94f6-0c3c-47d8-bcfd-7d4a148eec06"), new Guid("8d69236d-8940-417e-aab6-d41d74539ef2"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Betalingsterminalen er ikke mellom 75 og 130 cm over gulvet." },
                    { new Guid("c80f2711-1229-48d5-a15d-eb790d00f7f2"), new Guid("043ccfc1-ff23-43f3-a130-3d399638f24f"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Betalingsterminalen er mellom 75 og 130 cm over gulvet." },
                    { new Guid("f6d58cdf-cafa-4892-a847-1a70fa2dd4e2"), new Guid("54d4cb13-a006-4a8b-9fdb-89a01a9b9040"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Det finnes ikke et skilt som viser hvor kunden skal betale." },
                    { new Guid("2595a239-44fc-4837-9aee-c6dd9f46d71c"), new Guid("402f1644-36d0-4ad5-853b-aee2f4bfbf75"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Skilt til området der kunden skal betale varene sine, er ikke synlig på avstand utenfor kundens betjeningsområde. Skilt er ikke plassert over området der kunden skal betale varene sine." },
                    { new Guid("8b2343e2-a121-4247-8b19-318d0d42984c"), new Guid("d0ab6b63-c6c9-4a4f-81b0-5be0a4497278"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Skilt er ikke plassert over området der kunden skal betale varene sine." },
                    { new Guid("20308d8f-c099-436a-bf7b-f91a2fac0376"), new Guid("e5a123b7-f2d4-4d25-b6d7-544c3b7c63b8"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Det finnes et skilt som viser hvor kunden skal betale varene sine. Skiltet er synlig på avstand utenfor kundens betjeningsområde og plassert over området der kunden skal betale varene sine." },
                    { new Guid("8bb7a824-82ca-4fbc-bb33-151a38b0a054"), new Guid("c11dcd56-0aaa-4253-8565-34132b640f15"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Betalingsterminalen står ikke på rett linje ved siden av en annen betalingsterminal." },
                    { new Guid("1b27cdd4-a34b-486c-a5ff-684afa4579e7"), new Guid("85d5b052-1f22-449d-b0a3-2883593ace54"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Skilt til området der kunden skal betale varene sine, er ikke synlig på avstand utenfor kundens betjeningsområde." },
                    { new Guid("541fde0f-502e-4e6f-82f1-aca378d76b60"), new Guid("30f07a36-ff0b-4692-b7bf-0f2d8dee923a"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Det er minst 150 cm mellom betalingsterminalene." },
                    { new Guid("174f9a3a-a5b9-4e00-8fcb-f3d9b8fd215e"), new Guid("6cd1b621-12e6-4a03-bd6e-a7c8b39de251"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Det finnes hindringer i kundens betjeningsområde foran betalingsterminalen og gjenstander som henger over kundens betjeningsområde, er lavere enn 220 cm over gulvet." },
                    { new Guid("bace523f-8d4c-4c2f-80e7-b87e2a4fb330"), new Guid("4edceffe-eb77-4ca0-a498-24be5372d333"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Det finnes hindringer i kundens betjeningsområde foran betalingsterminalen. Gjenstander som henger over kundens betjeningsområde, er minst 220 cm over gulvet." },
                    { new Guid("5631c088-146b-4df6-98a6-7a7f4e8d6331"), new Guid("a9b2bb20-7240-4a93-ba1a-ae270e8679f1"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Det finnes hindringer i kundens betjeningsområde foran betalingsterminalen. Det henger ikke gjenstander over kundens betjeningsområde." },
                    { new Guid("20dc4731-c388-40f9-8c6a-45b92591f003"), new Guid("d18a7bce-556c-45cc-87d7-c765261166d5"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Kundens betjeningsområde foran betalingsterminalen er uten hindringer. Gjenstander som henger over kundens betjeningsområde, er lavere enn 220 cm over gulvet." },
                    { new Guid("cf2e7b7c-7fdd-45d1-8140-f6c299805358"), new Guid("d438e931-f57c-4a5c-bb5c-3e3a66824827"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Kundens betjeningsområde foran betalingsterminalen er uten hindringer. Gjenstander som henger over kundens betjeningsområde, er minst 220 cm over gulvet." },
                    { new Guid("6b3a3de6-d6ff-45a4-8061-6e62d6970747"), new Guid("ae869b09-090d-459b-827c-4d61a1578478"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Betalingsterminalene står for tett." }
                });

            migrationBuilder.InsertData(
                table: "RuleList",
                columns: new[] { "Id", "ChapterItemId", "IndicatorItemId", "Order", "RequirementItemId", "StandardItemId" },
                values: new object[,]
                {
                    { new Guid("832e0843-cab3-4dbc-9799-974e283fcc0b"), new Guid("75468cd0-478b-45e9-8a8e-51b0e574fb3b"), new Guid("c52eb3bc-6464-4dc9-b9f3-eb975e2a012c"), 1, new Guid("aebd662d-9dd5-4a27-88d5-19d6c5e12e5a"), new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2") },
                    { new Guid("eb160c6c-3a9e-4dff-93df-577d9eab4e09"), new Guid("731a0f5c-f586-471f-b32c-ceb8027f735a"), new Guid("692627b2-53bc-43f2-900d-44a40a21e7e9"), 1, new Guid("875e76b5-c926-43a0-8738-c4f41c7a0b8b"), new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2") },
                    { new Guid("b64cac7e-6525-49e8-9112-0238e1588ed8"), new Guid("b80b9b15-8f0e-4702-b7d9-95cafa68f9fb"), new Guid("692627b2-53bc-43f2-900d-44a40a21e7e9"), 2, new Guid("875e76b5-c926-43a0-8738-c4f41c7a0b8b"), new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2") },
                    { new Guid("0d6c763e-e0f6-4049-adeb-ae9429262b57"), new Guid("5f5abe28-1a74-4242-acc8-4b881ee4973a"), new Guid("6b4bf385-9174-4634-bc9e-bfbdab98586e"), 1, new Guid("c65786bb-1b93-4153-b88c-935cc2a7ab60"), new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2") },
                    { new Guid("5b3af04b-f6c6-4425-a22f-c2e7479839a5"), new Guid("6c0f12f8-0a91-4849-b18f-2af735017fcd"), new Guid("5b2a0a78-039f-4173-bf9e-1ca0060d1c53"), 1, new Guid("e503322b-ed77-4b69-adc4-eca19b6eb97d"), new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2") }
                });

            migrationBuilder.InsertData(
                table: "AnswerList",
                columns: new[] { "Id", "AlwaysVisible", "Bool", "LinkedParentCorrectId", "LinkedParentFailedId", "MaxInt", "MinInt", "Order", "RuleItemId", "TypeOfAnswerId" },
                values: new object[,]
                {
                    { new Guid("02d2db89-3717-48e1-883e-8e526bf6c727"), false, false, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, 1, new Guid("eb160c6c-3a9e-4dff-93df-577d9eab4e09"), 2 },
                    { new Guid("9aea071e-7263-4b2e-8cd7-5193fbbe5b77"), true, false, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("f98f67e5-cf6a-4afe-8998-3132640f9d70"), 130, 75, 2, new Guid("5b3af04b-f6c6-4425-a22f-c2e7479839a5"), 3 },
                    { new Guid("f98f67e5-cf6a-4afe-8998-3132640f9d70"), false, true, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, 1, new Guid("5b3af04b-f6c6-4425-a22f-c2e7479839a5"), 2 },
                    { new Guid("f69c1e45-99d8-4293-a242-c5ed9e126e99"), false, true, new Guid("d8611e84-0f00-4d75-bcab-cbf127fb68b5"), new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, 3, new Guid("832e0843-cab3-4dbc-9799-974e283fcc0b"), 2 },
                    { new Guid("9a51cc68-857e-4822-ac81-0ec3ebe7bf43"), false, true, new Guid("d8611e84-0f00-4d75-bcab-cbf127fb68b5"), new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, 2, new Guid("832e0843-cab3-4dbc-9799-974e283fcc0b"), 2 },
                    { new Guid("c4870935-ee11-4557-a9c3-aca678c17565"), false, false, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, 4, new Guid("832e0843-cab3-4dbc-9799-974e283fcc0b"), 4 },
                    { new Guid("d8611e84-0f00-4d75-bcab-cbf127fb68b5"), false, true, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, 1, new Guid("832e0843-cab3-4dbc-9799-974e283fcc0b"), 2 },
                    { new Guid("13d6d530-e533-4510-9a66-8b862899dbdf"), false, false, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, 4, new Guid("0d6c763e-e0f6-4049-adeb-ae9429262b57"), 4 },
                    { new Guid("438787f3-b33b-489c-b5a8-2f046a634dea"), false, false, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, 3, new Guid("5b3af04b-f6c6-4425-a22f-c2e7479839a5"), 4 },
                    { new Guid("89fd2205-1047-403d-a5bd-f70a1de2f247"), false, true, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("202d20e0-61df-4a7c-8287-104e3b439f64"), 0, 0, 2, new Guid("0d6c763e-e0f6-4049-adeb-ae9429262b57"), 2 },
                    { new Guid("78b8d910-c0bb-4467-acbe-1320f51fe658"), true, false, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("89fd2205-1047-403d-a5bd-f70a1de2f247"), -1, 150, 3, new Guid("0d6c763e-e0f6-4049-adeb-ae9429262b57"), 3 },
                    { new Guid("5544b740-0b5f-400c-b7b2-7e6472d4160b"), true, false, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bf459d05-702d-47d7-a5b7-19f8b3fb67c9"), -1, 220, 3, new Guid("b64cac7e-6525-49e8-9112-0238e1588ed8"), 3 },
                    { new Guid("bf459d05-702d-47d7-a5b7-19f8b3fb67c9"), false, true, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("a1964762-5c8f-40bb-a22d-c907149079d4"), 0, 0, 2, new Guid("b64cac7e-6525-49e8-9112-0238e1588ed8"), 2 },
                    { new Guid("a1964762-5c8f-40bb-a22d-c907149079d4"), false, false, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, 1, new Guid("b64cac7e-6525-49e8-9112-0238e1588ed8"), 2 },
                    { new Guid("8a12d92b-8a6a-44e7-9517-74331a4c2483"), false, false, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, 4, new Guid("b64cac7e-6525-49e8-9112-0238e1588ed8"), 4 },
                    { new Guid("d7b40e3c-e7fa-44e5-b44f-750759c971cc"), false, false, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("02d2db89-3717-48e1-883e-8e526bf6c727"), 0, 0, 2, new Guid("eb160c6c-3a9e-4dff-93df-577d9eab4e09"), 1 },
                    { new Guid("6912d4a0-b73b-4ecc-9fa8-49e1fd356635"), false, false, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, 3, new Guid("eb160c6c-3a9e-4dff-93df-577d9eab4e09"), 4 },
                    { new Guid("202d20e0-61df-4a7c-8287-104e3b439f64"), false, false, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, 1, new Guid("0d6c763e-e0f6-4049-adeb-ae9429262b57"), 2 }
                });

            migrationBuilder.InsertData(
                table: "RuleLanguageList",
                columns: new[] { "Id", "HelpText", "LanguageItemId", "RuleItemId" },
                values: new object[,]
                {
                    { new Guid("804438bd-ac67-40ff-9168-6814ea843242"), "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/12.png' alt='Gjenstander over betjeningsområdet. Illustrasjon.' /><h3>Krav:</h3><p>Det skal ikke henge gjenstander lavere enn 220 cm ned i kundens betjeningsområde.</p><h3>Hensikt:</h3><p>Hindringer kan også henge ned fra taket, som for eksempel skilt, plakater og lamper. Det gjør det vanskelig for høye kunder å komme frem til og bruke betalingsterminalen.</p></div>", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), new Guid("b64cac7e-6525-49e8-9112-0238e1588ed8") },
                    { new Guid("e369820b-ebcd-488e-9216-477d363f18ed"), "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/21.png' alt='Krav på avstand mellom betalingsautomater. Illustrasjon' /><h3>Krav: </h3><p>Dersom to eller flere betalingsterminaler står ved siden av hverandre på rett linje, skal det være minst 150 centimeter fra midten av betalingsterminalen til midten av neste betalingsterminal. NB Kravet gjelder ikke der betalingsterminalene står overfor hverandre.</p><h3>Hensikt: </h3><p>Formålet er at betalingsterminaler som står ved siden av hverandre, kan brukes samtidig, og at kundene som skal betale varene sine, kan komme seg bort uten å forstyrre hverandre.<br />Dersom det er flere betalingsterminaler som står ved siden av hverandre på rett linje, mål avstanden til den nærmeste.<br />Utgangspunktet for målingen er midt foran på betalingsterminalen.<br /></p></div>", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), new Guid("0d6c763e-e0f6-4049-adeb-ae9429262b57") },
                    { new Guid("6ae15ad1-51c2-4d8f-817d-7acf925c5de9"), "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/01.png' alt='Avstander i kundens betjeningsområde. Illustrasjon.' /><p>Kundens betjeningsområde er plassen foran betalingsterminalen, der kundene står når de bruker betalingsterminalen for å betale varene sine.<br />Illustrasjonen viser kundens betjeningsområde for betalingsterminalen. Det er et krav at dette området skal være minst 150 x 150 cm og uten hindringer.<br />Du skal nå måle opp kundens betjeningsområde i form av et kvadrat. Hensikten med å måle opp området er at du skal få en bedre forståelse av hva du skal sjekke i egenkontrollen.<br /></p><ul><li>Mål fra kassen/disken. Start på punktet midt foran betalingsterminalen og mål 75 cm mot venstre</li><li>Mål fra kassen/disken. Start på punktet midt foran betalingsterminalen og mål 75 cm mot høyre</li><li>Mål fra kassen/disken. Start på punktet midt foran betalingsterminalen og mål 150 cm ut i lokalet</li></ul></div><div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/11.png' alt='Kundens betjeningsområde foran betalingsautomaten. Illustrasjon.' /><h3>Krav:</h3><p>Kundens betjeningsområde foran betalingsterminalen skal være minst 150 x 150 centimeter. Det skal være uten hindringer.</p><h3>Hensikt:</h3><p>Formålet er at rullestolbrukere kan komme frem til betalingsterminalen og snu rullestolen om det trengs. Hindringer gjør det vanskelig for kunden å komme frem til og bruke betalingsterminalen. En hindring er for eksempel varehyller, stolper, vegger, søppelbøtter, skilt eller benker.</p><p>Om der er mulig, skal du ta bort hindringer i kundens betjeningsområde før du svarer på spørsmålet.</p></div>", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), new Guid("eb160c6c-3a9e-4dff-93df-577d9eab4e09") },
                    { new Guid("55294d7b-6af0-4399-8a5c-776aa13e3a29"), "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/31.png' alt='Skilt over betalingsområdet. Illustrasjon' /><h3>Krav:</h3><p>Skiltet skal plasseres over betalingsterminalen. Skiltet skal være synlig på avstand, utenfor kundens betjeningsområde.</p><h3>Hensikt: </h3><p>Formålet er at kunden lett skal finne fram til betalingsterminalen.<br />Skiltet skal være plassert over området der kunden skal betale varene sine. Det kan for eksempel være over kassen eller disken der betalingsterminalen står.<br />Eksempler på tekst på skilt er<br /></p><ul><li>Kasse</li><li>Betal her</li><li>Kort og kontanter</li><li>Nummer på kassen</li></ul></div>", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), new Guid("832e0843-cab3-4dbc-9799-974e283fcc0b") },
                    { new Guid("d8c7e031-b2eb-4906-8c4d-c1d5f3266bbc"), "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/41.png' alt='Høyden på betjeningskomponenter. Illustrasjon' /><h3>Krav: </h3><p>Høyden på betjeningskomponenter som skjerm og tastatur skal være mellom 75 centimeter og 130 centimeter over gulvet.</p><h3>Hensikt:</h3><p>Formålet er at betalingsterminalen skal være enkel å nå og bruke, både for kunder som står og kunder som sitter, f.eks. rullestolbrukere.<br />Dersom du kan justere høyden på betalingsterminalen, skal du flytte den til mellom 75 og 130 cm over gulvet før du måler.<br />Utgangspunktet for målingen er midt på betalingsterminalen.</p></div>", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), new Guid("5b3af04b-f6c6-4425-a22f-c2e7479839a5") }
                });

            migrationBuilder.InsertData(
                table: "AnswerLanguageList",
                columns: new[] { "Id", "AnswerItemId", "BoolFalseText", "BoolTrueText", "LanguageItemId", "Question" },
                values: new object[,]
                {
                    { new Guid("2583fbbf-12a3-475d-b610-41b5ad0327c1"), new Guid("02d2db89-3717-48e1-883e-8e526bf6c727"), "Nei", "Ja", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Finnes det hindringer i kundens betjeningsområde?" },
                    { new Guid("8da3f1e2-4ed3-4957-b94d-797ed932ec73"), new Guid("f98f67e5-cf6a-4afe-8998-3132640f9d70"), "Annet, ", "Mellom 75cm og 130cm over gulvet", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Hvor mange cm er det fra gulvet og opp til betalingsterminalen?" },
                    { new Guid("0ed22f35-94ec-46d1-9aad-615f91bbb1b0"), new Guid("f69c1e45-99d8-4293-a242-c5ed9e126e99"), "Nei", "Ja", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Er skiltet synlig på avstand utenfor kundens betjeningsområde?" },
                    { new Guid("14b18d90-1b1f-4628-b15e-edc9afe5a0a1"), new Guid("9a51cc68-857e-4822-ac81-0ec3ebe7bf43"), "Nei", "Ja", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Er skiltet plassert over området der kunden skal betale varene sine?" },
                    { new Guid("ec0e3dd2-bd43-4e44-a118-51b86b80d77f"), new Guid("c4870935-ee11-4557-a9c3-aca678c17565"), null, null, new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Bekreft med bilde" },
                    { new Guid("463efa96-5c19-4945-8bac-100a2b4c6916"), new Guid("d8611e84-0f00-4d75-bcab-cbf127fb68b5"), "Nei", "Ja", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Finnes det et skilt som viser hvor kunden skal betale varene sine?" },
                    { new Guid("6e68729a-50e9-4844-a791-43e2eb21fad0"), new Guid("13d6d530-e533-4510-9a66-8b862899dbdf"), null, null, new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Bekreft med bilde" },
                    { new Guid("cb3bfb9a-b373-4264-9add-3f4ec562c402"), new Guid("78b8d910-c0bb-4467-acbe-1320f51fe658"), null, null, new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Mål i cm" },
                    { new Guid("b760e91c-81f5-4de9-82c2-3747c23dbf9d"), new Guid("89fd2205-1047-403d-a5bd-f70a1de2f247"), "0-149 cm, ", "150 cm eller mer", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Hvor mange cm er det mellom betalingsterminalene?" },
                    { new Guid("7c632541-119a-4dd5-b501-e0ba7e2caff2"), new Guid("202d20e0-61df-4a7c-8287-104e3b439f64"), "Nei", "Ja", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Står betalingsterminalen ved siden av en annen betalingsterminal, på rett linje?" },
                    { new Guid("4b1e6cba-160c-4adb-a6cf-0736f1d585c2"), new Guid("5544b740-0b5f-400c-b7b2-7e6472d4160b"), null, null, new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Mål i cm" },
                    { new Guid("1670250d-7f81-4fd0-90a2-d9a8df97df8a"), new Guid("bf459d05-702d-47d7-a5b7-19f8b3fb67c9"), "0-219 cm, ", "220 cm eller mer", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Hvor mange cm over gulvet henger den laveste gjenstanden i kundens betjeningsområde?" },
                    { new Guid("3ec18f01-3e59-4cb1-b4b3-75e0af67ac2f"), new Guid("a1964762-5c8f-40bb-a22d-c907149079d4"), "Nei", "Ja", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Henger det gjenstander over kundens betjeningsområde?" },
                    { new Guid("6c73f84c-a2d5-43ac-a5fe-793d0c5672cc"), new Guid("8a12d92b-8a6a-44e7-9517-74331a4c2483"), null, null, new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Bekreft med bilde" },
                    { new Guid("6876174d-2e2c-484b-a9a7-14cb63359a30"), new Guid("d7b40e3c-e7fa-44e5-b44f-750759c971cc"), null, null, new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Beskriv hindringene i kundens betjeningsområde:" },
                    { new Guid("db55a19e-7f42-4176-921d-4a09698f727a"), new Guid("6912d4a0-b73b-4ecc-9fa8-49e1fd356635"), null, null, new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Bekreft med bilde" },
                    { new Guid("f94c4896-806c-4ce1-b6a3-ebf090ee9789"), new Guid("9aea071e-7263-4b2e-8cd7-5193fbbe5b77"), null, null, new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Mål i cm" },
                    { new Guid("2e2e8b32-c7c4-4ffa-b6b7-275a82e5b6af"), new Guid("438787f3-b33b-489c-b5a8-2f046a634dea"), null, null, new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Bekreft med bilde" }
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
                name: "IX_AnswerLanguageList_AnswerItemId",
                table: "AnswerLanguageList",
                column: "AnswerItemId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerLanguageList_LanguageItemId",
                table: "AnswerLanguageList",
                column: "LanguageItemId");

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
                name: "IX_DeclarationIndicatorGroupList_TestGroupItemId",
                table: "DeclarationIndicatorGroupList",
                column: "TestGroupItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationList_CompanyItemId",
                table: "DeclarationList",
                column: "CompanyItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationList_StatusId",
                table: "DeclarationList",
                column: "StatusId");

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
                name: "IX_DeclarationTestItem_PurposeOfTestId",
                table: "DeclarationTestItem",
                column: "PurposeOfTestId");

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
                name: "IX_IndicatorOutcomeLanguageList_IndicatorOutcomeItemId",
                table: "IndicatorOutcomeLanguageList",
                column: "IndicatorOutcomeItemId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicatorOutcomeLanguageList_LanguageItemId",
                table: "IndicatorOutcomeLanguageList",
                column: "LanguageItemId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicatorOutcomeList_IndicatorItemId",
                table: "IndicatorOutcomeList",
                column: "IndicatorItemId");

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
                name: "IX_OutcomeData_IndicatorOutcomeItemId",
                table: "OutcomeData",
                column: "IndicatorOutcomeItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeData_ResultId",
                table: "OutcomeData",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_RequirementLanguageList_LanguageItemId",
                table: "RequirementLanguageList",
                column: "LanguageItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RequirementLanguageList_RequirementItemId",
                table: "RequirementLanguageList",
                column: "RequirementItemId");

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
                name: "IX_RuleLanguageList_LanguageItemId",
                table: "RuleLanguageList",
                column: "LanguageItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RuleLanguageList_RuleItemId",
                table: "RuleLanguageList",
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
                name: "IX_TestGroupLanguageList_LanguageItemId",
                table: "TestGroupLanguageList",
                column: "LanguageItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TestGroupLanguageList_TestGroupItemId",
                table: "TestGroupLanguageList",
                column: "TestGroupItemId");

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
                name: "AnswerLanguageList");

            migrationBuilder.DropTable(
                name: "ContactPersonList");

            migrationBuilder.DropTable(
                name: "DeclarationIndicatorGroupList");

            migrationBuilder.DropTable(
                name: "IndicatorOutcomeLanguageList");

            migrationBuilder.DropTable(
                name: "IndicatorTestGroupList");

            migrationBuilder.DropTable(
                name: "IndicatorUserPrerequisite");

            migrationBuilder.DropTable(
                name: "RequirementLanguageList");

            migrationBuilder.DropTable(
                name: "RequirementUserPrerequisiteList");

            migrationBuilder.DropTable(
                name: "RuleLanguageList");

            migrationBuilder.DropTable(
                name: "TestGroupLanguageList");

            migrationBuilder.DropTable(
                name: "UserCompanyList");

            migrationBuilder.DropTable(
                name: "UserRoleList");

            migrationBuilder.DropTable(
                name: "RuleData");

            migrationBuilder.DropTable(
                name: "AnswerList");

            migrationBuilder.DropTable(
                name: "VlUserPrerequisiteList");

            migrationBuilder.DropTable(
                name: "LanguageList");

            migrationBuilder.DropTable(
                name: "TestGroupList");

            migrationBuilder.DropTable(
                name: "RoleList");

            migrationBuilder.DropTable(
                name: "OutcomeData");

            migrationBuilder.DropTable(
                name: "RuleList");

            migrationBuilder.DropTable(
                name: "VlTypeOfAnswer");

            migrationBuilder.DropTable(
                name: "DeclarationTestItem");

            migrationBuilder.DropTable(
                name: "IndicatorOutcomeList");

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
                name: "VlPurposeOfTest");

            migrationBuilder.DropTable(
                name: "VlTypeOfSupplierAndVersionList");

            migrationBuilder.DropTable(
                name: "VlTypeOfMachineList");

            migrationBuilder.DropTable(
                name: "VlTypeOfTestList");

            migrationBuilder.DropTable(
                name: "IndicatorList");

            migrationBuilder.DropTable(
                name: "StandardList");

            migrationBuilder.DropTable(
                name: "CompanyList");

            migrationBuilder.DropTable(
                name: "VlTypeOfStatus");

            migrationBuilder.DropTable(
                name: "UserList");
        }
    }
}
