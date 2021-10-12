using Microsoft.EntityFrameworkCore.Migrations;

namespace Quarter.Migrations
{
    public partial class AddHouseImageInOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HouseImage",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HouseImage",
                table: "Orders");
        }
    }
}
