using Api.Services;
namespace Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Api.Models.Dtos;
using Api.Helpers;

[ApiController]
    [Route("[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private IUserService _userService;
        public AuthenticateController(IUserService userService)
        {
            _userService= userService;
        }
    
    [AllowAnonymous]
    [HttpPost("login")]
    
    public IActionResult Login(AuthenticateRequest model)
    {
        var response = _userService.Authenticate(model);
        return Ok(response);
        //try
        //{
        //    var response = _userService.Authenticate(model);
        //    return Ok(response);

        //} 
        //catch (Exception ex)
        //{
        //    if (ex is UnauthorizedException)

        //        return StatusCode(401);

        //}

    }

    [AllowAnonymous]
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest model)
        {
        _userService.Register(model);
        return Ok(new { message = "Registration successful" });
    }
}
