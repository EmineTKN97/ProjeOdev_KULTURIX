using Business.Abstract;
using Business.Constants;
using DataAccess.Migrations;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace WEPAPI_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCommentController : ControllerBase
    {
        private readonly IBlogCommentService _blogcommentService;
        public BlogCommentController(IBlogCommentService blogcommentService)
        {
            _blogcommentService = blogcommentService;
        }


        [HttpGet("GetBlogCommentsDetails")]
        public ActionResult<BlogCommentDTO> GetAllCommentsDetails()
        {
            var result = _blogcommentService.GetAllCommentsDetails();
            if (result is null) return NotFound(Messages.BlogCommentNotListed);
            return Ok(result);

        }
        [HttpGet("GetCommentsByBlogId")]
        public ActionResult<BlogCommentDTO> GetCommentsByBlogId(Guid BlogId)
        {
            var result = _blogcommentService.GetCommentsByBlogId(BlogId);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(Messages.BlogCommentNotListed);
            ;

        }

        [HttpPost("AddComment")]
        public ActionResult<BlogCommentDTO> Add(Guid blogId, BlogCommentDTO blogcomment)
        {
            var result = _blogcommentService.Add(blogId,blogcomment);
            if (result.Success == true)
            {
                return Ok(Messages.BlogCommentAdded);
            }
            return BadRequest(Messages.BlogCommentNotAdded);
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _blogcommentService.Delete(id);
                return Ok(Messages.BlogCommentDeleted);
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.BlogCommentNotDeleted);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, BlogCommentDTO updatedcommentBlogDto)
        {
            try
            {
                _blogcommentService.Update(id, updatedcommentBlogDto);
                return Ok(Messages.BlogCommentUpdated);
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.BlogCommentNotUpdated);
            }
        }
    }
}