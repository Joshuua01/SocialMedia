using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Migrations
{
    public partial class PostCommOnCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_postId",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "44eb985a-a588-45f7-83e4-0f75290d87ed");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                column: "ConcurrencyStamp",
                value: "ef8e37c9-aed5-44f1-af90-f796f810d1dd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43d656f3-55f1-4c13-8c8a-44784e244edc", new DateTime(2023, 2, 17, 23, 43, 14, 211, DateTimeKind.Local).AddTicks(4188), "AQAAAAEAACcQAAAAEPMo1rNoLHEn25L0tRROzDCKvF4iphA2Dx3lYyoDfW1okHelOscA8sgpDAMqviTesQ==", "dce3b2f4-455e-4390-b091-c40937afb1a4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e80bb701-5abf-4001-bc17-378e9b03205c", new DateTime(2023, 2, 17, 23, 43, 14, 203, DateTimeKind.Local).AddTicks(8329), "AQAAAAEAACcQAAAAEEtHMGIjaOMvjLMNB4IIpTFUBrqU172AiMkYwPa4jHZdY3WZOQAgHXjd3hvCg8yEbQ==", "4144fc05-bdc7-4686-84f3-a0a17cb1644f" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_postId",
                table: "Comments",
                column: "postId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_postId",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "7442358f-5367-43c6-8bcd-0d1b5c414352");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                column: "ConcurrencyStamp",
                value: "9ba462cc-4218-4218-a4c6-5021dc731459");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7162ebe-76c1-45e3-98d0-f0d0feaed1bf", new DateTime(2023, 2, 15, 16, 41, 9, 206, DateTimeKind.Local).AddTicks(5849), "AQAAAAEAACcQAAAAEHScSGLwamhY+faKDQ2kSvHKLrV2NLJ67zr9W/kg7Q8hMyJlW7dzGpU3YGTKqmPnWA==", "895f4a60-15db-44c5-9721-fed1e997964a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a4890dc-7290-47ee-bd72-9e90ac9f3643", new DateTime(2023, 2, 15, 16, 41, 9, 199, DateTimeKind.Local).AddTicks(179), "AQAAAAEAACcQAAAAEDn+T9bC0m4Yk6GkPCv6VhBcgS9HP/PoNHHhbhGM6N5JUXfHGU8Zvi9mZxBSg8cixg==", "9d2000b8-4be0-4d7d-9a98-f89bdb354593" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_postId",
                table: "Comments",
                column: "postId",
                principalTable: "Posts",
                principalColumn: "Id");
        }
    }
}
