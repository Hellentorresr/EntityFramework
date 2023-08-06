using IntroductionToEFCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IntroductionToEFCore.Controllers
{
    [ApiController]
    [Route("api/filmgenre")]
    public class FilmGernreController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public FilmGernreController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult> Post(FilmGenre filmGenre)
        {
            //Entity framework work code to insert
            _dbContext.Add(filmGenre);

            //saving the changes in the database
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
