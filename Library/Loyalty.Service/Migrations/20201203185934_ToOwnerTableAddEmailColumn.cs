using Microsoft.EntityFrameworkCore.Migrations;

namespace Loyalty.Service.Migrations
{
    public partial class ToOwnerTableAddEmailColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "tblOwner",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "tblOwner");
        }
    }
}
