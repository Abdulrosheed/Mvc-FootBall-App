using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace FootballWebApp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ClubName = table.Column<string>(type: "Varchar(20)", nullable: false),
                    ClubManagerName = table.Column<string>(type: "text", nullable: true),
                    StadiumName = table.Column<string>(type: "Varchar(20)", nullable: false),
                    StadiumCapacity = table.Column<int>(type: "int", nullable: false),
                    ClubCoachName = table.Column<string>(type: "text", nullable: true),
                    ClubNickName = table.Column<string>(type: "Varchar(20)", nullable: false),
                    ClubRegistrationNumber = table.Column<string>(type: "Varchar(20)", nullable: false),
                    ClubBiggestRival = table.Column<string>(type: "varchar(40)", nullable: false),
                    ClubNumberOfTrophies = table.Column<int>(type: "int(20)", nullable: false),
                    ClubFoundationDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sponsorer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(30)", nullable: false),
                    NetWorth = table.Column<decimal>(type: "decimal(30)", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "varchar(40)", nullable: false),
                    SponsorerNumberOfCompanies = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsorer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "Varchar(20)", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "Varchar(20)", nullable: false),
                    JerseyNumber = table.Column<int>(type: "int(20)", nullable: false),
                    PlayingPosition = table.Column<string>(type: "varchar(20)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "DateTime(6)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    WeeklySalary = table.Column<decimal>(type: "decimal(50)", nullable: false),
                    PlayerPhoto = table.Column<string>(type: "Varchar(50)", nullable: true),
                    ContractExpiryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    StrongFoot = table.Column<string>(type: "varchar(20)", nullable: false),
                    Nationality = table.Column<string>(type: "Varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClubSponsorers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    SponsorerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubSponsorers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClubSponsorers_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClubSponsorers_Sponsorer_SponsorerId",
                        column: x => x.SponsorerId,
                        principalTable: "Sponsorer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_ClubName",
                table: "Clubs",
                column: "ClubName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_ClubNickName",
                table: "Clubs",
                column: "ClubNickName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_ClubRegistrationNumber",
                table: "Clubs",
                column: "ClubRegistrationNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_StadiumName",
                table: "Clubs",
                column: "StadiumName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClubSponsorers_ClubId",
                table: "ClubSponsorers",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubSponsorers_SponsorerId",
                table: "ClubSponsorers",
                column: "SponsorerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_ClubId",
                table: "Players",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_Email",
                table: "Players",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerPhoto",
                table: "Players",
                column: "PlayerPhoto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sponsorer_Name",
                table: "Sponsorer",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sponsorer_RegistrationNumber",
                table: "Sponsorer",
                column: "RegistrationNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClubSponsorers");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Sponsorer");

            migrationBuilder.DropTable(
                name: "Clubs");
        }
    }
}
