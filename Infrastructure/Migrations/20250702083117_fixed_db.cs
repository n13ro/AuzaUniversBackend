using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixed_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pairs_Students_StudentId",
                table: "Pairs");

            migrationBuilder.DropIndex(
                name: "IX_Pairs_StudentId",
                table: "Pairs");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Pairs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Pairs",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pairs_StudentId",
                table: "Pairs",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pairs_Students_StudentId",
                table: "Pairs",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
