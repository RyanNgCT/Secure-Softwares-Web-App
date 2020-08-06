using Microsoft.EntityFrameworkCore.Migrations;

namespace ssd_assignment_team1_draft1.Migrations
{
    public partial class AddApplicationRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Software");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Software");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Review");

            migrationBuilder.AlterColumn<string>(
                name: "SoftwareName",
                table: "Review",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "AuditRecords",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "AuditActionType",
                table: "AuditRecords",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Software",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Software",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "SoftwareName",
                table: "Review",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Review",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "AuditRecords",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "AuditActionType",
                table: "AuditRecords",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150);
        }
    }
}
