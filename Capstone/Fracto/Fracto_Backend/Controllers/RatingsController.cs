using Backend.Models;
//using FractoAPI.Data;
//using FractoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingsController : Controller
    {
        private readonly FractoDbContext _context;

        public RatingsController(FractoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _context.Ratings
                .Include(r => r.User)
                .Include(r => r.Doctor)
                .ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rating = await _context.Ratings
                .Include(r => r.User)
                .Include(r => r.Doctor)
                .FirstOrDefaultAsync(r => r.RatingId == id);

            return rating == null ? NotFound() : Ok(rating);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Rating rating)
        {
            _context.Ratings.Add(rating);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = rating.RatingId }, rating);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Rating rating)
        {
            if (id != rating.RatingId) return BadRequest();
            _context.Entry(rating).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rating = await _context.Ratings.FindAsync(id);
            if (rating == null) return NotFound();
            _context.Ratings.Remove(rating);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}