using LibraryBlazorCRUD2.Data;
using LibraryBlazorCRUD2.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryBlazorCRUD2.Services
{
    public class PatronService
    {
        private readonly AppDbContext _context;

        public PatronService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Patron>> GetAllPatronsAsync()
        {
            return await _context.Patrons.Include(p => p.Books).ToListAsync();
        }

        public async Task<Patron> GetPatronByIdAsync(int id)
        {
            return await _context.Patrons.Include(p => p.Books).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddPatronAsync(Patron patron)
        {
            Console.WriteLine($"Adding {patron}");
            _context.Patrons.Add(patron);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePatronAsync(Patron patron)
        {
            _context.Entry(patron).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePatronAsync(int id)
        {
            var patron = await _context.Patrons.FindAsync(id);
            _context.Patrons.Remove(patron);
            await _context.SaveChangesAsync();
        }
    }
}
