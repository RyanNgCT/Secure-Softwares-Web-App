using Microsoft.EntityFrameworkCore.Migrations;

namespace ssd_assignment_team1_draft1.Migrations
{
    public partial class SerialNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hash",
                table: "Software",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SerialNumber",
                table: "Software",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WarrantyPeriod",
                table: "Software",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hash",
                table: "Software");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "Software");

            migrationBuilder.DropColumn(
                name: "WarrantyPeriod",
                table: "Software");
        }
    }
}
