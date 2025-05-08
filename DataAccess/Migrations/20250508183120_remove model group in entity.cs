using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class removemodelgroupinentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Group_MyGroupId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "MyGroupId",
                table: "Students",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_MyGroupId",
                table: "Students",
                newName: "IX_Students_GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Group_GroupId",
                table: "Students",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Group_GroupId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Students",
                newName: "MyGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                newName: "IX_Students_MyGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Group_MyGroupId",
                table: "Students",
                column: "MyGroupId",
                principalTable: "Group",
                principalColumn: "Id");
        }
    }
}
