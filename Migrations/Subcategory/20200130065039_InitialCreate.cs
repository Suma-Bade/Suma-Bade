using Microsoft.EntityFrameworkCore.Migrations;

namespace EmartMVC.Migrations.Subcategory
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "subcategories",
                columns: table => new
                {
                    SubId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubName = table.Column<string>(nullable: true),
                    SubDetails = table.Column<string>(nullable: true),
                    SubGst = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subcategories", x => x.SubId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subcategories");
        }
    }
}
