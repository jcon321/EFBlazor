using LibraryBlazorCRUD2.Data;
using LibraryBlazorCRUD2.Components;
using Microsoft.EntityFrameworkCore;
using LibraryBlazorCRUD2.Services;

namespace LibraryBlazorCRUD2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            // Register dbcontext
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("Data Source=mydatabase.db"));
            builder.Services.AddScoped<PatronService>();
            builder.Services.AddScoped<BookService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
