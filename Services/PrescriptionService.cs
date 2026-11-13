using Microsoft.EntityFrameworkCore;
using PharmacyTrackerApi.DTOs;
using PharmacyTrackerApi.Models;
using PharmacyTrackerApi.Data;

namespace PharmacyTrackerApi.Services;

public class PrescriptionService(PharmacyDbContext context)
{
    public async Task<List<Prescription>> GetPrescriptionsAsync()
    {
        return await context.Prescriptions.ToListAsync();
    }

    public async Task<Prescription?> CreatePrescriptionAsync(CreatePrescriptionDto dto)
    {
        var patientExists = await context.Patients.AnyAsync(p => p.Id == dto.PatientId);
        if (!patientExists) return null;
        var rx = new Prescription
        {
            MedicationName = dto.MedicationName, 
            Dosage = dto.Dosage, 
            RefillsRemaining = dto.RefillsRemaining,
            PatientId = dto.PatientId
        };
        
        context.Prescriptions.Add(rx);
        await context.SaveChangesAsync();
        return rx;
    }

    public async Task<Prescription?> RefillPrescriptionAsync(int id)
    {
        var rx = await context.Prescriptions.FindAsync(id);
        if (rx is null || rx.RefillsRemaining <= 0) return null;

        rx.RefillsRemaining--;
        await context.SaveChangesAsync();
        return rx;
    }
}