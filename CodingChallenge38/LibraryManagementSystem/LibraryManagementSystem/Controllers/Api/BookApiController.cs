using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksApiController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksApiController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookRepository.GetAllWithDetailsAsync();
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _bookRepository.AddAsync(book);
                await _bookRepository.SaveAsync();
                return Ok(book);
            }
            catch (Exception)
            {
                // TODO: Add logging here
                return StatusCode(500, "Internal server error");
            }
        }

        // Add PUT and DELETE similarly
    }
}
