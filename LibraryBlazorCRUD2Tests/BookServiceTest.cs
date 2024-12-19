using LibraryBlazorCRUD2.Data;
using LibraryBlazorCRUD2.Models;
using LibraryBlazorCRUD2.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace LibraryBlazorCRUD2.Tests
{
    public class BookServiceTest
    {
        private AppDbContext GetContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            AppDbContext context = new AppDbContext(options);

            return context;
        }

        [Fact]
        public async Task CanAddAndRetrieveBook()
        {
            using var context = GetContext();
            var service = new BookService(context);

            var newBook = new Book { Title = "New Book", PatronId = 1 };
            await service.AddBookAsync(newBook);

            var book = await service.GetBookByIdAsync(newBook.Id);
            Assert.NotNull(book);
            Assert.Equal("New Book", book.Title);
        }

        //[Fact]
        //public async Task CanUpdateBook()
        //{
        //    using var context = GetContext();
        //    var service = new BookService(context);

        //    var book = await service.GetBookByIdAsync(1);
        //    book.Title = "Updated Title";
        //    await service.UpdateBookAsync(book);

        //    var updatedBook = await service.GetBookByIdAsync(1);
        //    Assert.Equal("Updated Title", updatedBook.Title);
        //}

        //[Fact]
        //public async Task CanDeleteBook()
        //{
        //    using var context = GetContext();
        //    var service = new BookService(context);

        //    await service.DeleteBookAsync(1);

        //    var book = await service.GetBookByIdAsync(1);
        //    Assert.Null(book);
        //}

        //[Fact]
        //public async Task CanGetAllBooks()
        //{
        //    using var context = GetContext();
        //    var service = new BookService(context);

        //    var books = await service.GetAllBooksAsync();
        //    Assert.Single(books);
        //}
    }
}
