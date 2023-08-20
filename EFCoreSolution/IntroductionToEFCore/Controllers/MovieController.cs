using AutoMapper;
using DTOs;
using IntroductionToEFCore.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroductionToEFCore.Controllers
{
    [ApiController]
    [Route("api/movies")]
  
    public class MovieController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public MovieController(ApplicationDBContext context, IMapper mapper) 
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> CreateMovie(MovieCreationDTO movieDTO)
        {
            var movie = mapper.Map<Movie>(movieDTO);
            
            //when there's not a junction table
            if(movie.FilmGenres is not null)
            {
                foreach(var genre in movie.FilmGenres)
                {
                   context.Entry(genre).State = EntityState.Unchanged; //the Entry method is useful for working with entities that are tracked by the DbContext, as well as entities that are not yet tracked but you want to start tracking them in a specific state.
                }
            }

            //when there's a junction table
            if(movie.MovieActors is not null)
            {
              for(int i = 0;  i <movie.MovieActors.Count; i++)
                {
                    movie.MovieActors[i].SearchOrder = i + 1; //in the same order the actors are being receive they will be save
                }
            }

            context.Add(movie);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
