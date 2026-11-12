using Microsoft.AspNetCore.Mvc;
using PharmacyTrackerApi.Data;
using PharmacyTrackerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace PharmacyTrackerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionController(PharmacyDbContext context) : ControllerBase
{
    // GET: api/Prescriptions
    [HttpGet]
    public async Task<ActionResult<List<Prescription>>> GetPrescriptions()
    {
        return await context.Prescriptions.ToListAsync();
    }

    // POST: api/Prescriptions
    [HttpPost]
    public async Task<ActionResult<Prescription>> CreatePrescription(Prescription rx)
    {
        context.Prescriptions.Add(rx);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPrescriptions), new {id = rx.Id}, rx);
    }

    // PUT: api/Prescriptions/1/refill
    [HttpPut("{id}/refill")]
    public async Task<IActionResult> RefillPrescription(int id)
    {
        var rx = await context.Prescriptions.FindAsync(id);
        if (rx is null) return NotFound();
        if (rx.RefillsRemaining <= 0) return BadRequest("No refills remaining");
        rx.RefillsRemaining--;
        await context.SaveChangesAsync();
        return Ok(rx);
    }
}