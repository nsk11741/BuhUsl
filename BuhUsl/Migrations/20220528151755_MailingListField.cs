using Microsoft.EntityFrameworkCore.Migrations;

namespace BuhUsl.Migrations
{
    public partial class MailingListField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMailingList",
                table: "Clients",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMailingList",
                table: "Clients");
        }
    }
}
