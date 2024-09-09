using Assignment7.Application.Interfaces;
using Assignment7.Domain.Entities;
using Assignment7.Domain.Helpers;
using Assignment7.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Assignment7.Application.Dtos;
using Assignment7.Application.Mappers;

namespace Assignment7.WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookService _bookService;

        public BookController(IBookRepository bookRepository, IBookService bookServices)
        {
            _bookRepository = bookRepository;
            _bookService = bookServices;
        }
        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await _bookRepository.GetAllBooks();
            var bookDto = books.Select(b => b.ToBookDto()).ToList();
            return Ok(bookDto);
        }
        [Authorize(Roles = "User")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var book = await _bookRepository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            var bookDto = book.ToBookDto();
            return Ok(bookDto);
        }
        [Authorize(Roles = "Librarian, Library Manager")]
        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(Book book)
        {
            var createdBook = await _bookRepository.AddBook(book);
            return Ok(createdBook);
        }
        [Authorize(Roles = "Librarian, Library Manager")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book book)
        {
            if (id != book.Id) return BadRequest();

            var createdBook = await _bookRepository.UpdateBook(book);
            var bookDto = createdBook.ToBookDto();
            return Ok(bookDto);
        }
        [Authorize(Roles = "Librarian, Library Manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var deleted = await _bookRepository.DeleteBook(id);
            if (!deleted)
            {
                return NotFound();
            }
            return Ok("Buku telah dihapus");
        }
        [Authorize(Roles = "User")]
        [HttpGet("search-book")]
        public async Task<ActionResult<IEnumerable<Book>>> SearchBookAsync([FromQuery] QueryObject query, [FromQuery] Pagination pagination)
        {
            var querybook = await _bookRepository.SearchBookAsync(query, pagination);
            return Ok(querybook);
        }
        [Authorize(Roles = "User")]
        [HttpGet("search-book-language")]
        public async Task<ActionResult<IEnumerable<Book>>> SearchBookLanguage([FromQuery] string language)
        {
            var booklanguage = await _bookService.SearchBookLanguage(language);
            var booklanguageDto = booklanguage.Select(x => x.ToBookDto()).ToList();
            return Ok(booklanguageDto);
        }
        [HttpPut("delete-stamp/{id}")]
        public async Task<ActionResult> DeleteStampBook(int id, string deleteStatus)
        {
            await _bookService.DeleteStampBook(id, deleteStatus);
            return Ok(new { id, deleteStatus });
        }
    }
}
