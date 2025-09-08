using Backend.Models;
//using FractoAPI.Data;
//using FractoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : Controller
    {
        private readonly FractoDbContext _context;

        public DoctorsController(FractoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _context.Doctors.Include(d => d.Specialization).ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var doctor = await _context.Doctors.Include(d => d.Specialization).FirstOrDefaultAsync(d => d.DoctorId == id);
            return doctor == null ? NotFound() : Ok(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = doctor.DoctorId }, doctor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Doctor doctor)
        {
            if (id != doctor.DoctorId) return BadRequest();
            _context.Entry(doctor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null) return NotFound();
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}