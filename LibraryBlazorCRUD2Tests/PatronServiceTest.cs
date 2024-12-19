using LibraryBlazorCRUD2.Data;
using LibraryBlazorCRUD2.Models;
using LibraryBlazorCRUD2.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace LibraryBlazorCRUD2.Tests
{
    public class PatronServiceTest
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
        public async Task CanAddAndRetrievePatron()
        {
            using var context = GetContext();
            var service = new PatronService(context);

            var newPatron = new Patron { Name = "Jane Doe" };
            await service.AddPatronAsync(newPatron);

            var patron = await service.GetPatronByIdAsync(newPatron.Id);
            Assert.NotNull(patron);
            Assert.Equal("Jane Doe", patron.Name);
        }

        //[Fact]
        //public async Task CanUpdatePatron()
        //{
        //    using var context = GetContext();
        //    var service = new PatronService(context);

        //    var patron = await service.GetPatronByIdAsync(1);
        //    patron.Name = "Updated Name";
        //    await service.UpdatePatronAsync(patron);

        //    var updatedPatron = await service.GetPatronByIdAsync(1);
        //    Assert.Equal("Updated Name", updatedPatron.Name);
        //}

        //[Fact]
        //public async Task CanDeletePatron()
        //{
        //    using var context = GetContext();
        //    var service = new PatronService(context);

        //    await service.DeletePatronAsync(1);

        //    var patron = await service.GetPatronByIdAsync(1);
        //    Assert.Null(patron);
        //}

        //[Fact]
        //public async Task CanGetAllPatrons()
        //{
        //    using var context = GetContext();
        //    var service = new PatronService(context);

        //    var patrons = await service.GetAllPatronsAsync();
        //    Assert.Single(patrons);
        //}
    }
}
