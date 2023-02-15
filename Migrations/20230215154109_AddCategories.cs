using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Migrations
{
    public partial class AddCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "Posts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Posts_categoryId",
                table: "Posts",
                column: "categoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_categoryId",
                table: "Posts",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_categoryId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Posts_categoryId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "Posts");

            migrationBuilder.CreateTable(
                name: "Reactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ApplicationUserId = table.Column<string>(type: "TEXT", nullable: false),
                    PostId = table.Column<int>(type: "INTEGER", nullable: false),
                    reactionType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reactions_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reactions_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_ApplicationUserId",
                table: "Reactions",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_PostId",
                table: "Reactions",
                column: "PostId");
        }
    }
}
