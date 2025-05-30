using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Board_Game_Ledger.Migrations
{
    /// <inheritdoc />
    public partial class modelsimprovement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a276f8b-09fc-4093-8d37-0aa162971c69");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ecce5f5-400d-4e90-abae-8f4911f28e47");

            migrationBuilder.AddColumn<string>(
                name: "AssociatedUserId",
                table: "Players",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "GameSessions",
                type: "TEXT",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Faction",
                table: "GameSessionPlayers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "IsWinner",
                table: "GameSessionPlayers",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "359798e3-96e6-433f-8336-6bb30a30d272", null, "User", "USER" },
                    { "ec5aabca-eb3a-40b1-abc4-48ed9b725a06", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_AssociatedUserId",
                table: "Players",
                column: "AssociatedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_AspNetUsers_AssociatedUserId",
                table: "Players",
                column: "AssociatedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_AspNetUsers_AssociatedUserId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_AssociatedUserId",
                table: "Players");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "359798e3-96e6-433f-8336-6bb30a30d272");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec5aabca-eb3a-40b1-abc4-48ed9b725a06");

            migrationBuilder.DropColumn(
                name: "AssociatedUserId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "GameSessions");

            migrationBuilder.DropColumn(
                name: "Faction",
                table: "GameSessionPlayers");

            migrationBuilder.DropColumn(
                name: "IsWinner",
                table: "GameSessionPlayers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a276f8b-09fc-4093-8d37-0aa162971c69", null, "Admin", "ADMIN" },
                    { "0ecce5f5-400d-4e90-abae-8f4911f28e47", null, "User", "USER" }
                });
        }
    }
}
