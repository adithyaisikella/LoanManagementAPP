using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagementAPP.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDetailsData",
                columns: table => new
                {
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetailsData", x => x.UserName);
                });

            migrationBuilder.InsertData(
                table: "UserDetailsData",
                columns: new[] { "UserName", "Password", "Role" },
                values: new object[] { "Adithya", "police", "Admin" });

            migrationBuilder.InsertData(
                table: "UserDetailsData",
                columns: new[] { "UserName", "Password", "Role" },
                values: new object[] { "Daya", "rams", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDetailsData");
        }
    }
}
