using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var result = _blogService.GetAll();
        return Ok(result);
    }

    [HttpGet("Get")]
    public IActionResult Get(Guid id)
    {
        var result = _blogService.GetById(id);
        return Ok(result);
    }

    [HttpPost("Add")]
    public IActionResult Add(Blog blog)
    {
        _blogService.Add(blog);
        return Ok();
    }

    [HttpDelete("Delete")]
    public IActionResult Delete(Guid id)
    {
        var deletedEntity = _blogService.GetById(id);

        if (deletedEntity != null)
        {
            _blogService.Delete(deletedEntity);
            return Ok();
        }

        return BadRequest();
    }


    [HttpPut("Update")]
    public IActionResult Update(Blog blog)
    {
        _blogService.Update(blog);
        return Ok();
    }
}
}

