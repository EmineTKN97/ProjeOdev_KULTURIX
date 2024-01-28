using Business.Abstract;
using Business.Constants;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediasController : ControllerBase
    {
        IMediaService _mediaService;

        public MediasController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        [HttpPost("AddBlogMedia")]
        public async Task<IActionResult> AddBlogMedia(IFormFile file,Guid BlogId)
        {
            var result = await _mediaService.AddBlogMedia(file,BlogId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(Messages.MediaNotAdded);
        }
        [HttpPost("AddUserMedia")]
        public async Task<IActionResult> AddUserMedia(IFormFile file, Guid UserId)
        {
            var result = await _mediaService.AddUserMedia(file, UserId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(Messages.MediaNotAdded);
        }

    }
}
