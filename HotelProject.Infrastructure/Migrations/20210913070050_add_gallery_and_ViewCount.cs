using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelProject.Persistance.Migrations
{
    public partial class add_gallery_and_ViewCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ViewCount",
                table: "Rooms",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Rooms");
        }
    }
}
