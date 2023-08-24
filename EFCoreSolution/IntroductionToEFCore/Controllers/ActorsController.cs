
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        [Route("CreateActor")]
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

        //Applying filters
        [HttpGet]
        [Route("GetActorByName")]
        public async Task<ActionResult<IEnumerable<Actor>>> GetActorByName(string Pname)
        {
            //version 1
          //  return await _dbContext.Actors.Where(act => act.Name == name).ToListAsync();

           //version 2
           //All Actors where their names contains name
          // return await _dbContext.Actors.Where(act => act.Name.Contains(name)).ToListAsync();

            //sorting
            //version 3
            return await _dbContext.Actors.
                Where(name => name.Name == Pname).
                 OrderBy(act => act.Name).
                    ThenByDescending(bth => bth.Birthday).
                        ToListAsync();

            //SQL select * from Actors order by Name, Birthday desc
        }

        //[HttpGet]
        //[Route("GetIdAndNameActor")]
        //public async Task<ActionResult> GetIdAndNameActor()
        //{
        //    //projecting an anonymous object from  Actor records
        //    var actors = await _dbContext.Actors.Select(act => new {act.Id, act.Name}).ToListAsync();
        //    return Ok(actors); //by returning Ok(JSON) the anonymous object will be sent serialized, cause I dont have a DTO
        //} 
        //The same method but returning a DTO
        [HttpGet]
        [Route("GetIdAndNameActor")]
        public async Task<ActionResult<IEnumerable<ActorDTOFilterd>>> GetIdAndNameActor()
        {
            //projecting an ActorDTOFilterd
            // return await _dbContext.Actors.Select(act => new ActorDTOFilterd { Id = act.Id, Name = act.Name }).ToListAsync();

            //a better opt using automapper
            //without using Select because EF core knows it just need to select the fields 
            //that exist in the ActorDTOFilterd class, 
            return await _dbContext.Actors.ProjectTo<ActorDTOFilterd>(mapper.ConfigurationProvider).ToListAsync();
        }

        //Applying filters-- operadores booleanos binarios & ||
        [HttpGet]
        [Route("GetActorByRangeBirthday")]
        public async Task<ActionResult<IEnumerable<Actor>>> GetActorByRangeBirthday(DateTime start, DateTime end)
        {
            return await _dbContext.Actors.Where(act => act.Birthday >= start && act.Birthday <= end).
                OrderBy(act => act.Birthday).ToListAsync();
        }

        //filtering by id, returning the first accuracy or 404
        [HttpGet]
        [Route("GetAutorById")]
        public async Task<ActionResult<Actor>> GetAutorById(int id)
        {
           var actor = await _dbContext.Actors.FirstOrDefaultAsync(aut => aut.Id == id);
           if(actor is null) return NotFound(); // returns 404

            return actor;
        }
    }
}
