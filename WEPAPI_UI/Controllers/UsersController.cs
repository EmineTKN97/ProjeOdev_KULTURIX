using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WEPAPI_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> Delete(Guid id)
        {
           var result= await _userService.Delete(id);
            return !result.Success ? BadRequest(Messages.UserNotDeleted) : Ok(Messages.UserDeleted);
    
            
        }
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> Update(Guid id, UserDTO userdto)
        {
            var existingUser = await _userService.GetById(id);
            var result = await _userService.Update(id, userdto);

            if (existingUser != null && result.Success)
            {
                return Ok(Messages.UserUpdated);
            }
            else
            {
                return BadRequest(Messages.UserNotUpdated);
            }
        }
        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword(string currentPassword, string newPassword,Guid UserId)
        {
            var result = await _userService.ChangePassword(currentPassword, newPassword, UserId);
            if (result.Success)
            {
                return Ok(Messages.ChangePassword);
            }

            return BadRequest(Messages.ChangeNotPassword);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid UserId)
        {
            var result = await _userService.GetById(UserId);
            return !result.Success ? BadRequest(Messages.UserNotListed) : Ok(result.Data);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUser()
        {
            var result = _userService.GetAll();
            return !result.Success ? BadRequest(Messages.UserNotListed) : Ok(result.Data);
        }
    }
}
