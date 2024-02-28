using System;
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
                name: "FK_BlogLikes_BlogComments_BlogCommentId",
                table: "BlogLikes");

            migrationBuilder.DropIndex(
                name: "IX_BlogLikes_BlogCommentId",
                table: "BlogLikes");

            migrationBuilder.DropColumn(
                name: "BlogCommentId",
                table: "BlogLikes");

            migrationBuilder.AlterColumn<Guid>(
                name: "BlogId",
                table: "BlogLikes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "BlogId",
                table: "BlogLikes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "BlogCommentId",
                table: "BlogLikes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogLikes_BlogCommentId",
                table: "BlogLikes",
                column: "BlogCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogLikes_BlogComments_BlogCommentId",
                table: "BlogLikes",
                column: "BlogCommentId",
                principalTable: "BlogComments",
                principalColumn: "CommentId");
        }
    }
}
