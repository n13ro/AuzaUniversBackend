using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fix_amount_coin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCoins");

            migrationBuilder.AddColumn<int>(
                name: "CoinBalnce",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CoinId",
                table: "Students",
                type: "integer",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Coins_CoinId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_CoinId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CoinBalnce",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CoinId",
                table: "Students");

            migrationBuilder.CreateTable(
                name: "StudentCoins",
                columns: table => new
                {
                    CoinsId = table.Column<int>(type: "integer", nullable: false),
                    StudentsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCoins", x => new { x.CoinsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_StudentCoins_Coins_CoinsId",
                        column: x => x.CoinsId,
                        principalTable: "Coins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCoins_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCoins_StudentsId",
                table: "StudentCoins",
                column: "StudentsId");
        }
    }
}
