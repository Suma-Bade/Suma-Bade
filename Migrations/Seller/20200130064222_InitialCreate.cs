using Microsoft.EntityFrameworkCore.Migrations;

namespace EmartMVC.Migrations.Seller
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    SId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(maxLength: 10, nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Companyname = table.Column<string>(nullable: false),
                    GSTIN = table.Column<int>(nullable: false),
                    AboutCompany = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: false),
                    Website = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Mobileno = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.SId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sellers");
        }
    }
}
