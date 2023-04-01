using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pragma.AdminCore.Data.Migrations
{
    public partial class temp_record : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TempRecord",
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
                    ProcessId = table.Column<Guid>(nullable: false),
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
                    LivePrice = table.Column<int>(nullable: false),
                    FilterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TempRecord_Filter_FilterId",
                        column: x => x.FilterId,
                        principalTable: "Filter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TempRecord_AspNetUsers_UserCreated",
                        column: x => x.UserCreated,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TempRecord_AspNetUsers_UserDeleted",
                        column: x => x.UserDeleted,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TempRecord_AspNetUsers_UserUpdated",
                        column: x => x.UserUpdated,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TempRecord_FilterId",
                table: "TempRecord",
                column: "FilterId");

            migrationBuilder.CreateIndex(
                name: "IX_TempRecord_UserCreated",
                table: "TempRecord",
                column: "UserCreated");

            migrationBuilder.CreateIndex(
                name: "IX_TempRecord_UserDeleted",
                table: "TempRecord",
                column: "UserDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TempRecord_UserUpdated",
                table: "TempRecord",
                column: "UserUpdated");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TempRecord");
        }
    }
}
