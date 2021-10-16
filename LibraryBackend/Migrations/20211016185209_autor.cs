using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryBackend.Migrations
{
    public partial class autor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seudonimo",
                table: "Autores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Seudonimo",
                table: "Autores",
                type: "varchar(75)",
                nullable: false,
                defaultValue: "");
        }
    }
}
