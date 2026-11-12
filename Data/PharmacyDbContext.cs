using Microsoft.EntityFrameworkCore;
using PharmacyTrackerApi.Models;

namespace PharmacyTrackerApi.Data;

public class PharmacyDbContext(DbContextOptions<PharmacyDbContext> options) : DbContext(options)
{
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Prescription> Prescriptions => Set<Prescription>();
}
