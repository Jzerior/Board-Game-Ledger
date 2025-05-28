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
                    { "c3260109-da12-4119-adef-d104267deeed", null, "Admin", "ADMIN" },
                    { "f882e27e-89e8-4c15-bad0-7ae1f430e893", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3260109-da12-4119-adef-d104267deeed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f882e27e-89e8-4c15-bad0-7ae1f430e893");

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
