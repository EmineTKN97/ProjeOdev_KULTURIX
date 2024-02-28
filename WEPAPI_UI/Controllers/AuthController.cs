using Azure.Core;
using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : Controller
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        
            
        }

        [HttpPost("loginUser")]
        public ActionResult Login(UserForLoginDTO userForLoginDto)
        {

            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(Messages.ErrorLogin);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(new { data = result.Data, message = Messages.SuccessfulLogin });
            }

            return BadRequest(Messages.ErrorLogin);
        }

        [HttpPost("registerUser")]
        public async Task<IActionResult> Register(UserForRegisterDTO userForRegisterDto)
        {
            
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(new { data = result.Data, message = Messages.UserRegistered } );
            }

            return BadRequest(result);
        
        }
        [HttpPost("loginAdmin")]
        public ActionResult Login(AdminForLoginDTO adminForLoginDto)
        {
            var adminToLogin = _authService.LoginAdmin(adminForLoginDto);
            if (!adminToLogin.Success)
            {
                return BadRequest(Messages.ErrorLogin);
            }

            var result = _authService.CreateAccessTokenAdmin(adminToLogin.Data);
            if (result.Success)
            {
                return Ok(new { data = result.Data, message = Messages.SuccessfulLogin});
            }

            return BadRequest(result);
        }

        [HttpPost("registerAdmin")]
        public ActionResult Register(AdminForRegisterDTO adminForRegisterDto)
        {
            var adminExists = _authService.AdminExists(adminForRegisterDto.Email);
            if (!adminExists.Success)
            {
                return BadRequest(adminExists.Message);
            }

            var registerAdminResult = _authService.RegisterAdmin(adminForRegisterDto, adminForRegisterDto.Password);
            var result = _authService.CreateAccessTokenAdmin(registerAdminResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
       
    }
}
