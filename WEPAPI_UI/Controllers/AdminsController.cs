using Business.Abstract;
using Business.Constants;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private IAdminService _adminService;

        public AdminsController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpDelete("DeleteAdmin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _adminService.Delete(id);
                return Ok(Messages.AdminDeleted);
            }
            catch (Exception ex)
            {

                return BadRequest(Messages.AdminNotDeleted);
            }
        }
        [HttpPut("UpdateAdmin")]
        public async Task<IActionResult> Update(Guid id, AdminDTO admindto)
        {
            var existingadmin = await _adminService.GetById(id);
            var result = await _adminService.Update(id, admindto);

            if (existingadmin != null && result.Success)
            {
                return Ok(Messages.AdminUpdated);
            }
            else
            {
                return BadRequest(Messages.AdminNotUpdated);
            }
        }
        [HttpPut("ChangeAdminPassword")]
        public async Task<IActionResult> ChangeAdminPassword(string currentPassword, string newPassword, Guid AdminId)
        {
            var result = await _adminService.ChangeAdminPassword(currentPassword, newPassword, AdminId);
            if (result.Success)
            {
                return Ok(Messages.ChangeAdminPassword);
            }

            return BadRequest(Messages.ChangeNotPassword);
        }

    }
}
