using Business.Abstract;
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
            return Ok(result);

        }

        [HttpPost("AddComment")]
        public ActionResult<BlogCommentDTO> Add(Guid blogId, BlogCommentDTO blogcomment)
        {
            _blogcommentService.Add(blogId, blogcomment);
            return Ok();
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _blogcommentService.Delete(id);
                return Ok("Blog başarıyla silindi.");
            }
            catch (Exception ex)
            {
                // Eğer bir hata oluşursa, isteğe bağlı olarak hata durumu ile cevap verebilirsiniz.
                return BadRequest($"Blog silme işlemi başarısız. Hata: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, BlogCommentDTO updatedcommentBlogDto)
        {
            try
            {
                _blogcommentService.Update(id, updatedcommentBlogDto);
                return Ok("Blog başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Blog güncelleme işlemi başarısız. Hata: {ex.Message}");
            }
        }
    }
}