using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Migrations
{
    public partial class UserCommentRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "applicationUserId",
                table: "Comments",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_applicationUserId",
                table: "Comments",
                column: "applicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_applicationUserId",
                table: "Comments",
                column: "applicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_applicationUserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_applicationUserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "applicationUserId",
                table: "Comments");
        }
    }
}
