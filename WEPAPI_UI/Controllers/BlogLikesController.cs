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
        public async Task<IActionResult> AddBlogLike(Guid blogId, BlogLikeDTO bloglike)
        {
            var result = await _bloglikeService.AddBlogLike(blogId,bloglike);
            if (result.Success)
            {
                return Ok(Messages.BlogLikeAdded);
            }
            return BadRequest(Messages.BlogLikeNotAdded);
        }
        [HttpPost("AddBlogCommentLike")]
        public async Task<IActionResult> AddBlogCommentLike(Guid blogCommentId, BlogLikeDTO bloglike)
        {
            var result = await _bloglikeService.AddBlogCommentLike(blogCommentId, bloglike);
            if (result.Success)
            {
                return Ok(Messages.BlogLikeAdded);
            }
            return BadRequest(Messages.BlogLikeNotAdded);
        }
        [HttpGet("GetBlogLikeDetails")]
        public async Task<IActionResult> GetAllLikeDetails()
        {
            var result = await _bloglikeService.GetAllLikeDetails();
            if (result is null) return NotFound(Messages.BlogLikedNotListed);
            return Ok(result);

        }
        [HttpGet("GetLikesByBlogId")]
        public async Task<IActionResult> GetLikesByBlogId(Guid BlogId)
        {
            var result = _bloglikeService.GetLikesByBlogId(BlogId);
            if (result is null)
            return NotFound(Messages.BlogLikedNotListed);
            return Ok(result);

        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
               await _bloglikeService.Delete(id);
                return Ok(Messages.BlogLikeDeleted);
            }
            catch (Exception exception)
            {
                return BadRequest(Messages.BlogLikeNotDeleted);
            }
        }


    }
}
