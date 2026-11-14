using Microsoft.AspNetCore.Mvc;
using PharmacyTrackerApi.Models;
using PharmacyTrackerApi.DTOs;
using PharmacyTrackerApi.Services;

namespace PharmacyTrackerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController(PatientService service) : ControllerBase
{
    // GET: api/patients
    [HttpGet]
    public async Task<ActionResult<List<Patient>>> GetPatients()
    {
        return await service.GetPatientsAsync();
    }

    // POST: api/patients
    [HttpPost]
    public async Task<ActionResult<Patient>> CreatePatient(CreatePatientDto dto)
    {
        var patient = await service.CreatePatientAsync(dto);
        if (patient == null)
        {
            return BadRequest("Failed to create patient.");
        }
        return CreatedAtAction(nameof(GetPatients), new { id = patient.Id }, patient);
    }
}