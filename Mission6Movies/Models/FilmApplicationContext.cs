using Microsoft.EntityFrameworkCore;

namespace Mission6Movies.Models
{
    public class FilmApplicationContext : DbContext
    {

        public FilmApplicationContext(DbContextOptions<FilmApplicationContext> options) : base(options)

        {

        }
        public DbSet<FormModel> Films { get; set; }
    }
}
