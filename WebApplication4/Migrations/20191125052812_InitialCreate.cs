using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recalls",
                columns: table => new
                {
                    country = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    reason_for_recall = table.Column<string>(nullable: true),
                    address_1 = table.Column<string>(nullable: true),
                    code_info = table.Column<string>(nullable: true),
                    product_quantity = table.Column<string>(nullable: true),
                    center_classification_date = table.Column<string>(nullable: true),
                    distribution_pattern = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    product_description = table.Column<string>(nullable: true),
                    report_date = table.Column<string>(nullable: true),
                    search_id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recalls", x => x.search_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recalls");
        }
    }
}
