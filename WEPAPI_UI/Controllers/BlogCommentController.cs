using Business.Abstract;
using Entities.Concrete;
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
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {


            var result = _blogcommentService.GetAll();
            return Ok(result);
        }

        [HttpGet("Get")]
        public IActionResult Get(Guid id)
        {
            var result = _blogcommentService.GetById(id);
            return Ok(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(BlogComment blogcomment)
        {
            _blogcommentService.Add(blogcomment);
            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(Guid id)
        {
            var deletedEntity = _blogcommentService.GetById(id);

            if (deletedEntity != null)
            {
                _blogcommentService.Delete(deletedEntity);
                return Ok();
            }

            return BadRequest();
        }


        [HttpPut("Update")]
        public IActionResult Update(BlogComment blogcomment)
        {
            _blogcommentService.Update(blogcomment);
            return Ok();
        }
    }
}