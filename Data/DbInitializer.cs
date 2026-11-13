using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PharmacyTrackerApi.Models;

namespace PharmacyTrackerApi.Data;

public static class DbInitializer
{
    public static void SeedData(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<PharmacyDbContext>();

        db.Database.Migrate();

        if (db.Patients.Any()) return;

        var jane = new Patient
        {
            FirstName = "Jane",
            LastName = "Doe",
            DateOfBirth = new DateOnly(1990, 5, 15),
            Prescriptions =
            [
                new Prescription
                {
                    MedicationName = "Amoxicillin",
                    Dosage = "500mg",
                    RefillsRemaining = 3
                },
                new Prescription
                {
                    MedicationName = "Lisinopril",
                    Dosage = "10mg",
                    RefillsRemaining = 1
                }
            ]
        };
        var john = new Patient
        {
            FirstName = "John",
            LastName = "Doe",
            DateOfBirth = new DateOnly(1985, 8, 22),
            Prescriptions =
            [
                new Prescription
                {
                    MedicationName = "Metformin",
                    Dosage = "500mg",
                    RefillsRemaining = 1
                }
            ]
        };
        db.Patients.AddRange(jane, john);
        db.SaveChanges();   
    }
}