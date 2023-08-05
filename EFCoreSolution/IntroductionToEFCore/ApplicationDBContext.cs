using IntroductionToEFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace IntroductionToEFCore
{
    public class ApplicationDBContext : DbContext 
    {
        //Constructor
        public ApplicationDBContext(DbContextOptions options) : base(options) { 
            
        }

        //adding the FilmGenre class to be a entity
        public DbSet<FilmGenre> FilmGenres => Set<FilmGenre>();

        //adding the Actor class class to be a entity
        public DbSet<Actor> Actors => Set<Actor>();

        //Adding the Movie class to be a entity
        public DbSet<Movie> Movies => Set<Movie>();

        //Adding the Comment class to be a entity
        public DbSet<Comment> Comments => Set<Comment>();

        //
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //never delete this line of code

            //adding the settings
            //modelBuilder.Entity<FilmGenre>().HasKey(f => f.Id);
            modelBuilder.Entity<FilmGenre>().Property(g => g.Name).HasMaxLength(150);


            //Adding conf for the Actor table
            modelBuilder.Entity<Actor>().Property(a => a.Name).HasMaxLength(150);
            modelBuilder.Entity<Actor>().Property(a => a.Birthday).HasColumnType("date");// to excluete the hour from the Datetime data type
            modelBuilder.Entity<Actor>().Property(a => a.Furtune).HasPrecision(18, 2);//18 digits and 2 decimals, example: 1234567891234567.11, cause the actors are rich 😁 

            //Adding conf for the movie table
            modelBuilder.Entity<Movie>().Property(m => m.Name).HasMaxLength(150);
            modelBuilder.Entity<Movie>().Property(m => m.MovieReleaseDate).HasColumnType("date");
        }
    }
}