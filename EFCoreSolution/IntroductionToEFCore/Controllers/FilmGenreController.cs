using AutoMapper;
using DTOs;
using IntroductionToEFCore.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroductionToEFCore.Controllers
{
    [ApiController]
    [Route("api/filmgenre")]
    public class FilmGenreController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IMapper mapper;

        public FilmGenreController(ApplicationDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(FilmGenreDTO filmGenreDTO)
        {
            //mapping from Entity to DTO
            var _filmGenre = mapper.Map<FilmGenre>(filmGenreDTO);
            //Entity framework work code to insert
            _dbContext.Add(_filmGenre);

            //saving the changes in the database
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        //Adding many records at the same time 
        [HttpPost("many")]
        public async Task<ActionResult> Post(FilmGenreDTO[] filmGenresDTO)
        {
            var genres = mapper.Map<FilmGenre[]>(filmGenresDTO);
            _dbContext.AddRange(genres); //AddRange method is used to add a list of entities
            await _dbContext.SaveChangesAsync(); //save the changes in the database
            return Ok();
        }


        [HttpGet]
        [Route("GetFilmGenre")]
        public async Task<ActionResult<IEnumerable<FilmGenre>>> GetFilmGenre()
        {
            //                     table Name
            return await _dbContext.FilmGenres.ToListAsync();
        }
    }
}
