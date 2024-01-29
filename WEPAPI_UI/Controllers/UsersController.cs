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
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AdUser(UserDTO userdto)
        {
            var result = await _userService.Add(userdto);
            return !result.Success ? BadRequest(Messages.UserNotAdded) : Ok(result);
        }
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _userService.Delete(id);
                return Ok(Messages.UserDeleted);
            }
            catch (Exception ex)
            {

                return BadRequest(Messages.UserNotDeleted);
            }
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> Update(Guid id, UserDTO userDto)
        {

            var result = await _userService.Update(id, userDto);
            return !result.Success ? BadRequest(Messages.UserNotUpdated) : Ok(Messages.UserUpdated);
        }
        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllUsers();
            return !result.Success ? BadRequest(Messages.UserNotListed) : Ok(result.Data);
        }
    }
}
