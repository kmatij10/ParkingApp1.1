using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Protests.Data.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Protests",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(maxLength: 10000, nullable: false),
                    StartsAt = table.Column<DateTime>(nullable: false),
                    CityId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Protests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Protests_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CommentText = table.Column<string>(maxLength: 2048, nullable: false),
                    ProtestId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Protests_ProtestId",
                        column: x => x.ProtestId,
                        principalTable: "Protests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityName", "CreatedAt" },
                values: new object[] { 1L, "Zagreb", new DateTime(2020, 7, 27, 9, 58, 2, 384, DateTimeKind.Local).AddTicks(7420) });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityName", "CreatedAt" },
                values: new object[] { 2L, "Široki", new DateTime(2020, 7, 27, 9, 58, 2, 394, DateTimeKind.Local).AddTicks(4860) });

            migrationBuilder.InsertData(
                table: "Protests",
                columns: new[] { "Id", "CityId", "CreatedAt", "Description", "StartsAt", "Title" },
                values: new object[] { 1L, 1L, new DateTime(2020, 7, 27, 9, 58, 2, 396, DateTimeKind.Local).AddTicks(100), "Description 1", new DateTime(2020, 8, 1, 9, 58, 2, 396, DateTimeKind.Local).AddTicks(1540), "Title 1" });

            migrationBuilder.InsertData(
                table: "Protests",
                columns: new[] { "Id", "CityId", "CreatedAt", "Description", "StartsAt", "Title" },
                values: new object[] { 2L, 2L, new DateTime(2020, 7, 27, 9, 58, 2, 396, DateTimeKind.Local).AddTicks(2610), "Description 2", new DateTime(2020, 8, 11, 9, 58, 2, 396, DateTimeKind.Local).AddTicks(2640), "David predvodi u Širokom prosvjed" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentText", "CreatedAt", "ProtestId" },
                values: new object[] { 1L, "Comment 1", new DateTime(2020, 7, 27, 9, 58, 2, 396, DateTimeKind.Local).AddTicks(4110), 1L });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentText", "CreatedAt", "ProtestId" },
                values: new object[] { 2L, "Comment 1", new DateTime(2020, 7, 27, 9, 58, 2, 396, DateTimeKind.Local).AddTicks(5060), 1L });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentText", "CreatedAt", "ProtestId" },
                values: new object[] { 3L, "Comment 1", new DateTime(2020, 7, 27, 9, 58, 2, 396, DateTimeKind.Local).AddTicks(5090), 2L });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProtestId",
                table: "Comments",
                column: "ProtestId");

            migrationBuilder.CreateIndex(
                name: "IX_Protests_CityId",
                table: "Protests",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Protests");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
