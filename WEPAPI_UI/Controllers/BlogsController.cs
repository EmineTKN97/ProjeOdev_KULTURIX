using Business.Abstract;
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

        [HttpGet("GetAllBlogDetails")]
        public ActionResult<BlogDetailsDTO> GetAllBlogDetails()
        {
            var result = _blogService.GetAllBlogDetails();
            if (result is null) return NotFound();
            return Ok(result);

        }
        [HttpGet("GetBlogDetails")]
        public ActionResult<BlogDTO> GetBlogDetails()
        {
            var result = _blogService.GetBlogDetails();
            return Ok(result);

        }
        [HttpGet("GetById")]
        public ActionResult<BlogDTO> GetById(Guid id)
        {
            var result = _blogService.GetById(id);
            return Ok(result);

        }
        [HttpPost("AddBlog")]
        public ActionResult<BlogDTO> AddBlog(BlogDTO blog)
        {
            _blogService.Add(blog);
            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _blogService.Delete(id);
                return Ok("Blog başarıyla silindi.");
            }
            catch (Exception ex)
            {

                return BadRequest($"Blog silme işlemi başarısız. Hata: {ex.Message}");
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
                    return Ok("Blog başarıyla güncellendi.");
                }
                else
                {
                    return NotFound("Belirtilen id'ye sahip blog bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Blog güncelleme işlemi başarısız. Hata: {ex.Message}");
            }
        }
    }
}

