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
            try
            {
                return Ok(await _bookService.GetBooksByPublisher());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
            
        }
        [HttpGet("BooksByPublisher")]
        public async Task<IActionResult> GetBooksByAuthor()
        {
            try
            {
                return Ok(await _bookService.GetBooksByAuthor());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
            
        }
        [HttpGet("BooksByPublisherUsingSproc")]
        public async Task<IActionResult> GetBooksByPublisherUsingSproc()
        {
            try
            {
                return Ok(await _bookService.GetBooksByPublisherUsingSproc());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
            
        }
        [HttpGet("BooksByAuthorUsingSproc")]
        public async Task<IActionResult> GetBooksByAuthorUsingSproc()
        {
            try
            {
                return Ok(await _bookService.GetBooksByAuthorUsingSproc());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("AllBooksPrice")]
        public  async Task<IActionResult> GetAllBooksPrice()
        {
            try
            {
                return Ok(await _bookService.GetAllBooksPrice());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("AddBooks")]
        public async Task<IActionResult> AddBooks([FromBody] List<Book> books)
        {
            try
            {
                if(books == null)
                {
                    return BadRequest("Null Parameter");
                }
                await _bookService.AddBooks(books);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
