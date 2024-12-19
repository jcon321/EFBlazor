using LibraryBlazorCRUD2.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryBlazorCRUD.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Patron> Patrons { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
