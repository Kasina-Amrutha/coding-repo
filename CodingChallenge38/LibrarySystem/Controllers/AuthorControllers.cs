using Microsoft.AspNetCore.Mvc;
using LibrarySystem.Data;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly LibraryContext _context;
    public AuthorsController(LibraryContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Author>>> Get() =>
        await _context.Authors.Include(a => a.Books).ToListAsync();

    [HttpPost]
    public async Task<ActionResult<Author>> Post(Author author)
    {
        _context.Authors.Add(author);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = author.AuthorId }, author);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Author author)
    {
        if (id != author.AuthorId) return BadRequest();
        _context.Entry(author).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var author = await _context.Authors.FindAsync(id);
        if (author == null) return NotFound();
        _context.Authors.Remove(author);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
