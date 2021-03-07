using Microsoft.EntityFrameworkCore.Migrations;

namespace Orders.API.Entities.Migrations
{
    public partial class UpdateEnumsAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CaseType",
                table: "RecordSubjects",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<int>(
                name: "RecordType",
                table: "Locations",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "CaseType",
                table: "RecordSubjects",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<byte>(
                name: "RecordType",
                table: "Locations",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
