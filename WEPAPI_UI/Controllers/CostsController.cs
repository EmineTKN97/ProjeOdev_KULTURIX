using Business.Abstract;
using Business.Constants;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostsController : ControllerBase
    {
        ICostService _costService;

        public CostsController(ICostService costService)
        {
            _costService = costService;
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _costService.GetById(id);
            return !result.Success ? BadRequest(Messages.CostNotListed) : Ok(result.Data);
        }
        [HttpPost("AddTicketPrice")]
        public async Task<IActionResult> AddTicketPrice(CostDTO costDTO)
        {
            var result = await _costService.AddTicketPrice(costDTO);
            return !result.Success ? BadRequest(Messages.NotAddTicketPrice) : Ok(Messages.AddTicketPrice);
        }
        [HttpPut("UpdateTicketPrice")]
        public async Task<IActionResult> UpdatePrice(Guid Id,CostDTO costDTO)
        {

            var result = await _costService.UpdateTicketPrice(Id,costDTO);

            return !result.Success ? BadRequest(Messages.TicketPriceNotUpdated) : Ok(Messages.TicketPriceUpdated);


        }
    }

}
