using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroductionToEFCore.Entities.Configurations
{
    public class MovieActorConf : IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {
            //defining the compound key 
            builder.HasKey(movActor => new { movActor.ActorId, movActor.MovieId });
        }
    }
}
