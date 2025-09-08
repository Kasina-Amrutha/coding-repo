using Backend.Models;
//using FractoAPI.Data;
//using FractoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecializationsController : Controller
    {
        private readonly FractoDbContext _context;

        public SpecializationsController(FractoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _context.Specializations.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var specialization = await _context.Specializations.FindAsync(id);
            return specialization == null ? NotFound() : Ok(specialization);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Specialization specialization)
        {
            _context.Specializations.Add(specialization);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = specialization.SpecializationId }, specialization);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Specialization specialization)
        {
            if (id != specialization.SpecializationId) return BadRequest();
            _context.Entry(specialization).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var specialization = await _context.Specializations.FindAsync(id);
            if (specialization == null) return NotFound();
            _context.Specializations.Remove(specialization);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}