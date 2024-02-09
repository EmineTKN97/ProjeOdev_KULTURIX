using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

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
        public async Task<IActionResult> GetBlogsByCommentAndLikeCounts()
        {
            var result = await _blogService.GetBlogsByCommentAndLikeCount();
            return !result.Success ? BadRequest(Messages.BlogNotListed) : Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _blogService.GetById(id);
            return !result.Success ? BadRequest(Messages.BlogNotListed) : Ok(result.Data);
        }
        [HttpPost("AddBlog")]
        public  async Task<IActionResult> AddBlog(BlogDTO blogdto,Guid UserId)
        {
            var result = await _blogService.Add(blogdto,UserId);
            return !result.Success ? BadRequest(Messages.BlogNotAdded) : Ok(Messages.BlogAdded);
        }

        [HttpDelete("DeleteBlog")]
        public async Task<IActionResult> Delete(Guid id,Guid UserId)
        {
            try
            {
               await _blogService.Delete(id, UserId);
                return Ok(Messages.BlogDeleted);
            }
            catch (Exception ex)
            {

                return BadRequest(Messages.BlogNotDeleted);
            }
        }

        [HttpPut("UpdateBlog")]
        public async Task<IActionResult>Update(Guid id, BlogDTO updatedBlogDto, Guid UserId)
        {
              var existingBlog = await _blogService.GetById(id);
                var result = await _blogService.Update(id,updatedBlogDto, UserId);

                if (existingBlog != null && result.Success)
                { 
                    return Ok(Messages.BlogUpdated);
                }
                else
                {
                    return BadRequest(Messages.BlogNotUpdated);
                }
        }
        [HttpGet("GetByUserId")]
        public async Task<IActionResult> GetByUserId(Guid UserId)
        {
            var result = await _blogService.GetByUserId(UserId);
            return !result.Success ? BadRequest(Messages.BlogNotListed) : Ok(result.Data);


        }
        [HttpGet("GetLatestBlog")]
        public async Task<IActionResult> GetLatestBlog()
        {
            var result = await _blogService.GetLatestBlog();
            return !result.Success ? BadRequest(Messages.BlogNotListed) : Ok(result.Data);
        }
    }
}
