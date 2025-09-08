using Backend.Models;
//using FractoAPI.Data;
//using FractoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : Controller
    {
        private readonly FractoDbContext _context;

        public AppointmentsController(FractoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _context.Appointments
                .Include(a => a.User)
                .Include(a => a.Doctor)
                .ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var appointment = await _context.Appointments
                .Include(a => a.User)
                .Include(a => a.Doctor)
                .FirstOrDefaultAsync(a => a.AppointmentId == id);

            return appointment == null ? NotFound() : Ok(appointment);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = appointment.AppointmentId }, appointment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Appointment appointment)
        {
            if (id != appointment.AppointmentId) return BadRequest();
            _context.Entry(appointment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null) return NotFound();
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}