using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
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
        public async Task<IActionResult> AddBlogLike(Guid blogId, BlogLikeDTO bloglike,Guid UserId)
        {
            var result = await _bloglikeService.AddBlogLike(blogId,bloglike,UserId);
            return !result.Success ? BadRequest(Messages.BlogLikeNotAdded) : Ok(Messages.BlogLikeAdded);
        }
        [HttpPost("AddBlogCommentLike")]
        public async Task<IActionResult> AddBlogCommentLike(Guid blogCommentId, BlogLikeDTO bloglike, Guid UserId)
        {
            var result = await _bloglikeService.AddBlogCommentLike(blogCommentId, bloglike, UserId);
            return !result.Success ? BadRequest(Messages.BlogLikeNotAdded) : Ok(Messages.BlogLikeAdded);
        }
        [HttpGet("GetBlogLikeDetails")]
        public async Task<IActionResult> GetAllLikeDetails()
        {
            var result = await _bloglikeService.GetAllLikeDetails();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return NotFound(Messages.BlogLikedNotListed);

        }
        [HttpGet("GetLikesByBlogId")]
        public async Task<IActionResult> GetLikesByBlogId(Guid BlogId)
        {
            var result = await _bloglikeService.GetLikesByBlogId(BlogId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return NotFound(Messages.BlogLikedNotListed);

        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid id,Guid UserId)
        {
            try
            {
               await _bloglikeService.Delete(id, UserId);
                return Ok(Messages.BlogLikeDeleted);
            }
            catch (Exception exception)
            {
                return BadRequest(Messages.BlogLikeNotDeleted);
            }
        }


    }
}
