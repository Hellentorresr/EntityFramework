using AutoMapper;
using DTOs;
using IntroductionToEFCore.Entities;

namespace IntroductionToEFCore.UtilitiesAutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<FilmGenreDTO, FilmGenre>();

            CreateMap<ActorDTO, Actor>();

            CreateMap<MovieCreationDTO, Movie>()
               .ForMember(dest => dest.MovieActors, opt => opt.MapFrom(src => src.MovieActorCreationDTOs))
               .ForMember(dest => dest.FilmGenres, opt => opt.MapFrom(src => src.Genres.Select(Id => new FilmGenre { Id = Id })));

            CreateMap<MovieActorCreationDTO, MovieActor>()
               .ForMember(dest => dest.Character, opt => opt.MapFrom(src => src.MovieCharacter)); // map the 'MovieCharacter' property to the 'Character' property

            CreateMap<CommentDTO, Comment>();
        }
    }
}
