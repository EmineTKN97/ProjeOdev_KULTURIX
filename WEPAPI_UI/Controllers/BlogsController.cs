using Azure.Messaging;
using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WEPAPI_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _blogService;
        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet(" GetBlogsByCommentAndLikeCount")]
        public ActionResult<BlogDetailsDTO> GetBlogsByCommentAndLikeCounts()
        {
            var result = _blogService.GetBlogsByCommentAndLikeCount();
            if (result is null) return NotFound(Messages.BlogNotListed);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public ActionResult<BlogDTO> GetById(Guid id)
        {
            var result = _blogService.GetById(id);
            if(result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(Messages.BlogNotListed);
            

        }
        [HttpPost("AddBlog")]
        public ActionResult<BlogDTO> AddBlog(BlogDTO blog)
        {
            var result = _blogService.Add(blog);
            if (result.Success == true)
            {
                return Ok(Messages.BlogAdded);
            }
            return BadRequest(Messages.BlogNotAdded);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _blogService.Delete(id);
                return Ok(Messages.BlogDeleted);
            }
            catch (Exception ex)
            {

                return BadRequest(Messages.BlogNotDeleted);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, BlogDTO updatedBlogDto)
        {
            try
            {
                var existingBlog = _blogService.GetById(id);

                if (existingBlog != null)
                { 
                    _blogService.Update(id, updatedBlogDto);
                    return Ok(Messages.BlogUpdated);
                }
                else
                {
                    return NotFound(Messages.BlogNotUpdated);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.BlogNotUpdated);
            }
        }
    }
}

