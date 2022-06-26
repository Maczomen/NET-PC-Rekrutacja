using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactsWebApp.Data.Migrations
{
    public partial class WorkingCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contact_email",
                table: "Contact");

            migrationBuilder.AlterColumn<int>(
                name: "category",
                table: "Contact",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "category",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Contact_email",
                table: "Contact",
                column: "email",
                unique: true);
        }
    }
}
