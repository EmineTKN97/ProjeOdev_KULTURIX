using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
         IBlogService _blogService;
        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet("GetBlogsByCommentAndLikeCount")]
        public async Task<ActionResult> GetBlogsByCommentAndLikeCounts()
        {
            var result = await _blogService.GetBlogsByCommentAndLikeCount();
            if (!result.Success) 
            return BadRequest(Messages.BlogNotListed);
            return Ok(result.Data);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _blogService.GetById(id);
            if(result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(Messages.BlogNotListed);
            

        }
        [HttpPost("AddBlog")]
        public  async Task<IActionResult> AddBlog(BlogDTO blogdto)
        {
            var result = await _blogService.Add(blogdto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
               await _blogService.Delete(id);
                return Ok(Messages.BlogDeleted);
            }
            catch (Exception ex)
            {

                return BadRequest(Messages.BlogNotDeleted);
            }
        }

        [HttpPut("UpdateBlog")]
        public async Task<IActionResult>Update(Guid id, BlogDTO updatedBlogDto)
        {
            try
            {
                var existingBlog = _blogService.GetById(id);

                if (existingBlog != null)
                { 
                   await  _blogService.Update(id, updatedBlogDto);
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

