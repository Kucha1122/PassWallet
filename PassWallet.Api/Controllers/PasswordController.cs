using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PassWallet.Infrastructure.DTO;
using PassWallet.Infrastructure.DTO.Commands;
using PassWallet.Infrastructure.Services;

namespace PassWallet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordService _passwordService;
        private readonly IUserService _userService;

        public PasswordController(IPasswordService passwordService, IUserService userService)
        {
            _passwordService = passwordService;
            _userService = userService;
        }
        
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<PasswordDto>> GetAsync(Guid id)
        {
            var password = await _passwordService.GetAsync(id);
            
            if (password is null)
            {
                return NotFound();
            }

            return Ok(password);
        }
        
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<PasswordDto>>> BrowseAsync()
            => Ok(await _passwordService.BrowseAsync());

        [Authorize]
        [HttpPost("all")]
        public async Task<ActionResult<IEnumerable<PasswordDto>>> BrowseAsyncById()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            
            return Ok(await _passwordService.BrowseAsync(Guid.Parse(userId)));
        }

        
        [Authorize]
        [HttpPost("add")]
        public async Task<ActionResult> AddAsync(CreatePasswordCommand command)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            command.OwnerId = Guid.Parse(userId);
            
            await _passwordService.AddAsync(command);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteAsync(DeletePasswordCommand command)
        {
            await _passwordService.DeleteAsync(command);
            return Ok();
        }
    }
}