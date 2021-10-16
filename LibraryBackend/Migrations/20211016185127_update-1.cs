using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryBackend.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Seudonimo",
                table: "Autores",
                type: "varchar(75)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(25)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Seudonimo",
                table: "Autores",
                type: "varchar(25)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(75)");
        }
    }
}
