using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaceDayAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    categoryID = table.Column<string>(type: "TEXT", nullable: false),
                    categoryName = table.Column<string>(type: "TEXT", nullable: false),
                    categoryDistance = table.Column<decimal>(type: "TEXT", nullable: false),
                    entryFee = table.Column<decimal>(type: "TEXT", nullable: false),
                    eventID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.categoryID);
                });

            migrationBuilder.CreateTable(
                name: "Organisers",
                columns: table => new
                {
                    organiserID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    organiserName = table.Column<string>(type: "TEXT", nullable: false),
                    organiserSurname = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    phoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    passwordHash = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisers", x => x.organiserID);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    participantID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    participantName = table.Column<string>(type: "TEXT", nullable: false),
                    participantSurname = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    phoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    passwordHash = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.participantID);
                });

            migrationBuilder.CreateTable(
                name: "RaceEvents",
                columns: table => new
                {
                    eventID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    eventName = table.Column<string>(type: "TEXT", nullable: false),
                    eventDescription = table.Column<string>(type: "TEXT", nullable: false),
                    eventDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    eventLocation = table.Column<string>(type: "TEXT", nullable: false),
                    eventDistance = table.Column<decimal>(type: "TEXT", nullable: false),
                    eventType = table.Column<string>(type: "TEXT", nullable: false),
                    organiserID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceEvents", x => x.eventID);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    registrationID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    registrationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    registrationChannel = table.Column<string>(type: "TEXT", nullable: false),
                    participantID = table.Column<int>(type: "INTEGER", nullable: false),
                    eventID = table.Column<int>(type: "INTEGER", nullable: false),
                    categoryID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.registrationID);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    resultID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    position = table.Column<int>(type: "INTEGER", nullable: false),
                    participantStatus = table.Column<string>(type: "TEXT", nullable: false),
                    finishTime = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    registrationID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.resultID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Organisers");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "RaceEvents");

            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Results");
        }
    }
}
