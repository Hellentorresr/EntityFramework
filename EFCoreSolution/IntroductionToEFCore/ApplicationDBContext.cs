using IntroductionToEFCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

        //Adding the MovieActor junction entity,
        public DbSet<MovieActor> MoviesActors => Set<MovieActor>();

        //adding this method againg but clean up
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //never delete this line of code

            //Applying the configuration from all the classes that implement the IEntityTypeConfiguration<TEntity>
            //interface, this interface allows us to to confi the entity types and their relationships in a separate class instead of using the Fuent API in the OnModelCreating method
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        //I move all this code to Configurations folder devided by entities
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //base.OnModelCreating(modelBuilder); //never delete this line of code

        //adding the settings
        //modelBuilder.Entity<FilmGenre>().HasKey(f => f.Id);
        //   modelBuilder.Entity<FilmGenre>().Property(g => g.Name).HasMaxLength(150);

        // ** I moved this conf to its own file, in the Configurations folder
        ////Adding conf for the Actor table
        //modelBuilder.Entity<Actor>().Property(a => a.Name).HasMaxLength(50);
        //modelBuilder.Entity<Actor>().Property(a => a.Birthday).HasColumnType("date");// to excluete the hour from the Datetime data type
        //modelBuilder.Entity<Actor>().Property(a => a.Furtune).HasPrecision(18, 2);//18 digits and 2 decimals, example: 1234567891234567.11, cause the actors are rich 😁 

        //Adding conf for the movie table
        //modelBuilder.Entity<Movie>().Property(m => m.Name).HasMaxLength(150);
        //modelBuilder.Entity<Movie>().Property(m => m.MovieReleaseDate).HasColumnType("date");

        //Adding conf for the Comment table
        //modelBuilder.Entity<Comment>().Property(m => m.Recommend).HasMaxLength(500);
        }

        //add this method if i want each string property to be a column with a 
        //default number of characteres, but i my case I want to customize them indivually
        //cause EF by default adds maxLength to max, besically override this setting
        //protected override void ConfigureConventions(ModelConfigurationBuilder modlConf)
        //{
        //    modlConf.Properties<string>().HaveMaxLength(150);
        //}
    //}
}