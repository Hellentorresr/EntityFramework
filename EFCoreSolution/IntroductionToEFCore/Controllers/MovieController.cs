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

            //when there's not a junction table -- FilmGenreMovie
            if (movie.FilmGenres is not null)
            {
                foreach(var genre in movie.FilmGenres)
                {
                   context.Entry(genre).State = EntityState.Unchanged; //the Entry method is useful for working with entities that are tracked by the DbContext, as well as entities that are not yet tracked but you want to start tracking them in a specific state.
                }                                         //existing record do not create a new one
            }

            //when there's a junction table -- MoviesActors
            if (movie.MovieActors is not null)
            {
                  for(int i = 0;  i <movie.MovieActors.Count; i++)
                  {
                        //assignig to SearchOrder field its value
                        movie.MovieActors[i].SearchOrder = i + 1; //in the same order the actors are being receive they will be save
                  }
            }

            context.Add(movie);
            await context.SaveChangesAsync();
            return Ok();
        }


        /*This first approach is called eager loading, which means that the related data is loaded
         * from the database as part of the initial query. Eager loading is achieved by using 
         * the Include and ThenInclude methods on the DbSet2. Eager loading can improve performance 
         * and avoid multiple queries, but it can also result in loading more data than needed.*/
        [HttpGet]
        [Route("GetMoviesById")]
        public async Task<ActionResult<Movie>> GetMoviesById(int PId)
        {
            var movie = await context.Movies.
                Include(movie => movie.Comments).
                 Include(movie => movie.FilmGenres).
                     Include(movie => movie.MovieActors.OrderBy(act => act.SearchOrder)).
                       ThenInclude(movie => movie.Actor).
                         FirstOrDefaultAsync(m => m.Id == PId);

            if (movie is null) return NotFound();

            return  movie;
        }


        /*The second approach is called explicit loading, which means that the related data is 
         * explicitly loaded from the database at a later time. Explicit loading is achieved by 
         * using the Select method on the DbSet, which allows you to project only the properties or 
         * related data that you want. Explicit loading can reduce the amount of data transferred from 
         * the database, but it can also require more queries and more code.*/
        [HttpGet]
        [Route("GetMoviesByIdSelec")]
        public async Task<ActionResult> GetMoviesByIdSelec(int PId)
        {
            var movie = await context.Movies.
                Select(movie => new
                {
                    movie.Id,
                    movie.Name,
                    FilmGenre = movie.FilmGenres.Select(genr => genr.Name).ToList(), //projecting the names of the genres
                    Actors = movie.MovieActors.OrderBy(act => act.SearchOrder).Select(pa => new
                            {
                                Id = pa.ActorId,
                                pa.Actor.Name,
                                pa.Character
                            }
                    ),

                    CommentNumber = movie.Comments.Count()  //just counting how many comments this movie has

                }).
                 FirstOrDefaultAsync(m => m.Id == PId);

            if (movie is null) return NotFound();

            return Ok(movie); //by returning Ok(JSON) the anonymous object will be sent serialized
        }
    }
}
