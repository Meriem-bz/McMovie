
using Microsoft.EntityFrameworkCore;
using McMovie.Models;

public class McMovieContext(DbContextOptions<McMovieContext> options) : DbContext(options)
{
    public DbSet<Movie> Movie { get; set; } = default!;
}
