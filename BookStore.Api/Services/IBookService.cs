using BookStore.Api.Models;
using System.Collections.Generic;

namespace BookStore.Api.Services
{
    public interface IBookService
    {
        public List<Book> GetBooksByAuthor();
        public List<Book> GetBooksByPublisher();
        public decimal GetAllBooksPrice();
        public List<Book> GetBooksByAuthorUsingSproc();
        public List<Book> GetBooksByPublisherUsingSproc();
        public void AddBooks(List<Book> books);
    }
}
