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
        public IEnumerable<Book> GetBooksByPublisher()
        {
            return _bookService.GetBooksByPublisher();
        }
        [HttpGet("BooksByPublisher")]
        public IEnumerable<Book> GetBooksByAuthor()
        {
            return _bookService.GetBooksByAuthor();
        }
        [HttpGet("BooksByPublisherUsingSproc")]
        public IEnumerable<Book> GetBooksByPublisherUsingSproc()
        {
            return _bookService.GetBooksByPublisherUsingSproc();
        }
        [HttpGet("BooksByAuthorUsingSproc")]
        public IEnumerable<Book> GetBooksByAuthorUsingSproc()
        {
            return _bookService.GetBooksByAuthorUsingSproc();
        }

        [HttpGet("AllBooksPrice")]
        public decimal GetAllBooksPrice()
        {
            return _bookService.GetAllBooksPrice();
        }
        [HttpPost("AddBooks")]
        public void AddBooks([FromBody] List<Book> books)
        {
            _bookService.AddBooks(books);
        }
    }
}
