using BookStore.Api.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BookStore.Api.Services
{
    public class BookService : IBookService
    {
        private BookStoreContext dbContext;
        public BookService(BookStoreContext context)
        {
            dbContext = context;
        }
        
        public async Task<List<Book>> GetBooksByPublisher()
        {
            return await dbContext.Book
                .OrderBy(x => x.Publisher)
                .ThenBy(x => x.AuthorLastName)
                .ThenBy(x => x.AuthorFirstName)
                .ThenBy(x => x.Title)
                .ToListAsync();
            
        }

        public async Task<List<Book>> GetBooksByAuthor()
        {
            return await dbContext.Book
                .OrderBy(x => x.AuthorLastName)
                .ThenBy(x => x.AuthorFirstName)
                .ThenBy(x => x.Title)
                .ToListAsync();

        }

        public async Task<decimal> GetAllBooksPrice()
        {
            return await dbContext.Book.SumAsync(x => x.Price);
                
        }


        public async Task<List<Book>> GetBooksByAuthorUsingSproc()
        {
            List<Book> books=await dbContext.Book.FromSqlRaw("usp_GetAllBooksByAuthor").ToListAsync();
            return books;
        }
        public async Task<List<Book>> GetBooksByPublisherUsingSproc()
        {
            List<Book> books = await dbContext.Book.FromSqlRaw("usp_GetAllBooksByPublisher").ToListAsync();
            return books;
        }

        public async Task AddBooks(List<Book> books)
        {
            await dbContext.Book.AddRangeAsync(books);
            await dbContext.SaveChangesAsync();
            
        }
    }
}
