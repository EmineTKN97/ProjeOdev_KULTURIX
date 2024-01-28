using Business.Abstract;
using Business.Constants;
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
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(Messages.UserNotAdded);
        }
    }
}
