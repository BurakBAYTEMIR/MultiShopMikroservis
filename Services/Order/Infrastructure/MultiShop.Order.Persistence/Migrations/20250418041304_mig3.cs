using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiShop.Order.Persistence.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrederDate",
                table: "Orderings",
                newName: "OrderDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Orderings",
                newName: "OrederDate");
        }
    }
}
