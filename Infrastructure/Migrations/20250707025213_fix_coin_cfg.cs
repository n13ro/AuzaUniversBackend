using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fix_coin_cfg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Coins",
                table: "Coins");

            migrationBuilder.DropIndex(
                name: "IX_Coins_Id",
                table: "Coins");

            migrationBuilder.RenameTable(
                name: "Coins",
                newName: "Coin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coin",
                table: "Coin",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Coin",
                table: "Coin");

            migrationBuilder.RenameTable(
                name: "Coin",
                newName: "Coins");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coins",
                table: "Coins",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Coins_Id",
                table: "Coins",
                column: "Id");
        }
    }
}
