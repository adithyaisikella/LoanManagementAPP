using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagementAPP.Migrations
{
    public partial class LoanManagementAPPModelsUserDetDataContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDetailsData",
                columns: table => new
                {
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Roleid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetailsData", x => x.UserName);
                });

            migrationBuilder.InsertData(
                table: "UserDetailsData",
                columns: new[] { "UserName", "Password", "Roleid" },
                values: new object[] { "Adithya@gmail.com", "police", "1" });

            migrationBuilder.InsertData(
                table: "UserDetailsData",
                columns: new[] { "UserName", "Password", "Roleid" },
                values: new object[] { "Daya@gmail.com", "rams", "0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDetailsData");
        }
    }
}
