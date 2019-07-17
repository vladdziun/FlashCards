using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginReg.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardCategory",
                table: "Cards");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CardCategory",
                table: "Cards",
                nullable: false,
                defaultValue: "");
        }
    }
}
