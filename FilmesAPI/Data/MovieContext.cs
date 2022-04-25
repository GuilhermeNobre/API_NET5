using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data
{
    public class MovieContext : DbContext
    {

        public MovieContext(DbContextOptions<MovieContext> opt) : base(opt)
        {
             
        }
    
        public DbSet<Movie> Movies { get; set; }
    }

}
