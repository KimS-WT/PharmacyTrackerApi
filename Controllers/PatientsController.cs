using Microsoft.AspNetCore.Mvc;
using PharmacyTrackerApi.Data;
using PharmacyTrackerApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;

namespace PharmacyTrackerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController(PharmacyDbContext context) : ControllerBase
{
    // GET: api/patients
    [HttpGet]
    public async Task<ActionResult<List<Patient>>> GetPatients()
    {
        return await context.Patients
        .Include(p => p.Prescriptions) // Eager Loading- EF Core performs a SQL LEFT JOIN between Patients and Prescriptions, populating each patient's prescriptions array automatically in the JSON response(foreign key info is shown now)
        .ToListAsync();
    }

    // POST: api/patients
    [HttpPost]
    public async Task<ActionResult<Patient>> CreatePatient(Patient patient)
    {
        context.Patients.Add(patient);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPatients), new { id = patient.Id }, patient);
    }
}