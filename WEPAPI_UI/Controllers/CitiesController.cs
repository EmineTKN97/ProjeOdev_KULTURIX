using Business.Abstract;
using Business.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
       
            ICityService _cityService;
            public CitiesController(ICityService cityService)
            {
                _cityService = cityService;

            }
            [HttpGet("GetAllCities")]
            public async Task<IActionResult> GetAllCities()
            {
                var result = await _cityService.GetAll();
                return !result.Success ? BadRequest() : Ok(result);
            }
        }
}
