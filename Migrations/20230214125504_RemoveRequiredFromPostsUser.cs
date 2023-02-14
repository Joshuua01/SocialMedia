using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Migrations
{
    public partial class RemoveRequiredFromPostsUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_applicationUserId",
                table: "Posts");

            migrationBuilder.AlterColumn<string>(
                name: "applicationUserId",
                table: "Posts",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

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

            migrationBuilder.AlterColumn<string>(
                name: "applicationUserId",
                table: "Posts",
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
                value: "7a5f80be-055e-43b3-923a-480cd6b79bef");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                column: "ConcurrencyStamp",
                value: "cd0105f1-037d-402f-aa8c-fae4440a6558");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87b6f587-ee3d-47dd-9001-01388a8cfe7e", new DateTime(2023, 2, 8, 22, 50, 42, 717, DateTimeKind.Local).AddTicks(5058), "AQAAAAEAACcQAAAAEE28HXmNkUlVP0Hbr1plLtgDXA0R3h8zq4opPzkVtak/wl7jEQM634iZ7B0mncynnA==", "7489910e-baf7-4d79-819f-315cd2796fb5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6de8978-4ffe-4059-b9d8-3c2086ea1c69", new DateTime(2023, 2, 8, 22, 50, 42, 709, DateTimeKind.Local).AddTicks(8026), "AQAAAAEAACcQAAAAEFXmou7t2i/MjkLR1JX/kC8iLtmmo7qIOjx72X06YkVQRzMQAB3kkX9tgYd41CyGNw==", "aa640e38-7123-434d-8aac-dcc10d24d304" });

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_applicationUserId",
                table: "Posts",
                column: "applicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
