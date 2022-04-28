using BookStore.Api.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Services
{
    public class BookService : IBookService
    {
        private BookStoreContext dbContext;
        public BookService(BookStoreContext context)
        {
            dbContext = context;
        }
        
        public List<Book> GetBooksByPublisher()
        {
            return dbContext.Book
                .OrderBy(x => x.Publisher)
                .ThenBy(x => x.AuthorLastName)
                .ThenBy(x => x.AuthorFirstName)
                .ThenBy(x => x.Title)
                .ToList();
            
        }

        public List<Book> GetBooksByAuthor()
        {
            return dbContext.Book
                .OrderBy(x => x.AuthorLastName)
                .ThenBy(x => x.AuthorFirstName)
                .ThenBy(x => x.Title)
                .ToList();

        }

        public decimal GetAllBooksPrice()
        {
            return dbContext.Book.Sum(x => x.Price);
                
        }


        public List<Book> GetBooksByAuthorUsingSproc()
        {
            List<Book> books= dbContext.Book.FromSqlRaw("usp_GetAllBooksByAuthor").ToList();
            return books;
        }
        public List<Book> GetBooksByPublisherUsingSproc()
        {
            List<Book> books = dbContext.Book.FromSqlRaw("usp_GetAllBooksByPublisher").ToList();
            return books;
        }

        public void AddBooks(List<Book> books)
        {
            dbContext.Book.AddRange(books);
            dbContext.SaveChanges();
        }
    }
}
