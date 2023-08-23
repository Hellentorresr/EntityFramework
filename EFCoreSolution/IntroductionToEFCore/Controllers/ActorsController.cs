
using AutoMapper;
using DTOs;
using IntroductionToEFCore.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroductionToEFCore.Controllers
{
    [ApiController]
    [Route("api/actors")]
    public class ActorsController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IMapper mapper;

        public ActorsController(ApplicationDBContext context, IMapper mapper)
        {
            this._dbContext = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> CreateActor(ActorDTO actorDTO)
        {
            var actor = mapper.Map<Actor>(actorDTO); //casting the dto to Actor entity

            _dbContext.Add(actor);

            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("GetActors")]
        public async Task<ActionResult<IEnumerable<Actor>>> GetActors()
        {
            //                     table Name
            return await _dbContext.Actors.ToListAsync();
        }
    }
}
