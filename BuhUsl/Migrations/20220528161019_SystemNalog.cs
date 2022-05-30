using Microsoft.EntityFrameworkCore.Migrations;

namespace BuhUsl.Migrations
{
    public partial class SystemNalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SystemNalog",
                table: "Order",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SystemNalog",
                table: "Order");
        }
    }
}
