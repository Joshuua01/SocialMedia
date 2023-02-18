using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Migrations
{
    public partial class CategoryPostCascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_categoryId",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "d181cbdf-75b9-49cc-952f-400a27f12209");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                column: "ConcurrencyStamp",
                value: "ab0a51fd-5551-4646-9d62-b9e8721103ef");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e58ff57-43d6-4042-af47-c9b2ce5075d9", new DateTime(2023, 2, 18, 10, 33, 52, 566, DateTimeKind.Local).AddTicks(3163), "AQAAAAEAACcQAAAAEKamDZcAtdvC7XnpIX1SGefj5XUPbk6oGu5HuWGkSwtEORxrCCDoQVr8GjoQaoOfjg==", "cda3830b-266b-4e0f-afba-9895503a52f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5aab275-3df7-4fa6-a16a-e18089bbf0f1", new DateTime(2023, 2, 18, 10, 33, 52, 558, DateTimeKind.Local).AddTicks(6608), "AQAAAAEAACcQAAAAEFhdLr8wYJ6k/t2lFtP213RSkSNQ5ORVY74URAl9nh3dNm95aWLEpxExsUkgZovd/w==", "5c3e9221-9acf-4251-8c2d-af721f61cf1b" });

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_categoryId",
                table: "Posts",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_categoryId",
                table: "Posts");

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
                name: "FK_Posts_Categories_categoryId",
                table: "Posts",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
