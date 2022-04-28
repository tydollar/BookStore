using BookStore.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Api.Services
{
    public interface IBookService
    {
        public  Task<List<Book>> GetBooksByAuthor();
        public  Task<List<Book>> GetBooksByPublisher();
        public Task<decimal> GetAllBooksPrice();
        public  Task<List<Book>> GetBooksByAuthorUsingSproc();
        public  Task<List<Book>> GetBooksByPublisherUsingSproc();
        public Task  AddBooks(List<Book> books);
    }
}
