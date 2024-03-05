using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Cities_SehirId",
                table: "Districts");

            migrationBuilder.RenameColumn(
                name: "SehirId",
                table: "Districts",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Districts_SehirId",
                table: "Districts",
                newName: "IX_Districts_CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Cities_CityId",
                table: "Districts",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Cities_CityId",
                table: "Districts");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Districts",
                newName: "SehirId");

            migrationBuilder.RenameIndex(
                name: "IX_Districts_CityId",
                table: "Districts",
                newName: "IX_Districts_SehirId");

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Cities_SehirId",
                table: "Districts",
                column: "SehirId",
                principalTable: "Cities",
                principalColumn: "CityId");
        }
    }
}
