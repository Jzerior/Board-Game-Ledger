using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Board_Game_Ledger.Migrations
{
    /// <inheritdoc />
    public partial class GameSessionCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameSessionPlayers_Players_PlayerId",
                table: "GameSessionPlayers");

            migrationBuilder.AddForeignKey(
                name: "FK_GameSessionPlayers_Players_PlayerId",
                table: "GameSessionPlayers",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameSessionPlayers_Players_PlayerId",
                table: "GameSessionPlayers");

            migrationBuilder.AddForeignKey(
                name: "FK_GameSessionPlayers_Players_PlayerId",
                table: "GameSessionPlayers",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
