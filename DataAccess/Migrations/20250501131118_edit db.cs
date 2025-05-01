using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class editdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pairs_Students_StudentId",
                table: "Pairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Mentors_MentorId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Pairs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Mentors");

            migrationBuilder.RenameColumn(
                name: "MentorId",
                table: "Students",
                newName: "MyPairId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_MentorId",
                table: "Students",
                newName: "IX_Students_MyPairId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Pairs",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Pairs_StudentId",
                table: "Pairs",
                newName: "IX_Pairs_GroupId");

            migrationBuilder.AddColumn<int>(
                name: "MyGroupId",
                table: "Students",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Auditorium",
                table: "Pairs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Pairs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Pairs",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupMentor",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "integer", nullable: false),
                    MentorsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMentor", x => new { x.GroupsId, x.MentorsId });
                    table.ForeignKey(
                        name: "FK_GroupMentor_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupMentor_Mentors_MentorsId",
                        column: x => x.MentorsId,
                        principalTable: "Mentors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_Email",
                table: "Students",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_MyGroupId",
                table: "Students",
                column: "MyGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Pairs_DateTime",
                table: "Pairs",
                column: "DateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Mentors_Email",
                table: "Mentors",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupMentor_MentorsId",
                table: "GroupMentor",
                column: "MentorsId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Pairs_MyPairId",
                table: "Students",
                column: "MyPairId",
                principalTable: "Pairs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pairs_Groups_GroupId",
                table: "Pairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_MyGroupId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Pairs_MyPairId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "GroupMentor");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Students_Email",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_MyGroupId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Pairs_DateTime",
                table: "Pairs");

            migrationBuilder.DropIndex(
                name: "IX_Mentors_Email",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "MyGroupId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Auditorium",
                table: "Pairs");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Pairs");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Pairs");

            migrationBuilder.RenameColumn(
                name: "MyPairId",
                table: "Students",
                newName: "MentorId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_MyPairId",
                table: "Students",
                newName: "IX_Students_MentorId");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Pairs",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Pairs_GroupId",
                table: "Pairs",
                newName: "IX_Pairs_StudentId");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Students",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Pairs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Mentors",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Pairs_Students_StudentId",
                table: "Pairs",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Mentors_MentorId",
                table: "Students",
                column: "MentorId",
                principalTable: "Mentors",
                principalColumn: "Id");
        }
    }
}
