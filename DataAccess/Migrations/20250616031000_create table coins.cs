﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class createtablecoins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mentors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Auditorium = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pairs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MentorPairs",
                columns: table => new
                {
                    MentorsId = table.Column<int>(type: "integer", nullable: false),
                    MyPairsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorPairs", x => new { x.MentorsId, x.MyPairsId });
                    table.ForeignKey(
                        name: "FK_MentorPairs_Mentors_MentorsId",
                        column: x => x.MentorsId,
                        principalTable: "Mentors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MentorPairs_Pairs_MyPairsId",
                        column: x => x.MyPairsId,
                        principalTable: "Pairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "StudentPairs",
                columns: table => new
                {
                    MyPairsId = table.Column<int>(type: "integer", nullable: false),
                    StudentsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPairs", x => new { x.MyPairsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_StudentPairs_Pairs_MyPairsId",
                        column: x => x.MyPairsId,
                        principalTable: "Pairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentPairs_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coins_Id",
                table: "Coins",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MentorPairs_MyPairsId",
                table: "MentorPairs",
                column: "MyPairsId");

            migrationBuilder.CreateIndex(
                name: "IX_Mentors_Id",
                table: "Mentors",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pairs_Id",
                table: "Pairs",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCoins_StudentsId",
                table: "StudentCoins",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPairs_StudentsId",
                table: "StudentPairs",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Id",
                table: "Students",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MentorPairs");

            migrationBuilder.DropTable(
                name: "StudentCoins");

            migrationBuilder.DropTable(
                name: "StudentPairs");

            migrationBuilder.DropTable(
                name: "Mentors");

            migrationBuilder.DropTable(
                name: "Coins");

            migrationBuilder.DropTable(
                name: "Pairs");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
