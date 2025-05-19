using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Board_Game_Ledger.Migrations
{
    /// <inheritdoc />
    public partial class DataEncapsulatedToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23992f28-3d95-4252-a2cc-276c6b8e8aa1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81831018-14ef-4d9c-ae55-956895114748");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Players",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "GameSessions",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "BoardGames",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a276f8b-09fc-4093-8d37-0aa162971c69", null, "Admin", "ADMIN" },
                    { "0ecce5f5-400d-4e90-abae-8f4911f28e47", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_AppUserId",
                table: "Players",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GameSessions_AppUserId",
                table: "GameSessions",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGames_AppUserId",
                table: "BoardGames",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGames_AspNetUsers_AppUserId",
                table: "BoardGames",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameSessions_AspNetUsers_AppUserId",
                table: "GameSessions",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_AspNetUsers_AppUserId",
                table: "Players",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardGames_AspNetUsers_AppUserId",
                table: "BoardGames");

            migrationBuilder.DropForeignKey(
                name: "FK_GameSessions_AspNetUsers_AppUserId",
                table: "GameSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_AspNetUsers_AppUserId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_AppUserId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_GameSessions_AppUserId",
                table: "GameSessions");

            migrationBuilder.DropIndex(
                name: "IX_BoardGames_AppUserId",
                table: "BoardGames");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a276f8b-09fc-4093-8d37-0aa162971c69");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ecce5f5-400d-4e90-abae-8f4911f28e47");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "GameSessions");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "BoardGames");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23992f28-3d95-4252-a2cc-276c6b8e8aa1", null, "User", "USER" },
                    { "81831018-14ef-4d9c-ae55-956895114748", null, "Admin", "ADMIN" }
                });
        }
    }
}
