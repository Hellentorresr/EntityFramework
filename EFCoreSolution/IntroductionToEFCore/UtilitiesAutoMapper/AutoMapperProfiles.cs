using AutoMapper;
using DTOs;
using IntroductionToEFCore.Entities;

namespace IntroductionToEFCore.UtilitiesAutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() {

            CreateMap<FilmGenreDTO, FilmGenre>();

            CreateMap<ActorDTO, Actor>();

            //mapping from type MovieCreationDTO to Movie
            CreateMap<MovieCreationDTO, Movie>().ForMember(entity => entity.FilmGenres,
                dto => dto.MapFrom(field => field.Genres.Select(Id => new FilmGenre { Id = Id})));

            CreateMap<MovieActorCreationDTO, MovieActor>();
        }
    }
}
