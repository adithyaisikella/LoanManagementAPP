
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanInformationAPI.Migrations
{
    public partial class LoanInformationAPIModelsLoanDBContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "loanHolders",
                columns: table => new
                {
                    BorrowerName = table.Column<string>(nullable: false),
                    PropertyInformation = table.Column<string>(nullable: true),
                    LoanId = table.Column<string>(nullable: true),
                    LegalDocuments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loanHolders", x => x.BorrowerName);
                });

            migrationBuilder.CreateTable(
                name: "RoleDescriptions",
                columns: table => new
                {
                    Roleid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleDescriptions", x => x.Roleid);
                });

            migrationBuilder.CreateTable(
                name: "LoanDetails",
                columns: table => new
                {
                    LoanId = table.Column<string>(nullable: false),
                    LoanAmount = table.Column<string>(nullable: true),
                    LoanTerm = table.Column<string>(nullable: true),
                    LoanType = table.Column<string>(nullable: true),
                    LoanHoldersBorrowerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanDetails", x => x.LoanId);
                    table.ForeignKey(
                        name: "FK_LoanDetails_loanHolders_LoanHoldersBorrowerName",
                        column: x => x.LoanHoldersBorrowerName,
                        principalTable: "loanHolders",
                        principalColumn: "BorrowerName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "LoanDetails",
                columns: new[] { "LoanId", "LoanAmount", "LoanHoldersBorrowerName", "LoanTerm", "LoanType" },
                values: new object[] { "9034", "230000", null, "24 Months", "HOME Loan" });

            migrationBuilder.InsertData(
                table: "RoleDescriptions",
                columns: new[] { "Roleid", "RoleType" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "loanHolders",
                columns: new[] { "BorrowerName", "LegalDocuments", "LoanId", "PropertyInformation" },
                values: new object[] { "Rajesh", "House Tax central Govt", "9034", "1-1-2,Infopark,Kochi,Kerala-682030" });

            migrationBuilder.CreateIndex(
                name: "IX_LoanDetails_LoanHoldersBorrowerName",
                table: "LoanDetails",
                column: "LoanHoldersBorrowerName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanDetails");

            migrationBuilder.DropTable(
                name: "RoleDescriptions");

            migrationBuilder.DropTable(
                name: "loanHolders");
        }
    }
}
