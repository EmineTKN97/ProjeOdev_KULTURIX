using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mediaadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Blogs");

            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    MediaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BlogId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.MediaId);
                    table.ForeignKey(
                        name: "FK_Medias_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId");
                    table.ForeignKey(
                        name: "FK_Medias_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_UserId",
                table: "Blogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogLikes_Userid",
                table: "BlogLikes",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_BlogComments_UserId",
                table: "BlogComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_BlogId",
                table: "Medias",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_UserId",
                table: "Medias",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComments_Users_UserId",
                table: "BlogComments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogLikes_Users_Userid",
                table: "BlogLikes",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Users_UserId",
                table: "Blogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogComments_Users_UserId",
                table: "BlogComments");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogLikes_Users_Userid",
                table: "BlogLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Users_UserId",
                table: "Blogs");

            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_UserId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_BlogLikes_Userid",
                table: "BlogLikes");

            migrationBuilder.DropIndex(
                name: "IX_BlogComments_UserId",
                table: "BlogComments");

            migrationBuilder.AddColumn<Guid>(
                name: "BlogId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
