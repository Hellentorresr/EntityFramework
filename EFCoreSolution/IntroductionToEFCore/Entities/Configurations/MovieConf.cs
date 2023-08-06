using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace IntroductionToEFCore.Entities.Configurations
{
    public class MovieConf : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(m => m.Name).HasMaxLength(150);
            builder.Property(m => m.MovieReleaseDate).HasColumnType("date");
        }
    }
}
