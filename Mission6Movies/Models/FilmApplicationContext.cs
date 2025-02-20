using System.Net.NetworkInformation;
using Microsoft.EntityFrameworkCore;
using Mission6Movies.Models;

namespace Mission6Movies.Models
{
    public class FilmApplicationContext : DbContext
    {
        public FilmApplicationContext(DbContextOptions<FilmApplicationContext> options) : base(options)
        {
        }

        public DbSet<FormModel> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }  // Add this line to enable access to categories
    }
}
