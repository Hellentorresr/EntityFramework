using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroductionToEFCore.Entities.Configurations
{
    public class GenreConf : IEntityTypeConfiguration<FilmGenre>
    {
        public void Configure(EntityTypeBuilder<FilmGenre> builder)
        {
            //Setting a default value for Name property
            //this id does not exist in the database, then add a new migration
            var fiction = new FilmGenre { Id = 9, Name = "Fiction" };
            var animation = new FilmGenre { Id = 10, Name = "Animation" };
            builder.HasData(animation, fiction);

            //adding a index with EF Core
            builder.HasIndex(genre => genre.Name).IsUnique(); //now the name prop is Unique
        }
    }
}
