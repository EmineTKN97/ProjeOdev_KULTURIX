using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogLikesController : ControllerBase
    {
        private readonly IBlogLikeService _bloglikeService;

        public BlogLikesController(IBlogLikeService bloglikeService)
        {
            _bloglikeService = bloglikeService;
        }
        [HttpPost("Post")]
        public ActionResult<BlogLikeDTO> Add(Guid blogId, BlogLikeDTO bloglike)
        {
            _bloglikeService.Add(blogId, bloglike);
            return Ok();
        }


    }
}
