using Microsoft.EntityFrameworkCore.Migrations;

namespace repo.Migrations
{
    public partial class ondelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_City_CityId",
                table: "Client");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_City_CityId",
                table: "Client",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_City_CityId",
                table: "Client");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_City_CityId",
                table: "Client",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
