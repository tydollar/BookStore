using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Api.Models;
using BookStore.Api.Services;

namespace BookStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        

        private readonly ILogger<BookController> _logger;
        private IBookService _bookService;
        public BookController(ILogger<BookController> logger,IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet("BooksByPublisher")]
        public async Task<IActionResult> GetBooksByPublisher()
        {
            return Ok(_bookService.GetBooksByPublisher());
        }
        [HttpGet("BooksByPublisher")]
        public async Task<IActionResult> GetBooksByAuthor()
        {
            return Ok(await _bookService.GetBooksByAuthor());
        }
        [HttpGet("BooksByPublisherUsingSproc")]
        public async Task<IActionResult> GetBooksByPublisherUsingSproc()
        {
            return Ok(await _bookService.GetBooksByPublisherUsingSproc());
        }
        [HttpGet("BooksByAuthorUsingSproc")]
        public async Task<IActionResult> GetBooksByAuthorUsingSproc()
        {
            return Ok(await _bookService.GetBooksByAuthorUsingSproc());
        }

        [HttpGet("AllBooksPrice")]
        public  async Task<IActionResult> GetAllBooksPrice()
        {
            return Ok(await _bookService.GetAllBooksPrice());
        }
        [HttpPost("AddBooks")]
        public async Task<IActionResult> AddBooks([FromBody] List<Book> books)
        {
            await _bookService.AddBooks(books);
            return Ok();
        }
    }
}
