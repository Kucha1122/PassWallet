using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        [HttpPost("all")]
        public async Task<ActionResult<IEnumerable<PasswordDto>>> BrowseAsync([FromBody] GetPasswordsCommand command)
            => Ok(await _passwordService.BrowseAsync(command.Id));
        
        [HttpPost("add")]
        public async Task<ActionResult> AddAsync(CreatePasswordCommand command)
        {
            var user = await _userService.GetAsync(command.OwnerId);
            await _passwordService.AddAsync(command, user);
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