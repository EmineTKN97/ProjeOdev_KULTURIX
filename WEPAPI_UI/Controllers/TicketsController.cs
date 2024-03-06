using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        
        [HttpPost("AddTicket")]
        public async Task<IActionResult> AddTicket(TicketDTO ticketdto, Guid UserId)
        {
            var result = await _ticketService.Add(ticketdto, UserId);
            return !result.Success ? BadRequest(Messages.TicketNotAdded) : Ok(Messages.TicketAdded);
        }
        [HttpPost("AddTicketPrice")]
        public async Task<IActionResult> AddTicketPrice(decimal Price)
        {
            var result = await _ticketService.AddTicketPrice(Price);
            return !result.Success ? BadRequest(Messages.NotAddTicketPrice) : Ok(Messages.AddTicketPrice);
        }

        [HttpDelete("DeleteTicket")]
        public async Task<IActionResult> Delete(Guid id, Guid UserId)
        {
            try
            {
                await _ticketService.Delete(id, UserId);
                return Ok(Messages.TicketDeleted);
            }
            catch (Exception ex)
            {

                return BadRequest(Messages.TicketNotDeleted);
            }
        }

        [HttpPut("UpdateTicket")]
        public async Task<IActionResult> Update(Guid id, TicketDTO ticketDto, Guid UserId)
        {
           
            var result = await _ticketService.Update(id, ticketDto, UserId);

            return !result.Success ? BadRequest(Messages.TicketNotUpdated) : Ok(Messages.TicketUpdated);
              
            
        }
        [HttpPut("UpdateTicketPrice")]
        public async Task<IActionResult> UpdatePrice(decimal Price)
        {

            var result = await _ticketService.UpdateTicketPrice(Price);

            return !result.Success ? BadRequest(Messages.TicketPriceNotUpdated) : Ok(Messages.TicketPriceUpdated);


        }
        [HttpGet("GetByUserId")]
        public async Task<IActionResult> GetByUserId(Guid UserId)
        {
            var result = await _ticketService.GetByUserId(UserId);
            return !result.Success ? BadRequest(Messages.TicketNotListed) : Ok(result.Data);


        }
       
        [HttpGet("GetAllTicketDetails")]
        public async Task<IActionResult> GetAllTicketDetails()
        {
            var result = await _ticketService.GetAllTicketDetails();
            return !result.Success ? BadRequest(Messages.TicketNotListed) : Ok(result.Data);
        }
      
    
    }
}
