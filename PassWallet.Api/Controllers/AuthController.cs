using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PassWallet.Infrastructure.DTO;
using PassWallet.Infrastructure.DTO.Commands;
using PassWallet.Infrastructure.DTO.User.Commands;
using PassWallet.Infrastructure.Services;

namespace PassWallet.Api.Controllers
{    
    [ApiController]
    [Route("[controller]")]
    [EnableCors("MyPolicy")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody]RegisterUserCommand command)
        {
            if (ModelState.IsValid)
            {
                await _userService.RegisterAsync(command);
            }
            return Created("User registered.", command);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginUserCommand command)
        {
            if (ModelState.IsValid)
            {
                var token = new TokenDto();
                try
                {
                    token = await _userService.LoginAsync(command);
                }
                catch (Exception)
                {
                    return BadRequest("Invalid credentials.");
                }

                return Ok(token);
            }
            
            return BadRequest("Invalid credentials.");
        }
    }
}