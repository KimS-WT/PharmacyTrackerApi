using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmacyTrackerApi.Migrations;

/// <inheritdoc />
public partial class _20261112191311_InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Patients",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                FirstName = table.Column<string>(type: "TEXT", nullable: false),
                LastName = table.Column<string>(type: "TEXT", nullable: false),
                DateOfBirth = table.Column<DateOnly>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Patients", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Prescriptions",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                MedicationName = table.Column<string>(type: "TEXT", nullable: false),
                Dosage = table.Column<string>(type: "TEXT", nullable: false),
                RefillsRemaining = table.Column<int>(type: "INTEGER", nullable: false),
                PatientId = table.Column<int>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Prescriptions", x => x.Id);
                table.ForeignKey(
                    name: "FK_Prescriptions_Patients_PatientId",
                    column: x => x.PatientId,
                    principalTable: "Patients",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Prescriptions_PatientId",
            table: "Prescriptions",
            column: "PatientId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Prescriptions");

        migrationBuilder.DropTable(
            name: "Patients");
    }
}
