using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class removemodelgroupindb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupMentor_Groups_GroupsId",
                table: "GroupMentor");

            migrationBuilder.DropForeignKey(
                name: "FK_Pairs_Groups_GroupId",
                table: "Pairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_MyGroupId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Group");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMentor_Group_GroupsId",
                table: "GroupMentor",
                column: "GroupsId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pairs_Group_GroupId",
                table: "Pairs",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Group_MyGroupId",
                table: "Students",
                column: "MyGroupId",
                principalTable: "Group",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupMentor_Group_GroupsId",
                table: "GroupMentor");

            migrationBuilder.DropForeignKey(
                name: "FK_Pairs_Group_GroupId",
                table: "Pairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Group_MyGroupId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Groups");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMentor_Groups_GroupsId",
                table: "GroupMentor",
                column: "GroupsId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pairs_Groups_GroupId",
                table: "Pairs",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_MyGroupId",
                table: "Students",
                column: "MyGroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }
    }
}
