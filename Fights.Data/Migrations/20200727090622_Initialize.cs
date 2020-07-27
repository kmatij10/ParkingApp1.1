using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fights.Data.Migrations
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
                name: "Organizers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Phone = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizers", x => x.Id);
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
                    CityId = table.Column<long>(nullable: false),
                    OrganizerId = table.Column<long>(nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Protests_Organizers_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Organizers",
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
                values: new object[,]
                {
                    { 1L, "Zagreb", new DateTime(2020, 7, 27, 11, 6, 22, 43, DateTimeKind.Local).AddTicks(5250) },
                    { 2L, "Široki", new DateTime(2020, 7, 27, 11, 6, 22, 54, DateTimeKind.Local).AddTicks(5210) }
                });

            migrationBuilder.InsertData(
                table: "Organizers",
                columns: new[] { "Id", "CreatedAt", "Name", "Phone" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 7, 27, 11, 6, 22, 56, DateTimeKind.Local).AddTicks(2680), "David", null },
                    { 2L, new DateTime(2020, 7, 27, 11, 6, 22, 56, DateTimeKind.Local).AddTicks(3540), "SDP", null }
                });

            migrationBuilder.InsertData(
                table: "Protests",
                columns: new[] { "Id", "CityId", "CreatedAt", "Description", "OrganizerId", "StartsAt", "Title" },
                values: new object[] { 1L, 1L, new DateTime(2020, 7, 27, 11, 6, 22, 56, DateTimeKind.Local).AddTicks(5090), "Description 1", 1L, new DateTime(2020, 8, 1, 11, 6, 22, 56, DateTimeKind.Local).AddTicks(6070), "Title 1" });

            migrationBuilder.InsertData(
                table: "Protests",
                columns: new[] { "Id", "CityId", "CreatedAt", "Description", "OrganizerId", "StartsAt", "Title" },
                values: new object[] { 2L, 2L, new DateTime(2020, 7, 27, 11, 6, 22, 56, DateTimeKind.Local).AddTicks(7520), "Description 2", 2L, new DateTime(2020, 8, 11, 11, 6, 22, 56, DateTimeKind.Local).AddTicks(7560), "David predvodi u Širokom prosvjed" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentText", "CreatedAt", "ProtestId" },
                values: new object[] { 1L, "Comment 1", new DateTime(2020, 7, 27, 11, 6, 22, 56, DateTimeKind.Local).AddTicks(8960), 1L });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentText", "CreatedAt", "ProtestId" },
                values: new object[] { 2L, "Comment 1", new DateTime(2020, 7, 27, 11, 6, 22, 56, DateTimeKind.Local).AddTicks(9890), 1L });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentText", "CreatedAt", "ProtestId" },
                values: new object[] { 3L, "Comment 1", new DateTime(2020, 7, 27, 11, 6, 22, 56, DateTimeKind.Local).AddTicks(9920), 2L });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProtestId",
                table: "Comments",
                column: "ProtestId");

            migrationBuilder.CreateIndex(
                name: "IX_Protests_CityId",
                table: "Protests",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Protests_OrganizerId",
                table: "Protests",
                column: "OrganizerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Protests");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Organizers");
        }
    }
}
