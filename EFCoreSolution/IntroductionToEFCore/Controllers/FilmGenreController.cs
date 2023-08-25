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

        //Updating 
        /*This first approach is called explicit loading, where you first query the entity from the 
         * database and then modify its properties. This approach is simple and straightforward, but 
         * it requires an extra roundtrip to the database to load the entity.*/
        [HttpPut]
        [Route("UpdateGenreName")]
        public async Task<ActionResult> UpdateGenreName(int PId, string name)
        {
            var genre = _dbContext.FilmGenres.FirstOrDefault(g => g.Id == PId); //first finding the genre
            if (genre is null) return NotFound();

            genre.Name = name; //updating the property

            await _dbContext.SaveChangesAsync(); //saving the changes
            return Ok();
        }

        //Updating 
        /*The second approach is called disconnected entities, where you create a new entity instance and
         * attach it to the DbContext with the Update method. This approach does not require loading the
         * entity from the database, but it assumes that you have all the values for the entity, including
         * its primary key. This approach is more common for real applications, where you may receive an 
         * entity from a web API or a user interface*/
        [HttpPut]
        [Route("UpdateGenre")]
        public async Task<ActionResult> UpdateGenre(int PId, FilmGenreDTO genreDTO)
        {
            var genre = mapper.Map<FilmGenre>(genreDTO); 
            genre.Id = PId;

            _dbContext.Update(genre);
            await _dbContext.SaveChangesAsync(); 
            return Ok();
        }

        //Deleting using the lettes way of doing it
        //More efficient because i'm just performing a query which is deleting
        [HttpDelete]
        [Route("DeleteGenre")]
        public async Task<ActionResult> DeleteGenre(int PId)
        {
            //this method: ExecuteDeleteAsync returns the total number of rows deleted in the database
            var alteredRow = await _dbContext.FilmGenres.Where(g => g.Id == PId).ExecuteDeleteAsync();

            if(alteredRow == 0) return NotFound();
            
           // return Ok();
           return NoContent(); //HTTP response status code 204 No Content is returned by the server to indicate that a HTTP request has been successfully completed, and there is no message body
        }

        //Deleting using the classic appr
        //performing two queries 1: finding the record 2: deleting
        [HttpDelete]
        [Route("DeleteGenreTwo")]
        public async Task<ActionResult> DeleteGenreTwo(int PId)
        {
            //First finding the Genre with the id == PId
            var alteredRow = await _dbContext.FilmGenres.FirstOrDefaultAsync(g => g.Id == PId);

            //Then
            if(alteredRow is null) return NotFound();

            _dbContext.Remove(alteredRow);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
