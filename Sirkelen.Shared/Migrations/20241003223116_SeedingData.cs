using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sirkelen.Shared.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Rank = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    ProfilePictureUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Height = table.Column<decimal>(type: "TEXT", nullable: true),
                    Weight = table.Column<decimal>(type: "TEXT", nullable: true),
                    JoinDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsAdmin = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SenderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ProfilePicture = table.Column<string>(type: "TEXT", nullable: true),
                    MediaUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ExerciseName = table.Column<string>(type: "TEXT", nullable: false),
                    Weight = table.Column<decimal>(type: "TEXT", nullable: false),
                    Reps = table.Column<int>(type: "INTEGER", nullable: false),
                    Sets = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalRecords_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeightRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Weight = table.Column<decimal>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeightRecords_Users_UserId",
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
                    { new Guid("19d74b5a-b751-4662-9491-e9b0c77e5cc4"), null, false, new DateTime(2024, 10, 4, 0, 31, 16, 317, DateTimeKind.Local).AddTicks(720), null, "Vuong", "$2a$11$qf7BhAkMVaW/rIplo3KAv.C3DTnAas6EdImzY27fuZsgDDq8TEwvS", null, null, "vuonguyen", null },
                    { new Guid("2a352af4-ca16-47d1-ac9a-b69b4dbb5e0f"), null, false, new DateTime(2024, 10, 4, 0, 31, 15, 882, DateTimeKind.Local).AddTicks(590), null, "Atle", "$2a$11$l4Ib1xjuH9dSUxriV4sz3.PJTUVPPFGRt71Bv5G.IFY0F1GzN7vz2", null, null, "atse02", null },
                    { new Guid("56d877e4-316e-4b7d-a473-831c305c6e67"), null, false, new DateTime(2024, 10, 4, 0, 31, 16, 172, DateTimeKind.Local).AddTicks(8920), null, "Sander", "$2a$11$AXKCRYeo3stBDUgLYyHPUeJXDIFj/Pd1Vuuyoh9gk3i4EyuF4YZEy", null, null, "sandercool", null },
                    { new Guid("a12fa66c-0a51-44d9-af73-728b35596642"), null, true, new DateTime(2024, 10, 4, 0, 31, 15, 733, DateTimeKind.Local).AddTicks(7650), null, "Alex", "$2a$11$zlttYoY/1Q6WJATLcgHADebaVx3O8ucX1aic9i4ruSgB9NlUqlsO2", null, null, "admin", null },
                    { new Guid("ea02dde6-d7d8-41ec-8566-507a853a1b58"), null, false, new DateTime(2024, 10, 4, 0, 31, 16, 28, DateTimeKind.Local).AddTicks(8120), null, "Brage", "$2a$11$a2SUyLX5NXgF2V/qmJ1tzudMYlXWlVh0aE9XuZyhW9tZrSZpGsTMu", null, null, "bragstern", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalRecords_UserId",
                table: "PersonalRecords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightRecords_UserId",
                table: "WeightRecords",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "PersonalRecords");

            migrationBuilder.DropTable(
                name: "WeightRecords");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
