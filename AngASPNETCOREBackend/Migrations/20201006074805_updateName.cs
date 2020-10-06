using Microsoft.EntityFrameworkCore.Migrations;

namespace AngASPNETCOREBackend.Migrations
{
    public partial class updateName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usrs",
                table: "Usrs");

            migrationBuilder.RenameTable(
                name: "Usrs",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Usrs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usrs",
                table: "Usrs",
                column: "Id");
        }
    }
}
