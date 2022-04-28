using BookStore.Api.Models;
using BookStore.Api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BookStore.Test
{
    [TestClass]
    public class BookServiceTest
    {
       
        private DbContextOptions<BookStoreContext> dbContextOptions;
        
        public BookServiceTest()
        {
            dbContextOptions = new DbContextOptionsBuilder<BookStoreContext>()
                .UseInMemoryDatabase(databaseName: "BookStore")
                .Options;
            using (var context = new BookStoreContext(dbContextOptions))
            {
              
                context.Book.Add(new Book
                {
                    AuthorFirstName = "Tyler",
                    AuthorLastName = "Gill",
                    Price = 1m,
                    Title = "The Best Book2",
                    Publisher = "Best Pub"

                });
                context.Book.Add(new Book
                {
                    AuthorFirstName = "Tyler",
                    AuthorLastName = "Gill",
                    Price = 2m,
                    Title = "The Best Book",
                    Publisher = "A Pub"

                });
                context.Book.Add(new Book
                {
                    AuthorFirstName = "Tyler",
                    AuthorLastName = "Aill",
                    Price = 2m,
                    Title = "The Best Book3",
                    Publisher = "Cest Pub"

                });

                context.SaveChanges();
            }

        }
        [TestMethod]
        public void GetBooksByPublisherTest()
        {
            using (var context = new BookStoreContext(dbContextOptions))
            {
                var service = new BookService(context);

                var books =service.GetBooksByPublisher();
                Assert.IsNotNull(books);
                Assert.IsTrue(books[0].Publisher == "A Pub");
            }
 
        }

        [TestMethod]
        public void GetBooksByAuthorTest()
        {
            using (var context = new BookStoreContext(dbContextOptions))
            {
                var service = new BookService(context);

                var books = service.GetBooksByAuthor();
                Assert.IsNotNull(books);
                Assert.IsTrue(books[0].Publisher == "Cest Pub");
            }

        }

        [TestMethod]
        public void GetBooksAllPriceTest()
        {
            using (var context = new BookStoreContext(dbContextOptions))
            {
                var service = new BookService(context);

                var price = service.GetAllBooksPrice();
                 
                Assert.IsTrue(price == 5);
            }

        }

        [TestMethod]
        public void AddBooksTest()
        {
            using (var context = new BookStoreContext(dbContextOptions))
            {
                var service = new BookService(context);
                var listBooks = new List<Book>
                {
                    new Book{ Id = 12, Price =1m,AuthorFirstName="Ty",AuthorLastName="G",Title="R"},
                    new Book{ Id = 22, Price =1m,AuthorFirstName="Ty",AuthorLastName="G",Title="R"},
                    new Book{ Id = 11, Price =1m,AuthorFirstName="Ty",AuthorLastName="G",Title="R"}
                };
                service.AddBooks(listBooks);

                Assert.IsTrue(service.GetBooksByPublisher().Count  == 6);
            }

        }

    }
}
