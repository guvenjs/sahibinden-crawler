using Microsoft.EntityFrameworkCore.Migrations;

namespace Pragma.AdminCore.Data.Migrations
{
    public partial class updatedrecordtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Record",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IsActive",
                table: "Record",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}
