using Microsoft.AspNetCore.Mvc;
using LibrarySystem.Data;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class GenresController : ControllerBase
{
    private readonly LibraryContext _context;
    public GenresController(LibraryContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Genre>>> Get() =>
        await _context.Genres.Include(g => g.Books).ToListAsync();

    [HttpPost]
    public async Task<ActionResult<Genre>> Post(Genre genre)
    {
        _context.Genres.Add(genre);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = genre.GenreId }, genre);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Genre genre)
    {
        if (id != genre.GenreId) return BadRequest();
        _context.Entry(genre).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var genre = await _context.Genres.FindAsync(id);
        if (genre == null) return NotFound();
        _context.Genres.Remove(genre);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
