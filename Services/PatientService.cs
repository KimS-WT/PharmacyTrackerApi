using Microsoft.EntityFrameworkCore;
using PharmacyTrackerApi.Data;
using PharmacyTrackerApi.DTOs;
using PharmacyTrackerApi.Models;

namespace PharmacyTrackerApi.Services;

// private readonly PharmacyDbContext _context = context;
public class PatientService(PharmacyDbContext context)
{
    public async Task<List<Patient>> GetPatientsAsync()
    {
        return await context.Patients.ToListAsync();
    }

    public async Task<Patient?> CreatePatientAsync(CreatePatientDto dto)
    {
        var patient = new Patient
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            DateOfBirth = dto.DateOfBirth
        };

        context.Patients.Add(patient);
        await context.SaveChangesAsync();
        return patient;
    }
}