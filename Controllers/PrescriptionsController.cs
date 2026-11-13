using Microsoft.AspNetCore.Mvc;
using PharmacyTrackerApi.Models;
using PharmacyTrackerApi.DTOs;
using PharmacyTrackerApi.Services;

namespace PharmacyTrackerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionsController(PrescriptionService service) : ControllerBase
{
    // GET: api/Prescriptions
    [HttpGet]
    public async Task<ActionResult<List<Prescription>>> GetPrescriptions()
    {
        return Ok(await service.GetPrescriptionsAsync());
    }

    // POST: api/Prescriptions
    [HttpPost]
    public async Task<ActionResult<Prescription>> CreatePrescription(CreatePrescriptionDto dto)
    {
        var rx = await service.CreatePrescriptionAsync(dto);
        if (rx is null) return BadRequest("Patient does not exist. ");
        return CreatedAtAction(nameof(GetPrescriptions), new {id = rx.Id}, rx);
    }

    // PUT: api/Prescriptions/1/refill
    [HttpPut("{id}/refill")]
    public async Task<IActionResult> RefillPrescription(int id)
    {
        var rx = await service.RefillPrescriptionAsync(id);
        if (rx is null) return BadRequest("No refills remaining");
        return Ok(rx);
    }
}