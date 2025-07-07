using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fix_coinID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Coins_CoinId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_CoinId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CoinId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Coins");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoinId",
                table: "Students",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Coins",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_CoinId",
                table: "Students",
                column: "CoinId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Coins_CoinId",
                table: "Students",
                column: "CoinId",
                principalTable: "Coins",
                principalColumn: "Id");
        }
    }
}
