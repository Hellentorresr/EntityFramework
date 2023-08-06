using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace IntroductionToEFCore.Entities.Configurations
{
    public class ActorConf : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            //Adding conf for the Actor table
            builder.Property(a => a.Name).HasMaxLength(50);
            builder.Property(a => a.Birthday).HasColumnType("date");// to excluete the hour from the Datetime data type
            builder.Property(a => a.Furtune).HasPrecision(18, 2);//18 digits and 2 decimals, example: 1234567891234567.11, cause the actors are rich 😁 
        }
    }
}
