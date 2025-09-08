using Microsoft.AspNetCore.Mvc;
using LibrarySystem.Data;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly LibraryContext _context;
    public BooksController(LibraryContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> Get() =>
        await _context.Books.Include(b => b.Author).Include(b => b.Genres).ToListAsync();

    [HttpPost]
    public async Task<ActionResult<Book>> Post(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = book.BookId }, book);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Book book)
    {
        if (id != book.BookId) return BadRequest();
        _context.Entry(book).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null) return NotFound();
        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
