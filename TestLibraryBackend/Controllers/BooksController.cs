using Microsoft.AspNetCore.Mvc;
using TestLibraryBackend.Services;
using TestLibraryBackend.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestLibraryBackend.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService) {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks() {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id) {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null) {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> AddBook(BookDto bookDto) {
            var addedBook = await _bookService.AddBookAsync(bookDto);
            return CreatedAtAction(nameof(GetBook), new { id = addedBook.Id }, addedBook);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookDto bookDto) {
            if (id != bookDto.Id) {
                return BadRequest();
            }
            await _bookService.UpdateBookAsync(bookDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id) {
            await _bookService.DeleteBookAsync(id);
            return NoContent();
        }
    }
}