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


        [HttpGet("GetBlogCommentsDetails")]
        public async Task<IActionResult> GetAllCommentsDetails()
        {
            var result = await _blogcommentService.GetAllCommentsDetails();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return NotFound(Messages.BlogCommentNotListed);


        }
        [HttpGet("GetCommentsByBlogId")]
        public async Task<IActionResult> GetCommentsByBlogId(Guid BlogId)
        {
            var result = await _blogcommentService.GetCommentsByBlogId(BlogId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
                return BadRequest(Messages.BlogCommentNotListed);
           
            

        }

        [HttpPost("AddComment")]
        public async Task<IActionResult> Add(Guid blogId, BlogCommentDTO blogcomment)
        {
            var result = await _blogcommentService.Add(blogId,blogcomment);
            if (result.Success)
            {
                return Ok(Messages.BlogCommentAdded);
            }
            return BadRequest(Messages.BlogCommentNotAdded);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _blogcommentService.Delete(id);
                return Ok(Messages.BlogCommentDeleted);
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.BlogCommentNotDeleted);
            }
        }

        [HttpPut("UpdateBlogComment")]
        public async Task<IActionResult> Update(Guid id, BlogCommentDTO updatedcommentBlogDto)
        {
            try
            {
                await _blogcommentService.Update(id, updatedcommentBlogDto);
                return Ok(Messages.BlogCommentUpdated);
            }
            catch (Exception exception)
            {
                return BadRequest(Messages.BlogCommentNotUpdated);
            }
        }
    }
}