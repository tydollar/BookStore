using BookStore.Api.Models;
using BookStore.Api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

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
                List<Book> list = context.Book.ToListAsync().Result;
                foreach (var item in list)
                {
                    context.Book.Remove(item);
                }
                context.Book.Add(new Book
                {
                    AuthorFirstName = "Tyler",
                    AuthorLastName = "Gill",
                    Price = 1m,
                    Title = "The Best Book2",
                    Publisher = "Best Pub",
                    PageRange ="11-12",
                    PublishDate=System.DateTime.Today.AddDays(-2000)
                    


                });
                context.Book.Add(new Book
                {
                    AuthorFirstName = "Tyler",
                    AuthorLastName = "Gill",
                    Price = 2m,
                    Title = "The Best Book",
                    Publisher = "A Pub",
                    PageRange = "1-2",
                    PublishDate = System.DateTime.Today.AddDays(-200)

                });
                context.Book.Add(new Book
                {
                    AuthorFirstName = "Tyler",
                    AuthorLastName = "Aill",
                    Price = 2m,
                    Title = "The Best Book3",
                    Publisher = "Cest Pub",
                    PageRange = "1-20",
                    PublishDate = System.DateTime.Today.AddDays(-3200)


                });

                context.SaveChanges();
            }

        }
        [TestMethod]
        public async Task GetBooksByPublisherTest()
        {
            using (var context = new BookStoreContext(dbContextOptions))
            {
                var service = new BookService(context);
                var books = await service.GetBooksByPublisher();
                Assert.IsNotNull(books);
                Assert.IsTrue(books[0].Publisher == "A Pub");
            }

        }

        [TestMethod]
        public async Task GetBooksByAuthorTest()
        {
            using (var context = new BookStoreContext(dbContextOptions))
            {
                var service = new BookService(context);
                var books = await service.GetBooksByAuthor();
                Assert.IsNotNull(books);
                Assert.IsTrue(books[0].Publisher == "Cest Pub");
            }

        }

        [TestMethod]
        public async Task GetBooksAllPriceTest()
        {
            using (var context = new BookStoreContext(dbContextOptions))
            {
                var service = new BookService(context);
                var price = await service.GetAllBooksPrice();

                Assert.IsTrue(price == 5);
            }

        }

        [TestMethod]
        public async Task AddBooksTest()
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
                await service.AddBooks(listBooks);
                var bookCount = await service.GetBooksByPublisher();
                Assert.IsTrue(bookCount.Count == 6);
            }

        }


        [TestMethod]
        public async Task GetCiticansTest()
        {
            using (var context = new BookStoreContext(dbContextOptions))
            {
                var service = new BookService(context);
                
                var bookCount = await service.GetBooksByPublisher();
                var cit = bookCount[0].Chicagoitation;
                Assert.IsTrue(cit== "Tyler Gill, The Best Book (The Best Book,October 2021)1-2.");
                var cit2 = bookCount[1].MLACitation;
                Assert.IsTrue(cit2 == "Gill,Tyler.\"The Best Book2\"Best Pub, November 2016, pp 11-12.");

            }

        }
    }
}
