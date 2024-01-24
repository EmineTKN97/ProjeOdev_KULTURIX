using Business.Abstract;
using Business.Constants;
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
        [HttpPost("AddBlogLike")]
        public ActionResult<BlogLikeDTO> AddBlogLike(Guid blogId, BlogLikeDTO bloglike)
        {
            var result = _bloglikeService.AddBlogLike(blogId,bloglike);
            if (result.Success == true)
            {
                return Ok(Messages.BlogLikeAdded);
            }
            return BadRequest(Messages.BlogLikeNotAdded);
        }
        [HttpPost("AddBlogCommentLike")]
        public ActionResult<BlogLikeDTO> AddBlogCommentLike(Guid blogCommentId, BlogLikeDTO bloglike)
        {
            var result = _bloglikeService.AddBlogLike(blogCommentId, bloglike);
            if (result.Success == true)
            {
                return Ok(Messages.BlogLikeAdded);
            }
            return BadRequest(Messages.BlogLikeNotAdded);
        }
        [HttpGet("GetBlogLikeDetails")]
        public ActionResult<BlogLikeDTO> GetAllLikeDetails()
        {
            var result = _bloglikeService.GetAllLikeDetails();
            if (result is null) return NotFound(Messages.BlogLikedNotListed);
            return Ok(result);

        }
        [HttpGet("GetLikesByBlogId")]
        public ActionResult<BlogLikeDTO> GetLikesByBlogId(Guid BlogId)
        {
            var result = _bloglikeService.GetLikesByBlogId(BlogId);
            if (result is null) return NotFound(Messages.BlogLikedNotListed);
            return Ok(result);

        }
        [HttpDelete("Delete")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _bloglikeService.Delete(id);
                return Ok(Messages.BlogLikeDeleted);
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.BlogLikeNotDeleted);
            }
        }


    }
}
