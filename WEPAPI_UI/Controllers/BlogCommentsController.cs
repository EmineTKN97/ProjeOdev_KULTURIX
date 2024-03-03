using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace WEPAPI_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCommentsController : ControllerBase
    {
        private readonly IBlogCommentService _blogcommentService;
        public BlogCommentsController(IBlogCommentService blogcommentService)
        {
            _blogcommentService = blogcommentService;
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid CommentId)
        {
            var result = await _blogcommentService.GetById(CommentId);
            return !result.Success ? BadRequest(Messages.BlogCommentNotListed) : Ok(result.Data);
        }

        [HttpGet("GetCommentsDetails")]
        public async Task<IActionResult> GetAllCommentsDetails()
        {
            var result = await _blogcommentService.GetAllCommentsDetails();
            return !result.Success ? BadRequest(Messages.BlogCommentNotListed) : Ok(result.Data);

        }
        [HttpGet("GetCommentsByBlogId")]
        public async Task<IActionResult> GetCommentsByBlogId(Guid BlogId)
        {
            var result = await _blogcommentService.GetCommentsByBlogId(BlogId);
            return !result.Success ? BadRequest(Messages.BlogCommentNotListed) : Ok(result.Data);
        }

        [HttpPost("AddComment")]
        public async Task<IActionResult> Add(Guid blogId, BlogCommentDTO blogcomment,Guid UserId)
        {
            var result = await _blogcommentService.Add(blogId,blogcomment,UserId);
            return !result.Success ? BadRequest(Messages.BlogCommentNotAdded) : Ok(Messages.BlogCommentAdded);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid id,Guid UserId)
        {
               var result = await _blogcommentService.Delete(id,UserId);
                return !result.Success ?BadRequest(Messages.BlogCommentNotDeleted) : Ok(Messages.BlogCommentDeleted);
            
        }
        [HttpGet("GetByUserId")]
        public async Task<IActionResult> GetByUserId(Guid UserId)
        {
            var result = await _blogcommentService.GetByCommentUserId(UserId);
            return !result.Success ? BadRequest(Messages.BlogNotListed) : Ok(result.Data);


        }
        [HttpPut("UpdateBlogComment")]
        public async Task<IActionResult> Update(Guid id, BlogCommentDTO updatedcommentBlogDto,Guid UserId)
        {
            var result = await _blogcommentService.Update(id,updatedcommentBlogDto,UserId);
            return !result.Success ? BadRequest(Messages.BlogCommentNotUpdated) : Ok(Messages.BlogCommentUpdated);
           
        }
    }
}