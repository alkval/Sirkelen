using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sirkelen.Shared.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserUser");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("116763b5-6ba5-4be4-8987-bbcbbc9c292f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("50db4520-9156-4b85-8d12-2332391064f9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6a13a748-54dc-47fc-a9e2-67e234178c78"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d54653cd-edcc-4431-bf2a-a1abcfb17d46"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ee2490bd-79ad-4b11-98d5-560f0af6e711"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Height", "IsAdmin", "JoinDate", "LastLogin", "Name", "PasswordHash", "ProfilePictureUrl", "Rank", "Username", "Weight" },
                values: new object[,]
                {
                    { new Guid("01425677-1175-4b86-b52e-76efaabb2757"), null, false, new DateTime(2024, 10, 3, 18, 12, 42, 462, DateTimeKind.Local).AddTicks(7150), null, "Brage", "$2a$11$Sjito3vGqC/mqOHT6RI1jurQXTtyuqRgBXtF2WPSAyX6LITLOX4hi", null, null, "bragstern", null },
                    { new Guid("13dd31fe-5f3b-4a5d-9a54-f7792258e343"), null, false, new DateTime(2024, 10, 3, 18, 12, 42, 316, DateTimeKind.Local).AddTicks(8100), null, "Atle", "$2a$11$4dbrPjeuVTndNcit447J8OTXVHbR0RNqnUuMEZeE3EAlJxgTNSTmC", null, null, "atse02", null },
                    { new Guid("4117473c-ec8a-4558-92a0-d4e81fd93979"), null, true, new DateTime(2024, 10, 3, 18, 12, 42, 167, DateTimeKind.Local).AddTicks(5270), null, "Alex", "$2a$11$7BYgs2gUCqrhWus4S2kWo.itgGrBlsHPZFqqQBWbiwXiObEfMMQxm", null, null, "admin", null },
                    { new Guid("4e431693-feb8-4a5f-b3e8-78920e576bc6"), null, false, new DateTime(2024, 10, 3, 18, 12, 42, 606, DateTimeKind.Local).AddTicks(8570), null, "Sander", "$2a$11$v2nyp3/luXeR/cuSDwrAl.3PRZrhm8RTKoam0RwNaadKAsA/k.t2W", null, null, "sandercool", null },
                    { new Guid("57b782cc-141b-4055-8ecd-9a48ee409709"), null, false, new DateTime(2024, 10, 3, 18, 12, 42, 751, DateTimeKind.Local).AddTicks(670), null, "Vuong", "$2a$11$/2fOZnf4BgFkWsWvjZIueeekAxP/INdeJqj/V9VUoXdLaQQLt6ft2", null, null, "vuonguyen", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("01425677-1175-4b86-b52e-76efaabb2757"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13dd31fe-5f3b-4a5d-9a54-f7792258e343"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4117473c-ec8a-4558-92a0-d4e81fd93979"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4e431693-feb8-4a5f-b3e8-78920e576bc6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("57b782cc-141b-4055-8ecd-9a48ee409709"));

            migrationBuilder.CreateTable(
                name: "UserUser",
                columns: table => new
                {
                    FriendsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUser", x => new { x.FriendsId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserUser_Users_FriendsId",
                        column: x => x.FriendsId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Height", "IsAdmin", "JoinDate", "LastLogin", "Name", "PasswordHash", "ProfilePictureUrl", "Rank", "Username", "Weight" },
                values: new object[,]
                {
                    { new Guid("116763b5-6ba5-4be4-8987-bbcbbc9c292f"), null, false, new DateTime(2024, 10, 3, 17, 18, 20, 595, DateTimeKind.Local).AddTicks(2210), null, "Brage", "$2a$11$QbbW7MJN1S19Ths8VXzt1.0xNj4lZpkjR2G2Y02YnS3TBEmnI/kJS", null, null, "bragstern", null },
                    { new Guid("50db4520-9156-4b85-8d12-2332391064f9"), null, false, new DateTime(2024, 10, 3, 17, 18, 20, 874, DateTimeKind.Local).AddTicks(3860), null, "Vuong", "$2a$11$1euBcOOJYPeuJZz33o5wi.oNDcvUvozu0RqY.VoDc1AEFWuuZjgmO", null, null, "vuonguyen", null },
                    { new Guid("6a13a748-54dc-47fc-a9e2-67e234178c78"), null, false, new DateTime(2024, 10, 3, 17, 18, 20, 452, DateTimeKind.Local).AddTicks(7020), null, "Atle", "$2a$11$V9EPvfQR9h6MGicKvi5y5OMkfhazbylC.MWgaSlRggZrdygXH3dki", null, null, "atse02", null },
                    { new Guid("d54653cd-edcc-4431-bf2a-a1abcfb17d46"), null, true, new DateTime(2024, 10, 3, 17, 18, 20, 310, DateTimeKind.Local).AddTicks(1670), null, "Alex", "$2a$11$1ykGNfNkLuTOTFVrkyIVFeoLJ8UlQ8WphAH9R9C6dJRnc51MksxiO", null, null, "admin", null },
                    { new Guid("ee2490bd-79ad-4b11-98d5-560f0af6e711"), null, false, new DateTime(2024, 10, 3, 17, 18, 20, 734, DateTimeKind.Local).AddTicks(6700), null, "Sander", "$2a$11$7fCp5qFF0Yvu/MLCA4bJMustakdueJ0w8titi5UGJbUTBSkpvHQeK", null, null, "sandercool", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserUser_UserId",
                table: "UserUser",
                column: "UserId");
        }
    }
}
