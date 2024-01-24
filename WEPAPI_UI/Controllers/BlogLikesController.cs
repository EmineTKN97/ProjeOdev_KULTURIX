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
        [HttpPost("BlogLike")]
        public ActionResult<BlogLikeDTO> AddBlogLike(Guid blogId, BlogLikeDTO bloglike)
        {
            _bloglikeService.AddBlogLike(blogId, bloglike);
            return Ok();
        }
        [HttpPost("BlogCommentLike")]
        public ActionResult<BlogLikeDTO> AddBlogCommentLike(Guid blogCommentId, BlogLikeDTO bloglike)
        {
            _bloglikeService.AddBlogCommentLike(blogCommentId, bloglike);
            return Ok();
        }
        [HttpGet("GetBlogLikeDetails")]
        public ActionResult<BlogLikeDTO> GetAllLikeDetails()
        {
            var result = _bloglikeService.GetAllLikeDetails();
            return Ok(result);

        }
        [HttpGet("GetLikesByBlogId")]
        public ActionResult<BlogLikeDTO> GetLikesByBlogId(Guid BlogId)
        {
            var result = _bloglikeService.GetLikesByBlogId(BlogId);
            return Ok(result);

        }
        [HttpDelete("Delete")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _bloglikeService.Delete(id);
                return Ok("Blog başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Blog silme işlemi başarısız. Hata: {ex.Message}");
            }
        }


    }
}
