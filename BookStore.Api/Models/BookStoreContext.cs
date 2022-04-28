using Microsoft.EntityFrameworkCore;
namespace BookStore.Api.Models
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }
         

    }
}
