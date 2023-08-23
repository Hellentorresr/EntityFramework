using AutoMapper;
using DTOs;
using IntroductionToEFCore.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntroductionToEFCore.Controllers
{
    [Route("api/movie/{movieId:int}/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public CommentsController(ApplicationDBContext context, IMapper mapper) 
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> AddCommentToMovie(int movieId, CommentDTO commentDTO)
        {
            var _comment = mapper.Map<Comment>(commentDTO);
            _comment.MovieId = movieId;
            context.Add(_comment);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
