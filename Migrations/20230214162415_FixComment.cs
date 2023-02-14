using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Migrations
{
    public partial class FixComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_applicationUserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_postId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "postId",
                table: "Comments",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "applicationUserId",
                table: "Comments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "a55294c9-8b9b-46a1-97c6-a1aa4d2688b2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                column: "ConcurrencyStamp",
                value: "87dabac9-d416-4f6f-927d-902e90cda4a6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "47c1fa1b-0a42-4343-846f-c5074ee7c070", new DateTime(2023, 2, 14, 17, 24, 14, 731, DateTimeKind.Local).AddTicks(3556), "AQAAAAEAACcQAAAAEFdu0PpErpEA6uSQbcmquJzr2AAu1iPazz417pIAPBGMND+q/jSpln0Lo+ovLMsbtQ==", "2ddad748-0199-4b22-b4b9-58d7ad26b4f8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a186373-8779-4577-9ef9-3600446062fa", new DateTime(2023, 2, 14, 17, 24, 14, 723, DateTimeKind.Local).AddTicks(6352), "AQAAAAEAACcQAAAAEKjj0/VFOxPd+KQAFcwydVPb1lYCtsWWFRAIYg36Ck2MurFk2wd/bjwGjurm3JY3lg==", "35f24f41-a554-47ce-abf6-0def4c48f825" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_applicationUserId",
                table: "Comments",
                column: "applicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_postId",
                table: "Comments",
                column: "postId",
                principalTable: "Posts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_applicationUserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_postId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "postId",
                table: "Comments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "applicationUserId",
                table: "Comments",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "e09ad5c9-aef9-4eeb-b6d3-a2800dbfccf9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                column: "ConcurrencyStamp",
                value: "aabb66fc-0751-444d-a7c4-8ec4fb09d5fa");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "169db931-f5f1-4408-bcb5-70dfcd8afb46", new DateTime(2023, 2, 14, 13, 55, 3, 662, DateTimeKind.Local).AddTicks(640), "AQAAAAEAACcQAAAAEIaonaAlFOefZm0PZJb6ukg2XLk6d+MEcatSBbCm9PXZ1d9DEEb0Cmk8daLGjV5rYg==", "278c4f46-e177-4886-ac43-93f7c279bbe7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0ebf303-c9df-4c7c-b00e-4153e07d0a64", new DateTime(2023, 2, 14, 13, 55, 3, 654, DateTimeKind.Local).AddTicks(2379), "AQAAAAEAACcQAAAAEDauyW1gnQTShhn3TFrAuSC8+1m9iLWodYAyiL3jl3JeneE1fe1aDrFCOLq445U4Mw==", "7114df2a-12d0-4a07-a5b8-fcb1413c77f3" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_applicationUserId",
                table: "Comments",
                column: "applicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_postId",
                table: "Comments",
                column: "postId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
