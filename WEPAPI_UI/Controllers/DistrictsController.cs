using Business.Abstract;
using Business.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {

        IDistrictService _districtService;
        public DistrictsController(IDistrictService districtService)
        {
            _districtService = districtService;

        }
        [HttpGet("GetAllDistricts")]
        public async Task<IActionResult> GetAllDistricts()
        {
            var result = await _districtService.GetAll();
            return !result.Success ? BadRequest() : Ok(result);
        }
        [HttpGet("GetDistrictCityId")]
        public async Task<IActionResult> GetCityIdDistricts(int cityId)
        {
            var result = await _districtService.GetCityId(cityId);
            return !result.Success ? BadRequest() : Ok(result);
        }
    }
}
