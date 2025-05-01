using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class editdbv002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupMentor_Groups_GroupsId",
                table: "GroupMentor");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupMentor_Mentors_MentorsId",
                table: "GroupMentor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupMentor",
                table: "GroupMentor");

            migrationBuilder.RenameTable(
                name: "GroupMentor",
                newName: "GroupMentors");

            migrationBuilder.RenameIndex(
                name: "IX_GroupMentor_MentorsId",
                table: "GroupMentors",
                newName: "IX_GroupMentors_MentorsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupMentors",
                table: "GroupMentors",
                columns: new[] { "GroupsId", "MentorsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMentors_Groups_GroupsId",
                table: "GroupMentors",
                column: "GroupsId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMentors_Mentors_MentorsId",
                table: "GroupMentors",
                column: "MentorsId",
                principalTable: "Mentors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupMentors_Groups_GroupsId",
                table: "GroupMentors");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupMentors_Mentors_MentorsId",
                table: "GroupMentors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupMentors",
                table: "GroupMentors");

            migrationBuilder.RenameTable(
                name: "GroupMentors",
                newName: "GroupMentor");

            migrationBuilder.RenameIndex(
                name: "IX_GroupMentors_MentorsId",
                table: "GroupMentor",
                newName: "IX_GroupMentor_MentorsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupMentor",
                table: "GroupMentor",
                columns: new[] { "GroupsId", "MentorsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMentor_Groups_GroupsId",
                table: "GroupMentor",
                column: "GroupsId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMentor_Mentors_MentorsId",
                table: "GroupMentor",
                column: "MentorsId",
                principalTable: "Mentors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
