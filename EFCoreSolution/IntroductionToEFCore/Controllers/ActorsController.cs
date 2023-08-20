
using AutoMapper;
using DTOs;
using IntroductionToEFCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IntroductionToEFCore.Controllers
{
    [ApiController]
    [Route("api/actors")]
    public class ActorsController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public ActorsController(ApplicationDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> CreateActor(ActorDTO actorDTO)
        {
            var actor = mapper.Map<Actor>(actorDTO); //casting the dto to Actor entity

            context.Add(actor);

            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
