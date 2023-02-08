using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Migrations
{
    public partial class UserPostRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "applicationUserId",
                table: "Posts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_applicationUserId",
                table: "Posts",
                column: "applicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_applicationUserId",
                table: "Posts",
                column: "applicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_applicationUserId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_applicationUserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "applicationUserId",
                table: "Posts");
        }
    }
}
