using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pragma.AdminCore.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Filter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    UserCreated = table.Column<string>(nullable: true),
                    UserUpdated = table.Column<string>(nullable: true),
                    UserDeleted = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filter_AspNetUsers_UserCreated",
                        column: x => x.UserCreated,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Filter_AspNetUsers_UserDeleted",
                        column: x => x.UserDeleted,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Filter_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Filter_AspNetUsers_UserUpdated",
                        column: x => x.UserUpdated,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Record",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    UserCreated = table.Column<string>(nullable: true),
                    UserUpdated = table.Column<string>(nullable: true),
                    UserDeleted = table.Column<string>(nullable: true),
                    SahibindenId = table.Column<string>(maxLength: 450, nullable: true),
                    IsActive = table.Column<string>(nullable: true),
                    ThumbnailImage = table.Column<string>(nullable: true),
                    LastCheckDate = table.Column<DateTime>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    Serie = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    KM = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    ListingDate = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    FirstPrice = table.Column<int>(nullable: false),
                    LivePrice = table.Column<int>(nullable: false),
                    FilterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Record", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Record_Filter_FilterId",
                        column: x => x.FilterId,
                        principalTable: "Filter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Record_AspNetUsers_UserCreated",
                        column: x => x.UserCreated,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Record_AspNetUsers_UserDeleted",
                        column: x => x.UserDeleted,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Record_AspNetUsers_UserUpdated",
                        column: x => x.UserUpdated,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecordPriceChanges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    UserCreated = table.Column<string>(nullable: true),
                    UserUpdated = table.Column<string>(nullable: true),
                    UserDeleted = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    RecordId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordPriceChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecordPriceChanges_Record_RecordId",
                        column: x => x.RecordId,
                        principalTable: "Record",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecordPriceChanges_AspNetUsers_UserCreated",
                        column: x => x.UserCreated,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecordPriceChanges_AspNetUsers_UserDeleted",
                        column: x => x.UserDeleted,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecordPriceChanges_AspNetUsers_UserUpdated",
                        column: x => x.UserUpdated,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Filter_UserCreated",
                table: "Filter",
                column: "UserCreated");

            migrationBuilder.CreateIndex(
                name: "IX_Filter_UserDeleted",
                table: "Filter",
                column: "UserDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Filter_UserId",
                table: "Filter",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Filter_UserUpdated",
                table: "Filter",
                column: "UserUpdated");

            migrationBuilder.CreateIndex(
                name: "IX_Record_FilterId",
                table: "Record",
                column: "FilterId");

            migrationBuilder.CreateIndex(
                name: "IX_Record_UserCreated",
                table: "Record",
                column: "UserCreated");

            migrationBuilder.CreateIndex(
                name: "IX_Record_UserDeleted",
                table: "Record",
                column: "UserDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Record_UserUpdated",
                table: "Record",
                column: "UserUpdated");

            migrationBuilder.CreateIndex(
                name: "IX_RecordPriceChanges_RecordId",
                table: "RecordPriceChanges",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordPriceChanges_UserCreated",
                table: "RecordPriceChanges",
                column: "UserCreated");

            migrationBuilder.CreateIndex(
                name: "IX_RecordPriceChanges_UserDeleted",
                table: "RecordPriceChanges",
                column: "UserDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_RecordPriceChanges_UserUpdated",
                table: "RecordPriceChanges",
                column: "UserUpdated");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "RecordPriceChanges");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Record");

            migrationBuilder.DropTable(
                name: "Filter");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
