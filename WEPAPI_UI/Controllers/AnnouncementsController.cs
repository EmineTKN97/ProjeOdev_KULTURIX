using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {

        IAnnouncementService _announcementService;
        public AnnouncementsController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;

        }
        [HttpGet("GetLatestAnnouncement")]
        public async Task<IActionResult> GetLatestAnnouncement()
        {
            var result = await _announcementService.GetLatestAnnouncement();
            return !result.Success ? BadRequest(Messages.AnnouncementNotListed) : Ok(result.Data);
        }
        [HttpGet("GetAllAnnouncement")]
        public async Task<IActionResult> GetAllAnnouncement()
        {
            var result = await _announcementService.GetAllAnnouncement();
            return !result.Success ? BadRequest(Messages.AnnouncementNotListed) : Ok(result.Data);
        }
        [HttpPost("AddAnnouncement")]
        public async Task<IActionResult> AddAnnouncement(AnnouncementDTO announcementdto,Guid adminId)
        {
            var result = await _announcementService.Add(announcementdto,adminId);
            return !result.Success ? BadRequest(Messages.AnnouncementNotAdded) : Ok(Messages.AnnouncementAdded);
        }

        [HttpDelete("DeleteAnnouncement")]
        public async Task<IActionResult> DeleteAnnouncement(Guid id, Guid adminId)
        {
            try
            {
                await _announcementService.Delete(id,adminId);
                return Ok(Messages.AnnouncementDeleted);
            }
            catch (Exception ex)
            {

                return BadRequest(Messages.AnnouncementNotDeleted);
            }
        }

        [HttpPut("UpdateAnnouncement")]
        public async Task<IActionResult> Update(Guid id, AnnouncementDTO updatedannouncementdto, Guid adminId)
        {
            var existingAnnouncement = _announcementService.GetById(id);
            var result = await _announcementService.Update(id, updatedannouncementdto,adminId);

            if (existingAnnouncement != null && result.Success)
            {
                return Ok(Messages.AnnouncementUpdated);
            }
            else
            {
                return BadRequest(Messages.AnnouncementNotUpdated);
            }  
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _announcementService.GetById(id);
            return !result.Success ? BadRequest(Messages.BlogNotListed) : Ok(result.Data);
        }

    }
}

